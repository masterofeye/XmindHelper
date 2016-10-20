using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Topic
   {
      public Topic()
      { 
      
      }

      public Topic(String Title)
      {
         _title = new Title(Title);
         _id = Util.Generate_ID();
         _timestamp = Util.GetEpoch();
      }

      public Topic(String Title, String Icon)
      {
         _title = new Title(Title);
         _id = Util.Generate_ID();
         _timestamp = Util.GetEpoch();
         AddIcon(Icon);
      }

      private String _branch;
      private String _id;
      private long _timestamp = 0;
      private String _modified_by;
      private String _style;
      private Title _title = null;
      private MarkerRefs _markerrefs = null;
      private String _xlink;
      private String _structure_class;
      private Children _children = null;
      private Labels _labels = null;
      private Relationships _relationships = null;
      private Boundaries _boundaries = null;

      public String Branch
      {
         get
         {
            return _branch;
         }
         set
         {
            _branch = value;
         }
      }

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

      public long Timestamp
      {
          get
          {
              return _timestamp;
          }
          set
          {
              _timestamp = value;
          }
      }

      public String Modified_By
      {
          get
          {
              return _modified_by;
          }
          set
          {
              _modified_by = value;
          }
      }

      public String Style
      {
          get
          {
              return _style;
          }
          set
          {
              _style = value;
          }
      }

      public Title Title
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

      public MarkerRefs MarkerRefs
      {
          get
          {
              return _markerrefs;
          }
          set
          {
              _markerrefs = value;
          }
      }

      public String XLink
      {
          get
          {
              return _xlink;
          }
          set
          {
              _xlink = value;
          }
      }

      public String Structure_Class
      {
          get
          {
              return _structure_class;
          }
          set
          {
              _structure_class = value;
          }
      }

      public Children Children
      {
          get
          {
              return _children;
          }
          set
          {
              _children = value;
          }
      }

      public Labels Labels
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

      public Relationships Relationships
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

      public Boundaries Boundaries
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

      public void SetMarkerRefs(MarkerRefs MarkerRefs)
      {
         _markerrefs = MarkerRefs;
      }

      public void AddIcon(String Icon)
      {
         if (_markerrefs == null)
            _markerrefs = new MarkerRefs();

         _markerrefs.AddMarkRef(new MarkerRef(Icon));
      }

      public void AddSubTopics(Topics SubTopic)
      {
         if (_children == null)
            _children = new Children();

         _children.AddTopics(SubTopic);
      }



      public static Topic ParseXmlNode(XElement Node)
      {
          Topic t = new Topic();
          IEnumerable<XAttribute> attrCol = Node.Attributes();
          foreach (XAttribute item in attrCol)
          {
              switch (item.Name.LocalName)
              {
                  case Constants.ID:
                      t.ID = item.Value;
                      break;
                  case Constants.TIMESTAMP:
                      t.Timestamp = long.Parse(item.Value);
                      break;
                  case Constants.BRANCH:
                      t.Branch = item.Value;
                      break;
                  case Constants.MODIFIED_BY:
                      t.Modified_By = item.Value;
                      break;
                  case Constants.STYLE_ID:
                      t.Style = item.Value;
                      break;
                  case Constants.XLINK:
                      t.XLink = item.Value;
                      break;
                  case Constants.STRUCTURE_CLASS:
                      t.Structure_Class = item.Value;
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

      public static XElement CreateXmlNode(XNamespace Ns, Topic T)
      {
         XElement el = new XElement(Ns + Constants.TOPIC);

         if(!String.IsNullOrEmpty(T.ID))
            el.Add(new XAttribute(Constants.ID, T.ID));
         else
            el.Add(new XAttribute(Constants.ID, Util.Generate_ID()));

         if (!String.IsNullOrEmpty(T.Branch))
            el.Add(new XAttribute(Constants.BRANCH, T.Branch)); //TODO Style ID

         if(!String.IsNullOrEmpty(T.Style))
            el.Add(new XAttribute(Constants.STYLE_ID, T.Style)); //TODO Style ID

         if (!String.IsNullOrEmpty(T.Structure_Class))
            el.Add(new XAttribute(Constants.STRUCTURE_CLASS, T.Structure_Class));

         if (T.Timestamp == 0)
            el.Add(new XAttribute(Constants.TIMESTAMP, Util.GetEpoch()));
         else
            el.Add(new XAttribute(Constants.TIMESTAMP, T.Timestamp));

         if (!String.IsNullOrEmpty(T.XLink))
            el.Add(new XAttribute(Constants.XLINK, T.XLink));

         if (T.Title != null)
         {
         XElement title = Title.CreateXmlNode(Ns, T.Title);
         if (title != null)
            el.Add(title);
         }

         if (T.Children != null)
         {
            XElement children = Children.CreateXmlNode(Ns, T.Children);
            if (children != null)
               el.Add(children);
         }

         if (T.MarkerRefs != null)
         {
            XElement markerref = MarkerRefs.CreateXmlNode(Ns, T.MarkerRefs);
            if (markerref != null)
               el.Add(markerref);
         }

         if (T.Relationships != null)
         {
            XElement relationships = Relationships.CreateXmlNode(Ns, T.Relationships);
            if (relationships != null)
               el.Add(relationships);
         }

         if (T.Boundaries != null)
         {
            XElement boundaries = Boundaries.CreateXmlNode(Ns, T.Boundaries);
            if (boundaries != null)
               el.Add(boundaries);
         }
         return el;

      
      }
   }
}
