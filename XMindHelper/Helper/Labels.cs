using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Labels
   {
       public Labels()
       {
           _labels = new List<Label>();
       }

      private List<Label> _labels;

      public List<Label> LabelsList
      {
         get
         {
            return _labels;
         }
         set
         {
            _labels = value;
         }
      }

      public void AddLabel(Label Ref)
      {
         _labels.Add(Ref);
      }

      public void RemoveLabel(Label Ref)
      {
         _labels.Remove(Ref);
      }

      public static Labels ParseXmlNode(XElement Node)
      {
          Labels l = new Labels();

          IEnumerable<XElement> nodeliste = Node.Elements();
          foreach (XElement item in nodeliste)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.MARKER_REF:
                      l.AddLabel(Label.ParseXmlNode(item));
                      break;
                  default:
                      break;
              }
          }
          return l;
      }
   }
}
