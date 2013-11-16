using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ICSharpCode.SharpDevelop.Project;

namespace Mu
{
	class CsProjectItemSettings
	{
		
		public IProject Project { get;set; }
		
		public bool HasProject { get { return Project != null; } }
		
		public string ProjectPath { get;set; }
		
		public string PreIncludePath { get;set; }
		
		public bool IncludeLinks { get;set; }
		
	}
}
