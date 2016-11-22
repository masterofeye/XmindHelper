using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMindHelper.ExcelTimeline
{
   class Projekt
   {
      private String _projectName;

      public String ProjectName
      {
        get { return _projectName; }
        set { _projectName = value; }
      }

      Dictionary<String,SamplePhase> _samplePhaseList;

      internal Dictionary<String, SamplePhase> SamplePhaseList
      {
         get { return _samplePhaseList; }
         set { _samplePhaseList = value; }
      }
   }
}
