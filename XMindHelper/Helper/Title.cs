using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Title
   {
      public Title()
      {}

      public Title(String Title)
      { 
         _title = Title;
      }


      private String _title;
      private int _svg_width = 0;

      public String TitleString
      {
         get
         {
            return _title;
         }
         set
         {
            _title = value;
         }
      }

      public int Svg_Width
      {
         get
         {
            return _svg_width;
         }
         set
         {
            _svg_width = value;
         }
      }

      public static Title ParseXmlNode(XElement Node)
      {
          Title t = new Title();
          t.TitleString = Node.Value;
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
