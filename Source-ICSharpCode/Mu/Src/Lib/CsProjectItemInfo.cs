using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ICSharpCode.SharpDevelop.Project;

namespace Mu
{
	class CsProjectItemInfo
	{
		public FileInfo    ProjectFileName { get; set; }
		public FileInfo    ProjectFile { get; set; }
		public FileInfo    ProjectInclude { get; set; }
		public IProject    Project { get;set; }
		public ProjectItem Item { get;set; }
		public bool        HasLink { get; private set; }
		public string      MetaInfoAsAttributes { get { return GetAttributeString(Item); } }
		
		public IDictionary<string,string> Meta { get; private set; }
		
		public CsProjectItemInfo(IProject proj, ProjectItem p)
		{
			Project              = proj;
			Item                 = p;
			ProjectFileName      = new FileInfo(proj.FileName);
			string localfile     = Path.Combine(ProjectFileName.Directory.FullName,p.FileName);
			ProjectFile          = new FileInfo(localfile);
			string includefile   = Path.Combine(ProjectFileName.Directory.FullName,p.Include);
			ProjectInclude       = new FileInfo(includefile);
			Meta                 = GetMetaDictionary(Item);
		}
		
		Dictionary<string,string> GetMetaDictionary(ProjectItem p)
		{
			Dictionary<string,string> d = new Dictionary<string,string>();
			foreach (string n in p.MetadataNames)
			{
				string v = p.GetMetadata(n);
				if (n.ToLower()=="link") HasLink=true;
				if (!string.IsNullOrEmpty(n) && !string.IsNullOrEmpty(v))
					d.Add( n, v );
			}
			return d;
		}
		List<string> GetAttributeList(ProjectItem p)
		{
			List<string> keyn = new List<string>();
			foreach (string n in p.MetadataNames)
			{
				string v = p.GetMetadata(n);
				if (!string.IsNullOrEmpty(v) && !string.IsNullOrEmpty(p.GetMetadata(n)))
					keyn.Add(string.Format( Strings.FormatTag0, n, p.GetMetadata(n) ));
			}
			return keyn;
		}
		List<string> GetAttributeList()
		{
			return GetAttributeList(Item);
		}
		
		string GetAttributeString(ProjectItem p)
		{
			string vals = string.Join(" ",GetAttributeList(p).ToArray());
			if (!string.IsNullOrEmpty(vals)) vals = " " + vals;
			return vals;
		}

	}
}
