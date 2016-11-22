using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMindHelper.ExcelTimeline
{
   class SoftwareRealease
   {
      private String _softwareRelease;

      public String SoftwareRelease
      {
         get { return _softwareRelease; }
         set { _softwareRelease = value; }
      }

      private DateTime _duedate;

      public DateTime Duedate
      {
         get { return _duedate; }
         set { _duedate = value; }
      }
   }
}
