using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Topics
   {
       public Topics()
       {
           _topics = new List<Topic>();
       }

       public Topics(String Type)
       {
          _type = Type;
          _topics = new List<Topic>();
       }

      private List<Topic> _topics;
      private String _type;

      public List<Topic> TopicsList
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

      public void AddTopic(Topic Ref)
      {
         _topics.Add(Ref);
      }

      public void RemoveTopic(Topic Ref)
      {
         _topics.Remove(Ref);
      }
      public static Topics ParseXmlNode(XElement Node)
      {
          Topics t = new Topics();

          IEnumerable<XAttribute> attrCol = Node.Attributes();
          foreach (XAttribute item in attrCol)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.TYPE:
                      t.Type = item.Value;
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
                  case Constants.TOPIC:
                      t.AddTopic(Topic.ParseXmlNode(item));
                      break;
                  default:
                      break;
              }
          }
          return t;
      }

      public static XElement CreateXmlNode(XNamespace Ns, Topics T)
      {
         XElement el = new XElement(Ns + Constants.TOPICS);

         if (!String.IsNullOrEmpty(T.Type))
            el.Add(new XAttribute(Constants.TYPE, T.Type));

         foreach (Topic item in T.TopicsList)
         {
            el.Add(Topic.CreateXmlNode(Ns, item));
         }
         return el;
      }

   }
}
