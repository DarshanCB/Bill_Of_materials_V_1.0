using _Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace BOM_Importer
{
    class Excel_Path
    {
        public Range Excel_Range(string Excel_Path)
        {
            _Excel.Application xlApp = new _Excel.Application();
            _Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Excel_Path.ToString());
            _Excel._Worksheet xlWorksheet = xlWorkbook.Worksheets[1];
            _Excel.Range xlRange = xlWorksheet.UsedRange;
            store_Excel_Path = Excel_Path.ToString();


            return xlRange;

        }

        public string store_Excel_Path { get; set; }

        public void KillSpecificExcelFileProcess()
        {
           
            foreach (Process process_excel in Process.GetProcesses())
            {
                if (process_excel.ProcessName == "EXCEL")
                {
                    process_excel.Kill();
                
                }
            }
        }

     


        public void Kill_Excel_Process(string Excel_Path)
        {
            _Excel.Application xlApp = new _Excel.Application();
            _Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Excel_Path.ToString());
            _Excel._Worksheet xlWorksheet = xlWorkbook.Worksheets[1];
            _Excel.Range xlRange = xlWorksheet.UsedRange;

            xlWorkbook.Close();
            xlApp.Quit();

        }
    }
}
