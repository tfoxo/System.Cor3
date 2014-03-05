/* oio : 1/8/2014 10:39 PM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

using MuPDFLib;

namespace Pdf2Png
{
	/// <summary>
	/// Description of ColorMatrixControl.
	/// </summary>
	public partial class ColorMatrixControl : Form
	{
		#region Static 
		static MatrixCollection MatrixCollection { get; set; }
		static OpenFileDialog ofd_pdf { get; set; }
		#endregion
		
		#region Properties
		FileInfo InputFileInfo { get; set; }
		IDMatrix ImageColorMatrix { get; set; }
		public int NumPages { get; set; }
		
		bool HasInput
		{
			get
			{
				if (InputFileInfo==null) return false;
				else if (!InputFileInfo.Exists) return false;
				return true;
			}
		}
		#endregion
		
		#region Constructor
		static ColorMatrixControl()
		{
			FileInfo asm = new FileInfo(Assembly.GetExecutingAssembly().Location);
			string settingsfile = Path.Combine(asm.Directory.FullName,"default.settings");
			ofd_pdf = new OpenFileDialog { Filter = "Adobe PDF|*.pdf" };
			MatrixCollection = MatrixCollection.Load(settingsfile);
		}
		
		public ColorMatrixControl()
		{
			InitializeComponent();
			tbInputFile.ApplyDefaultDragDrop();
			DoubleBuffered = true;
			this.cbMatrixMode.DataSource = MatrixCollection.Children;
			this.cbMatrixMode.DisplayMember = "Key";
			this.cbMatrixMode.SelectedText = "default";
			this.cbMatrixMode.SelectedIndexChanged += Event_MatrixSelected;
		}
		#endregion
		
		void RefreshNumPages()
		{
			using (MuPDF pdfDoc = new MuPDF(InputFileInfo.FullName, null))
			{
				NumPages = pdfDoc.PageCount;
				
				nPageStart.Minimum = 1;
				nPageStart.Value = 1;
				nPageStart.Maximum = NumPages;
				
				nPagesCount.Maximum = NumPages;
				nPagesCount.Minimum = 1;
				nPagesCount.Value = NumPages;
			}
		}
		void UpdateFileName()
		{
			InputFileInfo = new FileInfo(tbInputFile.Text);
		}
		
		#region Methods Matrix
		void Event_MatrixSelected(object sender, EventArgs e)
		{
			SetColorMatrix(MatrixCollection.Children[0]);
		}
		ColorMatrix GetColorMatrix()
		{
			return new IDMatrix(
				new float[][]{
					new float[] { Convert.ToSingle(cm00.Value),Convert.ToSingle(cm01.Value),Convert.ToSingle(cm02.Value),Convert.ToSingle(cm03.Value),Convert.ToSingle(cm04.Value) },
					new float[] { Convert.ToSingle(cm10.Value),Convert.ToSingle(cm11.Value),Convert.ToSingle(cm12.Value),Convert.ToSingle(cm13.Value),Convert.ToSingle(cm14.Value) },
					new float[] { Convert.ToSingle(cm20.Value),Convert.ToSingle(cm21.Value),Convert.ToSingle(cm22.Value),Convert.ToSingle(cm23.Value),Convert.ToSingle(cm24.Value) },
					new float[] { Convert.ToSingle(cm30.Value),Convert.ToSingle(cm31.Value),Convert.ToSingle(cm32.Value),Convert.ToSingle(cm33.Value),Convert.ToSingle(cm34.Value) },
					new float[] { Convert.ToSingle(cm40.Value),Convert.ToSingle(cm41.Value),Convert.ToSingle(cm42.Value),Convert.ToSingle(cm43.Value),Convert.ToSingle(cm44.Value) },
				});
		}
		void SetColorMatrix(IDMatrix m)
		{
			cm00.Value = (decimal)m.Matrix00;
			cm01.Value = (decimal)m.Matrix01;
			cm02.Value = (decimal)m.Matrix02;
			cm03.Value = (decimal)m.Matrix03;
			cm04.Value = (decimal)m.Matrix04;
			//
			cm10.Value = (decimal)m.Matrix10;
			cm11.Value = (decimal)m.Matrix11;
			cm12.Value = (decimal)m.Matrix12;
			cm13.Value = (decimal)m.Matrix13;
			cm14.Value = (decimal)m.Matrix14;
			//
			cm20.Value = (decimal)m.Matrix20;
			cm21.Value = (decimal)m.Matrix21;
			cm22.Value = (decimal)m.Matrix22;
			cm23.Value = (decimal)m.Matrix23;
			cm24.Value = (decimal)m.Matrix24;
			//
			cm30.Value = (decimal)m.Matrix30;
			cm31.Value = (decimal)m.Matrix31;
			cm32.Value = (decimal)m.Matrix32;
			cm33.Value = (decimal)m.Matrix33;
			cm34.Value = (decimal)m.Matrix34;
			//
			cm40.Value = (decimal)m.Matrix40;
			cm41.Value = (decimal)m.Matrix41;
			cm42.Value = (decimal)m.Matrix42;
			cm43.Value = (decimal)m.Matrix43;
			cm44.Value = (decimal)m.Matrix44;
			//
			System.Diagnostics.Debug.WriteLine("{0}", m);
		}
		#endregion
		
		#region Method: Button-Event
		void BtnBrowsePdfClick(object sender, EventArgs e)
		{
			if (ofd_pdf.ShowDialog() == DialogResult.OK)
			{
				tbInputFile.Text = ofd_pdf.FileName;
				UpdateFileName();
				btnUpdate.PerformClick();
			}
		}
		
		
		void ButtonAboutClick(object sender, EventArgs e)
		{
		}
		void BtnUpdateClick(object sender, EventArgs e)
		{
			UpdateFileName();
			if (!HasInput) {
				Console.WriteLine("No input");
				Console.WriteLine("Aborting");
				return;
			}
			if (ExportWorker!=null) {
				//throw exception or ask
				Console.WriteLine("Worker process working.");
				Console.WriteLine("Aborting");
				return;
			}
//			RefreshNumPages();
//			if (NumPages == 0) return;
			
			progressBar1.Maximum = 1;
			this.ImageColorMatrix = GetColorMatrix();
			ExportWorker = new PdfWorker(InputFileInfo,ImageColorMatrix,Convert.ToSingle(nDpi.Value), Convert.ToInt32(nPageStart.Value), Convert.ToInt32(nPagesCount.Value));
			Console.WriteLine("Worker init");
			ExportWorker.ProgressChanged += Exporter_Progress;
			ExportWorker.RunWorkerCompleted += Exporter_Completed;
			ExportWorker.WorkerReportsProgress = true;
			ExportWorker.WorkerSupportsCancellation = true;
			ExportWorker.RunWorkerAsync();
		}
		
		void BtnProcessClick(object sender, EventArgs e)
		{
		}
		#endregion
		
		#region BackgroundWorker
		
		PdfWorker ExportWorker;
		
		void Exporter_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			NumPages = 0;
			ExportWorker.Dispose();
			ExportWorker = null;
			progressBar1.Value = (progressBar1.Maximum = 0);
		}
		
		void Exporter_Progress(object sender, ProgressChangedEventArgs e)
		{
			Console.WriteLine("Worker progress {0}",e.ProgressPercentage);
			progressBar1.Value = e.ProgressPercentage;
		}
		
		void ButtonUpdatePageCountLength(object sender, System.EventArgs e)
		{
			UpdateFileName();
			if (!HasInput) {
				Console.WriteLine("No input");
				Console.WriteLine("Aborting");
				return;
			}
			if (ExportWorker!=null) {
				//throw exception or ask
				Console.WriteLine("Worker process working.");
				Console.WriteLine("Aborting");
				return;
			}
			RefreshNumPages();
		}
		void NPageStartValueChanged(object sender, System.EventArgs e)
		{
			throw new NotImplementedException();
		}
		#endregion
		
		public class PdfWorker : BackgroundWorker
		{
			FileInfo inputFile;
			ColorMatrix colorMatrix;
			float DPI;
			
			int pageStart = 0, pageLength = 0;
			
			public PdfWorker(FileInfo inputFile, ColorMatrix matrix, float dpi, int pageStart, int pageLength)
			{
				this.DPI = dpi;
				this.inputFile = inputFile;
				this.colorMatrix = matrix;
				this.pageStart = pageStart;
				this.pageLength = pageStart+pageLength;
			}
			protected override void OnDoWork(DoWorkEventArgs e)
			{
//				Console.WriteLine("Doing work");
				ReportProgress(0);
				
				lfoo.PdfToImage(
					this.inputFile.FullName,
					this.DPI,
					RenderType.RGB,
					false,
					false,
					360000, // max image size.
					null,
					this.colorMatrix,
					this.pageStart,
					this.pageLength
				);
				ReportProgress(1);
//				Console.WriteLine("Worker finishing");
				CancelAsync();
//				Console.WriteLine("Worker fin");
			}
		}
	}
}
