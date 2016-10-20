using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Boundary
   {
      public Boundary() { }
      public Boundary(String ID, String Range) { _id = ID;  _range = Range; }


      private String _id;
      private long _timestamp = 0;
      private String _modified_by;
      private String _range;

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

      public String Range
      {
         get
         {
            return _range;
         }
         set
         {
            _range = value;
         }
      }

      public static Boundary ParseXmlNode(XElement Node)
      {
         Boundary b = new Boundary();
         IEnumerable<XAttribute> attrCol = Node.Attributes();
         foreach (XAttribute item in attrCol)
         {
            switch (item.Name.LocalName)
            {
               case Constants.ID:
                  b.ID = item.Value;
                  break;
               case Constants.MODIFIED_BY:
                  b.Modified_By = item.Value;
                  break;
               case Constants.RANGE:
                  b.Range = item.Value;
                  break;
               case Constants.TIMESTAMP:
                  b.Timestamp = long.Parse(item.Value);
                  break;
               default:
                  break;
            }
         }
         return b;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Boundary T)
      {
         XElement el = new XElement(Constants.BOUNDARY);

         if (!String.IsNullOrEmpty(T.ID))
            el.Add(new XAttribute(Constants.ID, T.ID));
         else
            el.Add(new XAttribute(Constants.ID, Util.Generate_ID()));

         if (!String.IsNullOrEmpty(T.Modified_By))
            el.Add(new XAttribute(Constants.MODIFIED_BY,T.Modified_By));

         if (!String.IsNullOrEmpty(T.Range))
            el.Add(new XAttribute(Constants.RANGE, T.Range));

         if (T.Timestamp == 0)
            el.Add(new XAttribute(Constants.TIMESTAMP, Util.GetEpoch()));
         else
            el.Add(new XAttribute(Constants.TIMESTAMP, T.Timestamp));



         return el;
      }
   }
}
