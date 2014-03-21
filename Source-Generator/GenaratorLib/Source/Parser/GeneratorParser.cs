using System;

namespace Generator.Core.Parser
{
	public class GeneratorParser : System.ComponentModel.BackgroundWorker
	{
		public string ParserResult { get;set; }
		public IDbConfiguration4 Configuration { get;set; }
		public Action<string> ResultAction { get;set; }
		
		public void Prepare(IDbConfiguration4 configuration)
		{
			Configuration = configuration;
		}
		
		protected override void OnDoWork(System.ComponentModel.DoWorkEventArgs e)
		{
			base.OnDoWork(e);
			ParserResult = TemplateFactory.ConvertTable(Configuration);
		}
		
		protected override void OnRunWorkerCompleted(System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			base.OnRunWorkerCompleted(e);
			if (ResultAction!=null) ResultAction.Invoke(ParserResult);
			this.Configuration = null;
			this.ParserResult = null;
			GC.Collect();
		}
		
		protected override void OnProgressChanged(System.ComponentModel.ProgressChangedEventArgs e)
		{
			base.OnProgressChanged(e);
		}
		
	}
}
