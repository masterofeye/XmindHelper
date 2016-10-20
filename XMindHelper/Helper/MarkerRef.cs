using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class MarkerRef
   {
      public MarkerRef() { }
      public MarkerRef(String MarkerID) { _marker_id = MarkerID; }


      private String _marker_id;

      public String Marker_Id
      {
         get
         {
            return _marker_id;
         }
         set
         {
            _marker_id = value;
         }
      }

      public static MarkerRef ParseXmlNode(XElement Node)
      {
          MarkerRef marker = new MarkerRef();
          IEnumerable<XAttribute> attrCol = Node.Attributes();
          foreach (XAttribute item in attrCol)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.MARKER_ID:
                      marker.Marker_Id= item.Value;
                      break;

                  default:
                      break;
              }
          }
          return marker;
      }

      public static XElement CreateXmlNode(XNamespace Ns, MarkerRef T)
      {
         XElement el = new XElement(Constants.MARKER_REF);

         if (!String.IsNullOrEmpty(T.Marker_Id.ToString()))
            el.Add(new XAttribute(Constants.MARKER_ID, T.Marker_Id));

         return el;
      }
   }
}
