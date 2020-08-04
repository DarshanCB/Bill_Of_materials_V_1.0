using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace BOM_Importer
{
    class Program 
    {
        [STAThread]
        static void Main(string[] args)
        {


            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(new Excel_Text());
       
           
           Environment.Exit(0);

        }
    }
}
