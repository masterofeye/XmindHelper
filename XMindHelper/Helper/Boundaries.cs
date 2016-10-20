using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Boundaries
   {
      public Boundaries()
      {
         _boundaries = new List<Boundary>();
      }
      private List<Boundary> _boundaries;

      public List<Boundary> BoundaryList
      {
         get
         {
            return _boundaries;
         }
         set
         {
            _boundaries = value;
         }
      }
      public void AddBoundary(Boundary Ref)
      {
         BoundaryList.Add(Ref);
      }

      public void RemoveBoundary(Boundary Ref)
      {
         BoundaryList.Remove(Ref);
      }

      public static Boundaries ParseXmlNode(XElement Node)
      {
         Boundaries b = new Boundaries();

         IEnumerable<XElement> nodeliste = Node.Elements();
         foreach (XElement item in nodeliste)
         {
            switch (item.Name.LocalName)
            {
               case Constants.BOUNDARY:
                  b.AddBoundary(Boundary.ParseXmlNode(item));
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
