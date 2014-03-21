using System;
using System.ComponentModel;
using Generator;
using Generator.Export;

namespace Generator.Parser
{
	public class GeneratorParser : BackgroundWorker
	{
		public string ParserResult { get;set; }
		public IDbConfiguration4 Configuration { get;set; }
		public Action<string> ResultAction { get;set; }
		
		public void Prepare(IDbConfiguration4 configuration)
		{
			Configuration = configuration;
		}
		
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			base.OnDoWork(e);
			ParserResult = TemplateFactory.ConvertTable(Configuration);
		}
		
		protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
		{
			base.OnRunWorkerCompleted(e);
			if (ResultAction!=null) ResultAction.Invoke(ParserResult);
			this.Configuration = null;
			this.ParserResult = null;
			GC.Collect();
		}
		
	}
}
