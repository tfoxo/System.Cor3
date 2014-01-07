using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
// from:
// http://www.codeproject.com/Articles/9494/Manipulate-XML-data-with-XPath-and-XmlDocument-C
// ...
// To update a node, first I search out which node you are updating by
// SelectSingleNode, and then create a new node element.
// After setting the InnerXml of the new node, call ReplaceChild
// method of XmlElement to update the document.
namespace FeedTool
{
    /// <summary>
    /// Read information from Podcasts, Rss and YouTube feed.
    /// </summary>
    public class XmlInfo
    {
        #region XmlDoc:FileInfo, Load(FileInfo)
        public FileInfo XmlDoc
        {
            get;
            set;
        }
        /**
         * We currently are using web-content as primary, however
         * we are going to end up caching the results into a database,
         * or from a given file.
         * -------
         * If loading from a database (sqlite) this option remains obsolete
         */
        public void Load(FileInfo fileInfo)
        {
            LoadFile(fileInfo.FullName);
        }
        #endregion
        
        public bool HasError { get;set; }
        
        public List<NodeInfo> Nodes = new List<NodeInfo>();
        /// <summary>
        /// namespaces are added as lower case versions of found ns.
        /// The default namespace as added to the actual XmlDocument referenced
        /// are as they are found.  Additionally "xmlroot" is provided to the
        /// mentioned document in place of the root or empty xmlns.
        /// When Root xmlns is added to the Namespace dictionary, we use a
        /// empty string.
        /// </summary>
        public Dictionary<string,string> Namespaces = new Dictionary<string, string>();
        
        #region Properties: Xml Document Information
        public XmlDocument Doc = new XmlDocument();
        public XmlNode DocRoot;
        public XmlNamespaceManager DocNs;
        /// <summary>
        /// The name of the Root Node Element.  EG: 'feed' or 'rss'.
        /// </summary>
        public string RootType
        {
            get;
            private set;
        }
        #endregion
        
        public void LoadFile(string filename)
        {
            Nodes.Clear();
            try {
                Doc.Load(filename);
                HasError = false;
            } catch {
                HasError = true;
            }
            System.Diagnostics.Debug.Print("XML Loaded = {0}",!HasError);
            if (!HasError) Load();
        }
        public void Load(string xmlContent)
        {
            Nodes.Clear();
            try {
                Doc.LoadXml(xmlContent);
                HasError = false;
            } catch {
                HasError = true;
            }
//            System.Diagnostics.Debug.Print("XML Loaded = {0}",!HasError);
            if (!HasError) Load();
        }
        
        /// <summary>
        /// Requires that the XmlDocument (Doc) is set and loaded.
        /// </summary>
        /// <remarks>
        /// It matters not that this method blocks.
        /// </remarks>
        public void Load()
        {
            DocNs = new XmlNamespaceManager(Doc.NameTable);
            DocRoot = Doc.DocumentElement;
            /**
             * Collect namespace info from the document.
             */
            foreach (XmlAttribute node in DocRoot.Attributes) {
                if (!node.Name.Contains("xmlns")) continue;
                string name = node.Name
                    .Replace("xmlns:","")
                    .Replace("xmlns","")
                    ;
                Namespaces.Add(name,node.Value.ToLower());
                DocNs.AddNamespace(name==""?"xmlroot":name,node.Value);
            }
            RootType = DocRoot.Name;
        }
        
        /// <summary>
        /// This method is used to check the type of document we are
        /// navigating, such as to provide a icon to a user interface
        /// which identifies the type of feed we are viewing.
        /// </summary>
        /// <param name="nsUri"></param>
        /// <returns></returns>
        public bool HasNSValue(string value)
        {
            foreach (KeyValuePair<string,string> key in Namespaces)
                if (key.Value.ToLower()==value.ToLower()) return true;
            return false;
        }
        /// <summary>
        /// This method is used to check the type of document we are
        /// navigating, such as to provide a icon to a user interface
        /// which identifies the type of feed we are viewing.
        /// </summary>
        /// <param name="nsUri"></param>
        /// <returns></returns>
        public bool HasNSKey(string attr)
        {
            foreach (KeyValuePair<string,string> key in Namespaces)
                if (key.Key.ToLower()==attr.ToLower()) return true;
            return false;
        }
        
    }
}