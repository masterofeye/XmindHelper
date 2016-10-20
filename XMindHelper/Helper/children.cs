using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Children
   {
       public Children()
       {
           _topics = new List<Topics>();
       }

      private List<Topics> _topics;

      public List<Topics> TopicsList
      {
         get
         {
            return _topics;
         }
         set
         {
            _topics = value;
         }
      }

      public void AddTopics(Topics Ref)
      {
         _topics.Add(Ref);
      }

      public void RemoveTopics(Topics Ref)
      {
         _topics.Remove(Ref);
      }

      public static Children ParseXmlNode(XElement Node)
      {
          Children c = new Children();

          IEnumerable<XElement> nodeliste = Node.Elements();
          foreach (XElement item in nodeliste)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.TOPICS:
                      c.AddTopics(Topics.ParseXmlNode(item));
                      break;
                  default:
                      break;
              }
          }
          return c;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Children C)
      {
         XElement el = new XElement(Ns + Constants.CHILDREND);

         foreach (Topics item in C.TopicsList)
         {
            el.Add(Topics.CreateXmlNode(Ns, item));
         }

         return el;
      }
   }
}
