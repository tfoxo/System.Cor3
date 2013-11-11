using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace FeedTool
{
    /// <summary>
    /// represents a podcast feed (in most cases).
    /// </summary>
    public class AtomEntry : NodeInfo
    {
        #region Dictionary Infos

        internal override Dictionary<string, string> Infos
        {
            get {
                return infos;
            }
        } Dictionary<string,string> infos = Resource.Dic_AtomFeed.ToStringDictionary('\n','|',new char[] {'#','['},new char[] {'\r','\n','\t'});
        #endregion

        #region Content Dictionary

        List<AtomEntry> contentEntries = new List<AtomEntry>();

        public List<AtomEntry> ContentEntries
        {
            get { return contentEntries; }
        }

        #endregion

        #region Properties

        public override string HtmlText
        {
            get {

                #region LinkTest
                
                string linkTest = string.Empty;
                
                List<string> list = new List<string>();
                list.Add(string.Format("Url: {0}, Type: {1}, Format: {2}",LinkHref,LinkType,LinkRel));
                linkTest = string.Join("<br />",list.ToArray());
                list.Clear();
                
                #endregion
                #region VideoTest
                
//                string vidTest = string.Empty;
//                
//                int cid = 0;
//                // this makes no sense
//                foreach (AtomEntry atom in ContentEntries) {
//                    list.Add(
//                        string.Format(
//                            @"<a href=""{0}"" title=""Type: {1}, Format: {2}"">item</a> {4}",
//                            atom.LinkHref,
//                            atom.LinkType,
//                            atom.LinkRel,
//                            ++cid,
//                            atom.LinkRel
//                        )
//                    );
//                }
//                
//                vidTest = string.Join("<br />",list.ToArray())+"<hr />";
                #endregion
                
                return Resource
					.Html_Master
					.Replace("@{style}",Resource.html_css)
					.Replace("@{content}",Resource.Html_YouTube_Template)

                    //.Replace("@{links}",vidTest)
                    // link-alt-href
                    //.Replace("@{entry-link-href}",HtmlLinks["entry-link-href"])

                    .Replace("@{link}",LinkHref)
                    .Replace("@{title}",Title)
                    .Replace("@{description}",Description)
                    .Replace("@{date}",Updated)
//                    .Replace("@{img}",this.Image)
                    ;
            }
        }

        public override string Name { get { return FeedTitle; } }

        // Root elements?
        public string FeedTitle      { get ; set ; }
        public string FeedRights     { get ; set ; }
        public string FeedIcon       { get ; set ; }
        public string FeedLogo       { get ; set ; }
        public string FeedSubtitle   { get ; set ; }
        public string FeedLinkRel    { get ; set ; }
        public string FeedLinkType   { get ; set ; }
        public string FeedLinkHref   { get ; set ; }
        public string AuthorName     { get ; set ; }
        public string AuthorEmail    { get ; set ; }
        public string AuthorUri      { get ; set ; }
        // Atom-Entry
        public string Id             { get; set; }
        public string Title          { get; set; }
        public string LinkType       { get; set; }
        public string LinkRel        { get; set; }
        public string LinkHref       { get; set; }
        public string Summary        { get; set; }
        /// <summary>
        /// This is never used.
        /// </summary>
        public override string Description { get { return Summary; } set { Summary = value; } }

        public DateTime? DateUpdated { get; set; }
        string OrigUpdated           { get; set; }
        public string Updated        { get; set; }
        
        #endregion

        /// <summary>
        /// Title, Comments, Description, Date
        /// </summary>
        /// <param name="doc"></param>
        public override void Parse(XmlDocument doc, XmlNamespaceManager man)
        {
            var node =       GetNode(doc,man,"entry-id");
            Id =             node.InnerText;
            LinkHref =       TryGetText(doc,man,ref node,"entry-link-href");
            LinkType =       TryGetText(doc,man,ref node,"entry-link-type");
            LinkRel =        TryGetText(doc,man,ref node,"entry-link-rel");
            Summary =        TryGetText(doc,man,ref node,"entry-link-summary");
            Title =          TryGetText(doc,man,ref node,"entry-title");
            //
            OrigUpdated =    TryGetText(doc, man, ref node, "entry-updated");
            DateUpdated =    CheckDate(OrigUpdated);
            Updated =        DateUpdated.HasValue ? DateUpdated.Value.ToString(dateFmt) : OrigUpdated;
        }

        public override void GenerateLinks()
        {
            HtmlLinks.Clear();
            if (!string.IsNullOrEmpty(LinkHref)) {
                // @"<a title=""{0}"" href=""{1}""{2}>{3}</a>";
                HtmlLinks.Add("link",string.Format(linkFormat,LinkHref,LinkHref,string.Empty,"link"));
                HtmlLinks.Add("link-break","<br />");
            } else {
                HtmlLinks.Add("link",string.Empty);
                HtmlLinks.Add("link-break",string.Empty);
            }
        }

    }
}
