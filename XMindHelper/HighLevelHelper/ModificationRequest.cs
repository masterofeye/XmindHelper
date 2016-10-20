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

   class Messure
   {
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
      private List<String> _measureList;

      public ModificationRequest(String MRTitel, UInt32 MRNumber, String ProposalText, List<Statement> StatementList, List<String> MeasureList)
      {
         _mrTitel = MRTitel;
         _mrNumber = MRNumber;
         _mrTitel = ProposalText;
         _statementList = StatementList;
         _measureList = MeasureList;
      }

      public void CreateMR()
      {
         /*MR Number*/
         Topic mrNumber = new Topic(_mrNumber.ToString());
         mrNumber.Children = new Children();

         /*Unterpunkte erzeugen*/
         Topics subTopics = new Topics("attached");
         subTopics.AddTopic(new Topic("MR Text"));

         /*Statement Subtopic anlegen und dazugehörigen Statments hinzufügen*/
         Topic statement = new Topic("Statement-List");
         Topics subTopicsStatement = new Topics("attached");
         foreach (var item in _statementList)
         {
            subTopicsStatement.AddTopic(new Topic(item.StatementText, item.IconState));
         }
         statement.AddSubTopics(subTopicsStatement);

         subTopics.AddTopic(statement);
         subTopics.AddTopic(new Topic("CCB"));
         subTopics.AddTopic(new Topic("4-Eye-Review"));
         subTopics.AddTopic(new Topic("Module-Test"));


         /*Statement Subtopic anlegen und dazugehörigen Statments hinzufügen*/
         Topic measure = new Topic("Measure-List");
         Topics subTopicsMeasure = new Topics("attached");
         foreach (var item in _statementList)
         {
            subTopicsStatement.AddTopic(new Topic(item.StatementText, item.IconState));
         }
         statement.AddSubTopics(subTopicsStatement);
         subTopics.AddTopic(new Topic("Measure-List"));
         subTopics.AddTopic(new Topic("Branch-Responsibility"));
         subTopics.AddTopic(new Topic("MR Test"));
         /*Suptopics in das Topic hinzufügen*/
         mrNumber.Children.AddTopics(subTopics);
         
      }

      public void DelteMR()
      { 
      
      }

      public void ChangeMR()
      {

      }
   }
}
