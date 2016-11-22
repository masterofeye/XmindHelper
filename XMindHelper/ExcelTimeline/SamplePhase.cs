using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMindHelper.ExcelTimeline
{
   class SamplePhase
   {
      private String _samplePhase;

      public String SamplePhase
      {
         get { return _samplePhase; }
         set { _samplePhase = value; }
      }

      Dictionary<String, SoftwareRealease> _softwareReleaseList;

      internal Dictionary<String, SoftwareRealease> SoftwareReleaseList
      {
         get { return _softwareReleaseList; }
         set { _softwareReleaseList = value; }
      }
   }
}
