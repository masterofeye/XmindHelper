using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMindHelper.Helper;

namespace XMindHelper
{
   class ModificationRequest
   {
      public static XElement CreateMR(String MRNumber, String MRText, String MRTitel, XNamespace Ns, List<String> Stellungnahmen, List<String> Messures)
      {
         Topic mrnumber = new Topic(MRNumber);
         mrnumber.Children = new Children();

         Topics top = new Topics("attached");
         mrnumber.Children.AddTopics(top);
         top.AddTopic(new Topic("Antragstext"));

         Topic stellungnahmen = new Topic("Stellungnahmen");
         stellungnahmen.Children = new Children();
         Topics stellungnahmenTopics = new Topics("attached");
         foreach (String item in Messures)
         {
            stellungnahmenTopics.AddTopic(new Topic(item));
         }

         top.AddTopic(stellungnahmen);
         top.AddTopic(new Topic("CCB"));

         Topic measures = new Topic("Measures");
         measures.Children = new Children();
         Topics measuresTopics = new Topics("attached");
         foreach (String item in Messures)
	      {
            measuresTopics.AddTopic(new Topic(item));
	      }
         


         top.AddTopic(measures);
         top.AddTopic(new Topic("4-Eye-Review"));
         top.AddTopic(new Topic("Modultest"));
         top.AddTopic(new Topic("Branch-Responsibility"));
         top.AddTopic(new Topic("MR Test"));

         return  Topic.CreateXmlNode(Ns, mrnumber);
      }

      public MarkerRefs AddMarker(List<String> Stellungnahmen)
      {
         MarkerRefs markerrefs = new MarkerRefs();
         markerrefs.AddMarkRef(new MarkerRef("symbol-right"));
         return markerrefs;
      }
   }


}
