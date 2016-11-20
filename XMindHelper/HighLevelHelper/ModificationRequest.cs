using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMindHelper.Helper;

namespace XMindHelper.HighLevelHelper
{
   class Statement
   {
      public Statement(String Icon, String Text)
      {
         _iconState = Icon;
         _statementText = Text;
      }

      String _iconState;
      String _statementText;

      public String IconState
      {
         get
         {
            return _iconState;
         }
         set
         {
            _iconState = value;
         }
      }

      public String StatementText
      {
         get
         {
            return _statementText;
         }
         set
         {
            _statementText = value;
         }
      }

   }

   class Measure
   {
      public Measure(String Icon, String Text)
      {
         _iconState = Icon;
         _messureText = Text;
      }

      String _iconState;
      String _messureText;

      public String IconState
      {
         get
         {
            return _iconState;
         }
         set
         {
            _iconState = value;
         }
      }



      public String MessureText
      {
         get
         {
            return _messureText;
         }
         set
         {
            _messureText = value;
         }
      }
   }


   class ModificationRequest
   {
      private String _mrTitel;
      private UInt32 _mrNumber;
      private String _proposalText;
      private List<Statement> _statementList;
      private List<Measure> _measureList;

      public ModificationRequest(String MRTitel, UInt32 MRNumber, String ProposalText, List<Statement> StatementList, List<Measure> MeasureList)
      {
         _mrTitel = MRTitel;
         _mrNumber = MRNumber;
         _proposalText = ProposalText;
         _statementList = StatementList;
         _measureList = MeasureList;
      }

      public Topic CreateMR()
      {
         /*MR Number*/
         Topic mrNumber = new Topic(_mrNumber.ToString());
         mrNumber.Children = new Children();

         /*Unterpunkte erzeugen*/
         Topics subTopics = new Topics("attached");
         subTopics.AddTopic(new Topic(_mrTitel));

         /*Statement Subtopic anlegen und dazugehörigen Statments hinzufügen*/
         Topic statement = new Topic("Statement-List");

         foreach (var item in _statementList)
         {
            statement.AddSubTopicToAttached(new Topic(item.StatementText, item.IconState));
         }


         subTopics.AddTopic(statement);
         subTopics.AddTopic(new Topic("CCB"));
         subTopics.AddTopic(new Topic("4-Eye-Review"));
         subTopics.AddTopic(new Topic("Module-Test"));


         /*Statement Subtopic anlegen und dazugehörigen Statments hinzufügen*/
         Topic measure = new Topic("Measure-List");
         if (_measureList != null && _measureList.Count > 0)
         {
            foreach (var item in _measureList)
            {
               measure.AddSubTopicToAttached(new Topic(item.MessureText, item.IconState));
            }
         }

         subTopics.AddTopic(measure);
         subTopics.AddTopic(new Topic("Branch-Responsibility"));
         subTopics.AddTopic(new Topic("MR Test"));
         /*Suptopics in das Topic hinzufügen*/
         mrNumber.Children.AddTopics(subTopics);
         return mrNumber;
      }

      public void DelteMR()
      { 
      
      }

      public void ChangeMR()
      {

      }
   }
}
