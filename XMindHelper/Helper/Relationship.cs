using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Relationship
   {
      private String _end1;
      private String _end2;
      private String _id;
      private long _timestamp;

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

      public String End1
      {
         get
         {
            return _end1;
         }
         set
         {
            _end1 = value;
         }
      }

      public String End2
      {
         get
         {
            return _end2;
         }
         set
         {
            _end2 = value;
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

      public static Relationship ParseXmlNode(XElement Node)
      {
         Relationship r = new Relationship();
         IEnumerable<XAttribute> attrCol = Node.Attributes();
         foreach (XAttribute item in attrCol)
         {
            switch (item.Name.LocalName)
            {
               case Constants.ID:
                  r.ID = item.Value;
                  break;
               case Constants.END1:
                  r.End1 = item.Value;
                  break;
               case Constants.END2:
                  r.End2 = item.Value;
                  break;
               case Constants.TIMESTAMP:
                  r.Timestamp = long.Parse(item.Value);
                  break;
               default:
                  break;
            }
         }
         return r;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Relationship R)
      {
         XElement el = new XElement(Ns + Constants.RELATIONSHIP);

         el.Add(new XAttribute(Constants.END1, R.End1));
         el.Add(new XAttribute(Constants.END2, R.End2));
         el.Add(new XAttribute(Constants.ID, R.ID));
         el.Add(new XAttribute(Constants.TIMESTAMP, R.Timestamp));

         return el;
      }
   }
}
