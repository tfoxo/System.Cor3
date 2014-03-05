/* oio : 1/8/2014 10:39 PM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using MuPDFLib;

namespace System.Drawing
{
	[XmlRoot("MatrixSet")]
	public class MatrixCollection : SerializableClass<MatrixCollection>
	{
		[XmlArray("Items")]
		[XmlArrayItem("Matrix")]
//		[XmlElement("Items")]
		public List<IDMatrix> Children { get; set; }
		
		public MatrixCollection()
		{
		}
	}
	
	[XmlRoot("Matrix")]
	public class IDMatrix
	{
		public override string ToString()
		{
			return string.Format("{{Matrix: Key=\"{0}\", Value=\"{1}\" }}",Key,Identity);
		}

		
		public System.Drawing.Imaging.ColorMatrix ColorMatrix { get { return new System.Drawing.Imaging.ColorMatrix(this.Value); } }
		
		static public implicit operator ColorMatrix(IDMatrix m)
		{
			return m.ColorMatrix;
		}
		
		static public implicit operator IDMatrix(ColorMatrix m)
		{
			return new IDMatrix(
				m.Matrix00, m.Matrix01, m.Matrix02, m.Matrix03, m.Matrix04,
				m.Matrix10, m.Matrix11, m.Matrix12, m.Matrix13, m.Matrix14,
				m.Matrix20, m.Matrix21, m.Matrix22, m.Matrix23, m.Matrix24,
				m.Matrix30, m.Matrix31, m.Matrix32, m.Matrix33, m.Matrix34,
				m.Matrix40, m.Matrix41, m.Matrix42, m.Matrix43, m.Matrix44
			);
		}
		
		#region Methods
		//
		void SetMatrix(float[][] value)
		{
			Matrix00 = value[0][0]; Matrix01 = value[0][1]; Matrix02 = value[0][2]; Matrix03 = value[0][3]; Matrix04 = value[0][4];
			Matrix10 = value[1][0]; Matrix11 = value[1][1]; Matrix12 = value[1][2]; Matrix13 = value[1][3]; Matrix14 = value[1][4];
			Matrix20 = value[2][0]; Matrix21 = value[2][1]; Matrix22 = value[2][2]; Matrix23 = value[2][3]; Matrix24 = value[2][4];
			Matrix30 = value[3][0]; Matrix31 = value[3][1]; Matrix32 = value[3][2]; Matrix33 = value[3][3]; Matrix34 = value[3][4];
			Matrix40 = value[4][0]; Matrix41 = value[4][1]; Matrix42 = value[4][2]; Matrix43 = value[4][3]; Matrix44 = value[4][4];
		}
		//
		void SetMatrix(params float[] value)
		{
			Matrix00 = value[ 0]; Matrix01 = value[ 1]; Matrix02 = value[ 2]; Matrix03 = value[ 3]; Matrix04 = value[ 4];
			Matrix10 = value[ 5]; Matrix11 = value[ 6]; Matrix12 = value[ 7]; Matrix13 = value[ 8]; Matrix14 = value[ 9];
			Matrix20 = value[10]; Matrix21 = value[11]; Matrix22 = value[12]; Matrix23 = value[13]; Matrix24 = value[14];
			Matrix30 = value[15]; Matrix31 = value[16]; Matrix32 = value[17]; Matrix33 = value[18]; Matrix34 = value[19];
			Matrix40 = value[20]; Matrix41 = value[21]; Matrix42 = value[22]; Matrix43 = value[23]; Matrix44 = value[24];
		}
		//
		void SetMatrix(params double[] value)
		{
			Matrix00 = Convert.ToSingle(value[ 0]); Matrix01 = Convert.ToSingle(value[ 1]); Matrix02 = Convert.ToSingle(value[ 2]); Matrix03 = Convert.ToSingle(value[ 3]); Matrix04 = Convert.ToSingle(value[ 4]);
			Matrix10 = Convert.ToSingle(value[ 5]); Matrix11 = Convert.ToSingle(value[ 6]); Matrix12 = Convert.ToSingle(value[ 7]); Matrix13 = Convert.ToSingle(value[ 8]); Matrix14 = Convert.ToSingle(value[ 9]);
			Matrix20 = Convert.ToSingle(value[10]); Matrix21 = Convert.ToSingle(value[11]); Matrix22 = Convert.ToSingle(value[12]); Matrix23 = Convert.ToSingle(value[13]); Matrix24 = Convert.ToSingle(value[14]);
			Matrix30 = Convert.ToSingle(value[15]); Matrix31 = Convert.ToSingle(value[16]); Matrix32 = Convert.ToSingle(value[17]); Matrix33 = Convert.ToSingle(value[18]); Matrix34 = Convert.ToSingle(value[19]);
			Matrix40 = Convert.ToSingle(value[20]); Matrix41 = Convert.ToSingle(value[21]); Matrix42 = Convert.ToSingle(value[22]); Matrix43 = Convert.ToSingle(value[23]); Matrix44 = Convert.ToSingle(value[24]);
		}
		#endregion
		
		#region Constructor
		public IDMatrix() {
			SetMatrix(
				1f,0f,0f,0f,0f,
				0f,1f,0f,0f,0f,
				0f,0f,1f,0f,0f,
				0f,0f,0f,1f,0f,
				0f,0f,0f,0f,1f
			);
		}
		//
		public IDMatrix(params double[] inputValues) { SetMatrix(inputValues); }
		//
		public IDMatrix(params float[] inputValues) { SetMatrix(inputValues); }
		//
		public IDMatrix(float[][] inputValues) { this.Value = inputValues; }
		#endregion
		
		[XmlAttribute] public string Key { get; set; }
		[XmlAttribute] public string Description { get; set; }
		
		#region Properties
		//
		/// <summary>Red Factor</summary>
		[XmlIgnore] public float Matrix00 { get; set; }
		[XmlIgnore] public float Matrix01 { get; set; }
		[XmlIgnore] public float Matrix02 { get; set; }
		[XmlIgnore] public float Matrix03 { get; set; }
		[XmlIgnore] public float Matrix04 { get; set; }
		//
		[XmlIgnore] public float Matrix10 { get; set; }
		/// <summary>Green Factor</summary>
		[XmlIgnore] public float Matrix11 { get; set; }
		[XmlIgnore] public float Matrix12 { get; set; }
		[XmlIgnore] public float Matrix13 { get; set; }
		[XmlIgnore] public float Matrix14 { get; set; }
		//
		[XmlIgnore] public float Matrix20 { get; set; }
		[XmlIgnore] public float Matrix21 { get; set; }
		/// <summary>Blue Factor</summary>
		[XmlIgnore] public float Matrix22 { get; set; }
		[XmlIgnore] public float Matrix23 { get; set; }
		[XmlIgnore] public float Matrix24 { get; set; }
		//
		[XmlIgnore] public float Matrix30 { get; set; }
		[XmlIgnore] public float Matrix31 { get; set; }
		[XmlIgnore] public float Matrix32 { get; set; }
		/// <summary>Alpha Factor</summary>
		[XmlIgnore] public float Matrix33 { get; set; }
		[XmlIgnore] public float Matrix34 { get; set; }
		//
		[XmlIgnore] public float Matrix40 { get; set; }
		[XmlIgnore] public float Matrix41 { get; set; }
		[XmlIgnore] public float Matrix42 { get; set; }
		[XmlIgnore] public float Matrix43 { get; set; }
		/// <summary>Z Factor</summary>
		[XmlIgnore] public float Matrix44 { get; set; }
		#endregion
		
		#region Psudo-Property (Value)
		//
		[XmlIgnore] public float[][] Value {
			get
			{
				return new float[][]
				{
					new float[]{ Matrix00,Matrix01,Matrix02,Matrix03,Matrix04 },
					new float[]{ Matrix10,Matrix11,Matrix12,Matrix13,Matrix14 },
					new float[]{ Matrix20,Matrix21,Matrix22,Matrix23,Matrix24 },
					new float[]{ Matrix30,Matrix31,Matrix32,Matrix33,Matrix34 },
					new float[]{ Matrix40,Matrix41,Matrix42,Matrix43,Matrix44 },
				};
			}
			set { this.SetMatrix(value); }
		}
		
		[XmlAttribute("Value")]
		public string Identity {
			get {
				return string.Format(
					"{0}f,{1}f,{2}f,{3}f,{4}f, " +
					"{5}f,{6}f,{7}f,{8}f,{9}f, " +
					"{10}f,{11}f,{12}f,{13}f,{14}f, " +
					"{15}f,{16}f,{17}f,{18}f,{19}f, " +
					"{20}f,{21}f,{22}f,{23}f,{24}f",
					Matrix00, Matrix01, Matrix02, Matrix03, Matrix04,
					Matrix10, Matrix11, Matrix12, Matrix13, Matrix14,
					Matrix20, Matrix21, Matrix22, Matrix23, Matrix24,
					Matrix30, Matrix31, Matrix32, Matrix33, Matrix34,
					Matrix40, Matrix41, Matrix42, Matrix43, Matrix44
				);
			}
			set
			{
				string nv = value/*.Replace("f","")*/;
				string[] values = nv.Split(',');
				float[]     aid = new float[25];
				for (int i = 0, j = 0; i < 25; i++, j++)
				{
					aid[i] = Convert.ToSingle(values[i].Trim(' ','f'));
					j = j == 5 ? 0 : j;
				}
				SetMatrix(aid);
				aid = null;
				values = null;
			}
		}
		#endregion
	}
}
