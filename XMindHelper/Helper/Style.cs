using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Style
   {
      public Style()
      {
         _id = Util.Generate_ID();
      }

      private String _id;
      private String _name;
      private String _type;

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

      public String Name
      {
         get
         {
            return _name;
         }
         set
         {
            _name = value;
         }
      }

      public String Type
      {
         get
         {
            return _type;
         }
         set
         {
            _type = value;
         }
      }

      public static Style ParseXmlNode(XElement Node)
      {
         Style s = new Style();
         IEnumerable<XAttribute> attrCol = Node.Attributes();
         foreach (XAttribute item in attrCol)
         {
            switch (item.Name.LocalName)
            {
               case Constants.ID:
                  s.ID = item.Value;
                  break;
               case Constants.NAME:
                  s.Name = item.Value;
                  break;
               case Constants.TYPE:
                  s.Type = item.Value;
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
               case Constants.TITLE:
                  t.Title = Title.ParseXmlNode(item);
                  break;
               case Constants.MARKER_REFS:
                  t.MarkerRefs = MarkerRefs.ParseXmlNode(item);
                  break;
               case Constants.LABELS:
                  t.Labels = Labels.ParseXmlNode(item);
                  break;
               case Constants.CHILDREND:
                  t.Children = Children.ParseXmlNode(item);
                  break;
               case Constants.BOUNDARIES:
                  t.Boundaries = Boundaries.ParseXmlNode(item);
                  break;
               default:
                  break;
            }
         }
         return t;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Title T)
      {
         XElement el = new XElement(Ns + Constants.TITLE, T.TitleString);

         //if(!String.IsNullOrEmpty(T.Svg_Width.ToString()))
         //   el.Add(new XAttribute(Constants.SVG_WIDTH, T.Svg_Width));

         return el;
      }
   }
}
