using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMindHelper.ExcelTimeline
{
   class TimeLineParser
   {
      private const int PROJECT = 1;
      private const int SAMPLEPHASE = 2;
      private const int DUEDATE = 3;


      List<Projekt> _projectList = new List<Projekt>();

      internal List<Projekt> ProjectList
      {
         get { return _projectList; }
         set { _projectList = value; }
      }


      public TimeLineParser() { }

      public void Read(String Filename)
      {

         Projekt p = null;
         try
         {   // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(Filename))
            {
               String line = null;
               while ((line = sr.ReadLine()) != null)
               {
                  String[] split = line.Split('\t');
                  if (split.Count() >= 5)
                  {
                     ParseProjekt(p, split);

                  }

               }
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
         }
      }

      private Projekt ParseProjekt(Projekt P, String[] Split)
      {
         if (P == null)
         {
            P = new Projekt();
            P.ProjectName = Split[PROJECT];
            ParseSamplePhase(null, Split);
         }
         else
         {
            if (P.ProjectName == Split[PROJECT])
            {
               SamplePhase phase;
               if(P.SamplePhaseList.TryGetValue(Split[SAMPLEPHASE], out phase))
               {
                  //SamplePhase existiert schon 
                  ParseSamplePhase(phase, Split);
               }
               else
               {
                  //neue SamplePhase
                  phase = ParseSamplePhase(null, Split);
                  P.SamplePhaseList.Add(Split[SAMPLEPHASE], phase);
               }
            }
         }
         return P;
      }

      private SamplePhase ParseSamplePhase(SamplePhase P, String[] Split)
      {
         if (P == null)
         {
            P = new SamplePhase();
            P.SamplePhase = Split[SAMPLEPHASE];
            ParseSoftwareRelease(null, Split);
         }
         else
         {
            if (P.SamplePhase == Split[SAMPLEPHASE])
            {
               SoftwareRealease sw;
               if (P.SoftwareReleaseList.TryGetValue(Split[SoftwareRealease], out sw))
               {
                  //SamplePhase existiert schon 
                  ParseSamplePhase(phase, Split);
               }
               else
               {
                  //neue SamplePhase
                  phase = ParseSamplePhase(null, Split);
                  P.SamplePhaseList.Add(Split[SAMPLEPHASE], phase);
               }
            }
         }
         return P;
      }

      private SoftwareRealease ParseSoftwareRelease(SoftwareRealease P, String[] Split)
      {
         return P;
      }
   }
}
