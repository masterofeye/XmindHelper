using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class MarkerRefs
   {
       public MarkerRefs()
       {
           _markrefs = new List<MarkerRef>();
       }


      private List<MarkerRef> _markrefs;

      public List<MarkerRef> MarkerRefsList
      {
         get
         {
            return _markrefs;
         }
         set
         {
            _markrefs = value;
         }
      }

      public void AddMarkRef(MarkerRef Ref)
      {
          MarkerRefsList.Add(Ref);
      }

      public void RemoveMarkRef(MarkerRef Ref)
      {
          MarkerRefsList.Remove(Ref);
      }

      public static MarkerRefs ParseXmlNode(XElement Node)
      {
          MarkerRefs marker = new MarkerRefs();

          IEnumerable<XElement> nodeliste = Node.Elements();
          foreach (XElement item in nodeliste)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.MARKER_REF:
                      marker.AddMarkRef(MarkerRef.ParseXmlNode(item));
                      break;
                  default:
                      break;
              }
          }
          return marker;
      }

      public static XElement CreateXmlNode(XNamespace Ns, MarkerRefs R)
      {
         XElement el = new XElement(Constants.MARKER_REFS);

         foreach (MarkerRef item in R.MarkerRefsList)
         {
            el.Add(MarkerRef.CreateXmlNode(Ns, item));
         }

         return el;
      }
   }
}
