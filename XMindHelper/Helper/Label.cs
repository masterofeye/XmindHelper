using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Label
   {
      

      private String _label;

      public String LableString
      {
         get
         {
            return _label;
         }
         set
         {
            _label = value;
         }
      }

      public static Label ParseXmlNode(XElement Node)
      {
          Label l = new Label();
          l.LableString = Node.Value;
          return l;
      }
   }
}
