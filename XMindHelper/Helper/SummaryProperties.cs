using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class SummaryProperties : Properties
   {
      public static SummaryProperties ParseXmlNode(XElement Node)
      {
         SummaryProperties prop = new SummaryProperties();
         IEnumerable<XAttribute> attrCol = Node.Attributes();
         foreach (XAttribute item in attrCol)
         {
            switch (item.Name.LocalName)
            {
               case Constants.ID:
                  prop.ID = item.Value;
                  break;
               case Constants.TIMESTAMP:
                  prop.Timestamp = long.Parse(item.Value);
                  break;
               case Constants.BRANCH:
                  prop.Branch = item.Value;
                  break;
               case Constants.MODIFIED_BY:
                  prop.Modified_By = item.Value;
                  break;
               case Constants.STYLE_ID:
                  propt.Style = item.Value;
                  break;
               case Constants.XLINK:
                  prop.XLink = item.Value;
                  break;
               case Constants.STRUCTURE_CLASS:
                  prop.Structure_Class = item.Value;
                  break;
               default:
                  break;
            }
         }
         return prop;
      }
   }
}
