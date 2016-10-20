using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
    class Sheet
    {
        private String _id;
        private long _timestamp = 0;
        private String _modified_by;
        private String _theme;
        private Topic _topic;

        public String ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
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

        public String Modified_By
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

        public String Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
            }
        }

        public Topic Topic
        {
            get
            {
                return _topic;
            }
            set
            {
                _topic = value;
            }
        }

        public static Sheet ParseXmlNode(XElement Node)
        {
            Sheet s = new Sheet();
            IEnumerable<XAttribute> attrCol = Node.Attributes();
            foreach (XAttribute item in attrCol)
            {
                switch (item.Name.LocalName)
                {
                    case Constants.ID:
                        s.ID = item.Value;
                        break;
                    case Constants.TIMESTAMP:
                        s.Timestamp = long.Parse(item.Value);
                        break;
                    case Constants.MODIFIED_BY:
                        s.Modified_By = item.Value;
                        break;
                    case Constants.THEME:
                        s.Theme = item.Value;
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
                    case Constants.TOPIC:
                        s.Topic = Topic.ParseXmlNode(item);
                        break;
                    default:
                        break;
                }
            }

            return s;
        }

        public static XElement CreateXmlNode(XNamespace Ns, Sheet S)
        {
           XElement el = new XElement(Ns + Constants.SHEET);

           if (!String.IsNullOrEmpty(S.ID))
              el.Add(new XAttribute(Constants.ID, S.ID));
           else
              el.Add(new XAttribute(Constants.ID, Util.Generate_ID()));

           el.Add(new XAttribute(Constants.THEME, S.Theme));

           if (S.Timestamp == 0)
              el.Add(new XAttribute(Constants.TIMESTAMP, Util.GetEpoch()));
           else
              el.Add(new XAttribute(Constants.TIMESTAMP, S.Timestamp));

           el.Add(Topic.CreateXmlNode(Ns,S.Topic));

           return el;
        }
    }
}
