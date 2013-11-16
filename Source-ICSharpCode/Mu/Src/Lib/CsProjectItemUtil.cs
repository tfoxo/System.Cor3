using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ICSharpCode.SharpDevelop.Project;

namespace Mu
{

    class CsProjectItemUtil
    {
        static CsProjectItemSettings Settings { get;set; }
        static public readonly ItemType[] DefaultTypes = new ItemType[]{ ItemType.Compile, };
        
        static readonly ItemType[] CommonTypes = {
            ItemType.Compile,
            ItemType.Content,
            ItemType.EmbeddedResource,
            ItemType.None,
            ItemType.Page,
            ItemType.Resource};
        
        public CsProjectItemUtil(CsProjectItemSettings settings)
        {
            Settings = settings;
        }
        
//        string GetAttributeString(ProjectItem p)
//        {
//            List<string> keyn = new List<string>();
//            foreach (string n in p.MetadataNames)
//            {
//                string v = p.GetMetadata(n);
//                if (!string.IsNullOrEmpty(v) && !string.IsNullOrEmpty(p.GetMetadata(n)))
//                    keyn.Add(string.Format( Strings.FormatTag0, n, p.GetMetadata(n) ));
//            }
//            return string.Join(" ",keyn.ToArray());
//        }

        /// <summary>
        /// Generates a list of includes from a given project.
        /// </summary>
        /// <param name="fnamePre">Default = 'include'</param>
        /// <returns>XmlFragment as string.</returns>
        public string SerializeLinks()
        {
            var xlm = SerializeLinks(CommonTypes);
            string outt = string.Join("",xlm.ToArray());
            xlm = null;
            return outt;
        }
        
        List<string> SerializeLinks(params ItemType[] types)
        {
            if (!Settings.HasProject) return null;
            List<ItemType> listtypes = new List<ItemType>(types);
            List<string> itemset = new List<string>();
            string text = string.Empty;
            
            foreach ( ProjectItem p in Settings.Project.Items )
            {
                
                if (!listtypes.Contains(p.ItemType)) continue;
                
                CsProjectItemInfo info = new CsProjectItemInfo(Settings.Project,p);
                
                if (info.HasLink && !Settings.IncludeLinks) continue;
                
                string temp = ReformatCommon(info,Strings.CompileElement2);
                
                info = null;
                itemset.Add(temp);
                
            }
            listtypes = null;
            return itemset;
        }
    
        /// <summary>
        /// Reformats {tag}, {inc} and {fname}
        /// </summary>
        /// <param name="info">Contains Project, and ProjectItem FileInfo.</param>
        /// <param name="template">template</param>
        /// <param name="vals">a set of attribute values to be placed into the tag.</param>
        /// <returns></returns>
        string ReformatCommon(CsProjectItemInfo info, string template)
        {
            return template
                .Replace("{vals}",info.MetaInfoAsAttributes)
                .Replace("{tag}",info.Item.ItemType.ItemName)
//                        .Replace("{inc}",p.Include)
                .Replace("{inc}",info.ProjectInclude.FullName
                    .Replace(info.Project.Directory,string.Empty)  .Trim('\\','/') )
//                        .Replace("{fname}",p.FileName)
                .Replace("{fname:pre}",Settings.PreIncludePath)
                .Replace("{fname}",info.Item.Include)
//                        .Replace("{fname}",fn0.Name)
                ;
        }
        
        /// <summary>
        /// This method is used for my first successful tool.
        /// <para>List all files in the project contained within ProjectService.CurrentProject.Items.</para>
        /// </summary>
        /// <returns></returns>
        List<string> GetProjectFileInfo()
        {
            List<string> files = new List<string>();
            files.Add(string.Format("{0}",Settings.Project.FileName));
            if (!string.IsNullOrEmpty(Settings.Project.FileName))  // OpenSolution is null when no solution is opened
            {
                files.Add("Files:");
                foreach (ProjectItem p in Settings.Project.Items/*.Where(itm=>itm.ItemType==ItemType.Compile)*/) {
                    files.Add(string.Format("    {1} ( {0} )",string.Join(", ",p.MetadataNames.ToArray()),p.FileName));
                }
            }
            else files.Add("Error loading files.");
            
            return files;
        }
//        string CleanProject(this string input)
//        {
//            FileInfo pj = new FileInfo(Settings.Project.FileName);
//            return input.Replace(pj.Directory.FullName,"");
//        }
        
    }
}
