using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
    class XMap_Content
    {
       private string _xmlns;
       private string _xmlns_fo;
       private string _xmlns_svg;
       private string _xmlns_xhtml;
       private string _xmlns_xlink;
       private string _modified_by;
       private string _version;
       private long _timestamp = 0;


       public XMap_Content()
       {
          _sheet = new List<Sheet>();
       }

        private List<Sheet> _sheet;

        public void AddSheet(Sheet Ref)
        {
            _sheet.Add(Ref);
        }

        public void RemoveSheet(Sheet Ref)
        {
            _sheet.Remove(Ref);
        }

        public List<Sheet> SheetList
        {
            get
            {
                return _sheet;
            }
            set
            {
                _sheet = value;
            }
        }

        public string Xmlns
        {
           get
           {
              return _xmlns;
           }
           set
           {
              _xmlns = value;
           }
        }

        public string Xmlns_Fo
        {
           get
           {
              return _xmlns_fo;
           }
           set
           {
              _xmlns_fo = value;
           }
        }

        public string Xmlns_Svg
        {
           get
           {
              return _xmlns_svg;
           }
           set
           {
              _xmlns_svg = value;
           }
        }

        public string Xmlns_Xhtml
        {
           get
           {
              return _xmlns_xhtml;
           }
           set
           {
              _xmlns_xhtml = value;
           }
        }

        public string Xmlns_Xlink
        {
           get
           {
              return _xmlns_xlink;
           }
           set
           {
              _xmlns_xlink = value;
           }
        }

        public string Modified_By
        {
           get
           {
              return _modified_by;
           }
           set
           {
              _modified_by = value;
           }
        }

        public string Version
        {
           get
           {
              return _version;
           }
           set
           {
              _version = value;
           }
        }

        public long Timestamp
        {
           get
           {
              return _timestamp;
           }
           set
           {
              _timestamp = value;
           }
        }


        public static XMap_Content ParseXmlNode(XElement Node)
        {
            XMap_Content t = new XMap_Content();

            IEnumerable<XAttribute> attrCol = Node.Attributes();
            foreach (XAttribute item in attrCol)
            {
               switch (item.Name.LocalName)
               {
                  case Constants.XMLNS:
                     t.Xmlns = item.Value;
                     break;
                  case Constants.XMLNS_FO:
                     t.Xmlns_Fo = item.Value;
                     break;
                  case Constants.XMLNS_SVG:
                     t.Xmlns_Svg = item.Value;
                     break;
                  case Constants.XMLNS_XHTML:
                     t.Xmlns_Xhtml = item.Value;
                     break;
                  case Constants.XMLNS_XLINK:
                     t.Xmlns_Xlink = item.Value;
                     break;
                  case Constants.MODIFIED_BY:
                     t.Modified_By = item.Value;
                     break;
                  case Constants.TIMESTAMP:
                     t.Timestamp = long.Parse(item.Value);
                     break;
                  case Constants.VERSION:
                     t.Version = item.Value;
                     break;
                  default:
                     break;
               }
            }


            IEnumerable<XElement> nodeliste = Node.Elements();
            foreach (XElement item in nodeliste)
            {
                switch (item.Name.LocalName)
                {
                    case Constants.SHEET:
                        t.AddSheet(Sheet.ParseXmlNode(item));
                        break;
                    default:
                        break;
                }
            }
            return t;
        }

        public static XElement CreateXmlNode(XNamespace Ns, XMap_Content S)
        {
           XElement el = new XElement(Ns + Constants.XMAP_CONTENT);

           el.Add(new XAttribute(Constants.XMLNS, S.Xmlns));

           el.Add(new XAttribute(Constants.XMLNS_FO, S.Xmlns_Fo));
           el.Add(new XAttribute(Constants.XMLNS_SVG, S.Xmlns_Svg));
           el.Add(new XAttribute(Constants.XMLNS_XHTML, S.Xmlns_Xhtml));
           el.Add(new XAttribute(Constants.XMLNS_XLINK, S.Xmlns_Xlink));

           if (!String.IsNullOrEmpty(S.Modified_By))
              el.Add(new XAttribute(Constants.MODIFIED_BY, S.Modified_By));
           if(S.Timestamp == 0)
               el.Add(new XAttribute(Constants.TIMESTAMP, Util.GetEpoch()));
           else
              el.Add(new XAttribute(Constants.TIMESTAMP, S.Timestamp));

           el.Add(new XAttribute(Constants.VERSION, S.Version));

           foreach (Sheet item in S.SheetList)
           {
              el.Add(Sheet.CreateXmlNode(Ns, item));
           }

           return el;
        }
    }
}
