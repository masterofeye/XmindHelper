using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class AutomaticStyles
   {
      public AutomaticStyles()
      {
         _automaticStyles = new List<Style>();
      }
      private List<Style> _automaticStyles;

      public List<Style> AutomaticStylesList
      {
         get
         {
            return _automaticStyles;
         }
         set
         {
            _automaticStyles = value;
         }
      }
      public void AddStyle(Style Ref)
      {
         AutomaticStylesList.Add(Ref);
      }

      public void RemoveStyle(Style Ref)
      {
         AutomaticStylesList.Remove(Ref);
      }

      public static AutomaticStyles ParseXmlNode(XElement Node)
      {
         AutomaticStyles b = new AutomaticStyles();

         IEnumerable<XElement> nodeliste = Node.Elements();
         foreach (XElement item in nodeliste)
         {
            switch (item.Name.LocalName)
            {
               case Constants.STYLE:
                  b.AddStyle(Style.ParseXmlNode(item));
                  break;
               default:
                  break;
            }
         }
         return b;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Boundaries R)
      {
         XElement el = new XElement(Constants.BOUNDARIES);

         foreach (Boundary item in R.BoundaryList)
         {
            el.Add(Boundary.CreateXmlNode(Ns, item));
         }

         return el;
      }
   }
}
