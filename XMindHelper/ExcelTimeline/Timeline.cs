using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Globalization;

namespace XMindHelper.ExcelTimeline
{
   class Timeline
   {
      private const string StartTimeCell = "C3";
      private const int StartTimeRow = 3;
      private const int StartTimeColumn= 3;
      private const int StartProjectRow = 6;
      private const int StartProjectColumn = 1;

      public Application _appl;
      public Workbook _workbook;
      public Worksheet _sheet;
      public Range _range;

      public void CreateApplication()
      {
         _appl = new Application();
         _appl.Visible = true;
      }

      public void CreateTimeLineWorkbook()
      {
         _workbook = _appl.Workbooks.Add(Type.Missing);
         _sheet = _workbook.ActiveSheet;
         
         CreateCalendar();

         //Create now all Projects
         var list = Properties.Settings.Default.Projects.Cast<string>().ToList();
         int StartRow= StartProjectRow;
         foreach(var project in list)
         {
            CreateProjekt(project, _sheet.Cells[StartRow, StartProjectColumn]);
            StartRow++;
         }




      }

      public void CreateCalendar()
      {
         DateTime start = new DateTime(2016, 11, 1);
         DateTime end = new DateTime(2017, 1, 1);

         int lastCol = CreateYear(start, _sheet.Cells[StartTimeRow, StartTimeColumn]);

         CreateYear(end, _sheet.Cells[StartTimeRow, lastCol]);
      }

      public int CreateYear(DateTime Start, Range StartCell)
      {
         int daysLeft = new DateTime(Start.Year, 12, 31).DayOfYear - Start.DayOfYear;
         Range c1 = StartCell;
         Range c2 = _sheet.Cells[StartCell.Row, (StartCell.Column + daysLeft)];
         Range r = _sheet.get_Range(c1,c2);
         r.Merge();
         r.set_Value(Missing.Value, Start.Year);

         DateTime date = new DateTime(Start.Year, Start.Month, 1);
         return CreateMonths(date, _sheet.Cells[StartCell.Row,StartCell.Column]);
      }

      public int CreateMonths(DateTime Month, Range StartCell)
      {

         int StartCol = StartCell.Column;
         for (int i = Month.Month; i <= 12; i++)
         {
            int daysInMonth = DateTime.DaysInMonth(Month.Year, i);
            DateTime date = new DateTime(Month.Year, i, 1);
            CreateDays(date, _sheet.Cells[StartCell.Row, StartCol]);
            Range c1 = _sheet.Cells[StartTimeRow + 1, StartCol];
            StartCol = StartCol + daysInMonth;
            Range c2 = _sheet.Cells[StartTimeRow + 1, StartCol-1];

            Range r = _sheet.get_Range(c1, c2);
            r.Merge();
            r.set_Value(Missing.Value, CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i));
         }
         _sheet.Columns.AutoFit();
         return StartCol;
      }

      public void CreateDays(DateTime Month, Range StartCell)
      {
         int daysInMonth = DateTime.DaysInMonth(Month.Year, Month.Month);

         for (int i = 1; i <= daysInMonth; i++)
         {
            _sheet.Cells[StartCell.Row + 2, StartCell.Column + i - 1] = i;
         }
         
      }

      public void MarkToday()
      {
         DateTime date = DateTime.Now;
         
         int d = date.DayOfYear;

      }

      public void CreateProjekt(String Project, Range StartCell)
      {
         StartCell.Value = Project;

      }

      public void SetSWRelease(String SWRelease, Range StartCell, DateTime End)
      { 
         
      }


   }
}


