using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Relationships
   {
      private List<Relationship> _relationships;

      public List<Relationship> RelationshipList
      {
         get
         {
            return _relationships;
         }
         set
         {
            _relationships = value;
         }
      }

      public void AddRelationship(Relationship Ref)
      {
          RelationshipList.Add(Ref);
      }

      public void RemoveRelationship(Relationship Ref)
      {
          RelationshipList.Remove(Ref);
      }

      public static Relationships ParseXmlNode(XElement Node)
      {
          Relationships r = new Relationships();
          IEnumerable<XElement> nodeliste = Node.Elements();
          foreach (XElement item in nodeliste)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.MARKER_REF:
                      r.AddRelationship(Relationship.ParseXmlNode(item));
                      break;
                  default:
                      break;
              }
          }
          return r;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Relationships R)
      {
         XElement el = new XElement(Ns + Constants.RELATIONSHIPS);

         foreach (Relationship item in R.RelationshipList)
         {
            el.Add(Relationship.CreateXmlNode(Ns, item));
         }

         return el;
      }

   }
}
