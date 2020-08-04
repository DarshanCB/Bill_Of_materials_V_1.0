using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BOM_Importer 

{


    public partial class Excel_Text : Form
    {
        
        Excel_Path excel_range = new Excel_Path();
   
      
        public Excel_Text()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Please select the BOM Excel File";
            string token = ArasInterface.get_token();
          
           
        }


        #region Manufacturer

        private void Manufacturer()
        {

            try
            {
                //POST CRUD operation will be called which will add the new manufacturer, skip if there are duplicates and skip if there are no manufacturer
                
                Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                //Get the unique sorted list of items for manufacturers

                SortedSet<string> remove_dup = new SortedSet<string>();

                for (int i = 2; i <= rowCount; i++)
                {
                    remove_dup.Add(xlRange.Cells[i, 14].Value2);
                }

                int total_elements_bom = remove_dup.Count;
                int new_items = 0;

                foreach (string sorted_manufacture in remove_dup)
                {
                    if (sorted_manufacture == null)
                    {
                        continue;
                    }
                    else
                    {
                        var Manufacturer_items = new Dictionary<string, string>();
                        Manufacturer_items.Add("name", sorted_manufacture);

                        HttpResponseMessage response = ArasInterface.Manufacturer_POST_response(Manufacturer_items);

                        if (response.IsSuccessStatusCode)
                        {
                            new_items++;
                        }
                        else
                        {
                            //tis could also be a bad request!!!
                            toolStripStatusLabel1.Text = "Manufacturer Already exist results in " + response.ReasonPhrase;
                        }
                    }
                }

                tbNoOfManufacturers.Text = total_elements_bom + "  /  New_items = " + new_items;
                if (new_items > 0)
                {
                    toolStripStatusLabel1.Text = new_items + " manufacturer imported";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }
        }

        private void Manufacturer_AML()
        {
            try
            {

                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //this.textBox2.Text = sfd.FileName;
                    string path = sfd.FileName;

                    if (!File.Exists(path))
                    {
                        using (File.Create(path)) ;
                        toolStripStatusLabel1.Text = "File created successfully";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "File Already exist";
                    }

                    //Range xlRange = excel_range.Excel_Range(open_BOM_File.FileName.ToString());
                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;


                    SortedSet<string> remove_dup = new SortedSet<string>();

                    for (int i = 2; i <= rowCount; i++)
                    {
                        remove_dup.Add(xlRange.Cells[i, 14].Value2);
                    }

                    int total_items = remove_dup.Count;
                    int new_items = 0;


                   
                    foreach (string sorted_manufacture in remove_dup)
                    {
                        var Manufacturer_items = new Dictionary<string, string>();
                        Manufacturer_items.Add("name", sorted_manufacture);


                        File.AppendAllText(path, "<Item type=\"Manufacturer\" action=\"add\"> \n <name>" + sorted_manufacture + "</name> \n </Item> \n" + Environment.NewLine);
                        new_items++;
                        
                       
                    }

                    xlRange.Worksheet.Application.Quit();

                    tbNoOfManufacturers.Text = total_items + "  /  New_items =  " + new_items;
                    toolStripStatusLabel1.Text = "AML created for Manufacturer";

                    if (new_items > 0)
                    {
                        toolStripStatusLabel1.Text = new_items + " manufacturer imported";
                    }

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }
        }

        //private void Manufacturer_Edit()
        //{
        //    try
        //    {
        //        //PATCH CRUD operation will be called which will add the new manufacturer, skip if there are duplicates and skip if there are no manufacturer

        //        Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

        //        int rowCount = xlRange.Rows.Count;
        //        int colCount = xlRange.Columns.Count;

        //        //Get the unique sorted list of items for manufacturers

        //        SortedSet<string> remove_dup = new SortedSet<string>();

        //        for (int i = 2; i <= rowCount; i++)
        //        {
        //            remove_dup.Add(xlRange.Cells[i, 14].Value2);
        //        }


        //        int total_elements_bom = remove_dup.Count;
        //        int new_items = 0;

        //        foreach (string sorted_manufacture in remove_dup)
        //        {
        //            if (sorted_manufacture == null)
        //            {
        //                continue;
        //            }
        //            else
        //            {

        //                var Manufacturer_items = new Dictionary<string, string>();
        //                Manufacturer_items.Add("name", sorted_manufacture);

        //                bool response = ArasInterface.Manufacturer_Edit_response(Manufacturer_items);

        //                if (response)
        //                {
        //                    new_items++;
        //                }
        //                else
        //                {
        //                    toolStripStatusLabel1.Text = "Manufacturer Already exist";
        //                }

        //            }
        //        }

        //        tbNoOfManufacturers.Text = total_elements_bom + "  /  New_items = " + new_items;
        //        if (new_items > 0)
        //        {
        //            toolStripStatusLabel1.Text = new_items + " manufacturer imported";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("exception " + e.ToString());
        //    }
        //    finally
        //    {
        //        excel_range.KillSpecificExcelFileProcess();
        //    }
        //}

        #endregion Manufacturer

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //textBox2.Text = sfd.FileName;
        }

       

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Manufacturer_part

        private void Manufacturer_Part_AML()
        {

            try
            {

                SaveFileDialog sfd = new SaveFileDialog();
                HttpClient client = ArasInterface.RequestRead();
                var myUniqueFileName = string.Format(@"{0}.txt", Guid.NewGuid());
                string env_path = "C:\\Users\\" + Environment.UserName + "\\Documents\\";
                string actual_file = env_path + "manufacturer_part_number" + myUniqueFileName;
                int total_item = 0;
                int new_item = 0;

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //this.textBox3.Text = sfd.FileName;

                    string Manufacturer_Part_Path = sfd.FileName;

                    if (!File.Exists(Manufacturer_Part_Path))
                    {
                        using (File.Create(Manufacturer_Part_Path)) ;
                        toolStripStatusLabel1.Text = "File created successfully";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "File Already exist";
                    }



                    //Range xlRange = excel_range.Excel_Range(open_BOM_File.FileName.ToString());
                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;


                    string token = ArasInterface.get_token();
                    string urlParameters = "http://pdm-test.elcon-system.de/Innovator12/server/odata/Manufacturer Part?$select=id,item_number";

                    HttpResponseMessage response = ArasInterface.Request_result(urlParameters,"GET",token);  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                    if (response.IsSuccessStatusCode)
                    {

                        using (HttpContent content = response.Content)
                        {
                            
                            if (!File.Exists(actual_file))
                            {
                                using (File.Create(actual_file));

                                toolStripStatusLabel1.Text = "File created successfully";
                            }
                            else
                            {
                                toolStripStatusLabel1.Text = "File Already exist";
                            }

                            string result = content.ReadAsStringAsync().Result;

                            var jsonObj = JObject.Parse(result);
                            var values = (JArray)jsonObj["value"];

                            foreach (var item_number in values)
                            {
                                var append_item_number = (string)item_number["item_number"];

                                File.AppendAllText(actual_file, append_item_number + "\n");
                            }

                               
                            
                        }
                    }

                 for (int i = 2; i <= rowCount; i++)
                    {
                        string part_number = Convert.ToString(xlRange.Cells[i, 17].Value2);
                        string name_part = xlRange.Cells[i, 7].Value2;
                        string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                        if (part_number == null)
                        {
                            continue;
                        }
                        else
                        {
                            total_item++;
                            using (StreamReader sr = File.OpenText(actual_file))
                            {
                                string[] lines = File.ReadAllLines(actual_file);
                                bool exist = true;
                                
                                foreach (var all_item_number in lines)
                                {
                                 if(all_item_number == part_number)
                                    {
                                        exist = true;
                                        break;
                                    }
                                else
                                {
                                        exist = false;
                                }
                            }

                                if(exist == false)
                                {
                                    new_item++;
                                    File.AppendAllText(Manufacturer_Part_Path, "<Item type=\"Manufacturer Part\" action=\"add\"> \n <item_number>" + xlRange.Cells[i, 17].Value2 + "</item_number> \n <name>" + required_name + "</name> \n <manufacturer> \n <Item type =\"Manufacturer\" action= \"get\"> \n <name>" + xlRange.Cells[i, 14].Value2 + "</name> \n </Item> \n </manufacturer> \n <description>" + xlRange.Cells[i, 7].Value2 + "</description> \n </Item> \n  \n");
                                }
  
                            }

                        }

                    }
            
              

                }

                tbNoOfManufacturerParts.Text = total_item + "  /  New_items =  " + new_item;

                toolStripStatusLabel1.Text = "AML created for Manufacturer_Part";

                if (new_item > 0)
                {
                    toolStripStatusLabel1.Text = new_item + " manufacturer_part imported";
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }
        }

        private void Manufacturer_Part()
        {

            try
            {

                Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                int total_item = rowCount-1;
                int new_item = 0;

                for (int i = 2; i <= rowCount; i++)
                {

                    string item_number = Convert.ToString(xlRange.Cells[i, 17].Value2);
                    string description = xlRange.Cells[i, 7].Value2;
                    string required_name = description.Substring(0, description.IndexOf("/"));
                    string manufcaturer_name = Convert.ToString(xlRange.Cells[i, 14].Value2);

                   // bool result = ArasInterface.Manufacturer_Part_GET_response(item_number);


                    if (item_number != null && manufcaturer_name != null)
                    {

                        var Manufacturer_part_items = new Dictionary<string, string>();
                        Manufacturer_part_items.Add("item_number", item_number);
                        Manufacturer_part_items.Add("name", required_name);
                        Manufacturer_part_items.Add("description",description);

                        //Based on the manufacturer we are getting the manufacturer id respectively

                        string manufacturer_response = ArasInterface.Manufacturer_GET_response(Manufacturer_part_items);
                        string req_manufacturer_id = ArasInterface.GetManufacturer_id(manufcaturer_name, manufacturer_response);

                        Manufacturer_part_items.Add("manufacturer", req_manufacturer_id);

                        var encodedContent = JsonConvert.SerializeObject(Manufacturer_part_items);
                        HttpContent stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

                        HttpResponseMessage ManufacturerPart_POST = ArasInterface.Manufacturer_Part_POST_response(stringContent);

                        new_item++;

                    }

                }

                    tbNoOfManufacturerParts.Text = total_item + "  /  New_items =  " + new_item;

                    toolStripStatusLabel1.Text = "manufacturer part imported";
                
            }
            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }

        }


        #endregion Manufacturer_part



        #region part


        private void Part_AML()
        {
            try
            {

                SaveFileDialog sfd = new SaveFileDialog();

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //this.textBox4.Text = sfd.FileName;
                    string path = sfd.FileName;

                    if (!File.Exists(path))
                    {
                        using (File.Create(path)) ;
                        toolStripStatusLabel1.Text = "File created successfully";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "File Already exist";
                    }

                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    int total_items = 0;
                    int new_items = 0;

                    Dictionary<string, string> part_unique = new Dictionary<string, string>();
                    Dictionary<string, string> part_description = new Dictionary<string, string>();


                    for (int i = 2; i <= rowCount; i++)
                    {
                        string part = Convert.ToString(xlRange.Cells[i, 5].Value2);
                        string name_part = xlRange.Cells[i, 7].Value2;
                        string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                        if (!part_unique.ContainsKey(part) && !part_description.ContainsKey(part))
                        {
                            part_unique.Add(part, required_name);
                            part_description.Add(part, name_part);
                        }
                        
                    }
                    //total number of the parts will be calculated
                    total_items = part_unique.Keys.Count;

                    List<string> add_descriprtion_entry = new List<string>();

                    foreach (KeyValuePair<string, string> name_number in part_unique)
                    {
                        


                        foreach (KeyValuePair<string, string> name_description in part_description)

                            //Part and name AML structure will be created with unique part
                            if (name_number.Key == null)
                            {
                                continue;
                            }
                            else
                            {
                                
                                if (name_number.Key == name_description.Key)
                                {
                                    File.AppendAllText(path, "<Item type=\"Part\" action=\"add\"> \n  <item_number>" + name_number.Key + "</item_number> \n <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                                   // File.AppendAllText(path, "<Item type=\"Part\" action=\"edit\" where=\"[item_number]='" + name_number.Key + "'\">  \n  <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                                    new_items++;
                                }
                                add_descriprtion_entry.Add(name_description.Key);
                            }
                    }

                    tbNoOfParts.Text = total_items + "  /  New_items = " + new_items;

                    toolStripStatusLabel1.Text = "Part with part number and name is created";

                    if (new_items > 0)
                    {
                        toolStripStatusLabel1.Text = new_items + " part imported";
                    }

                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }
        }

        private void Part()
        {
            try
            {

                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    int total_items = 0;
                    int new_items = 0;

                    Dictionary<string, string> part_unique = new Dictionary<string, string>();
                    Dictionary<string, string> part_description = new Dictionary<string, string>();


                    for (int i = 2; i <= rowCount; i++)
                    {
                        string part = Convert.ToString(xlRange.Cells[i, 5].Value2);
                        string name_part = xlRange.Cells[i, 7].Value2;
                        string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                        if (!part_unique.ContainsKey(part) && !part_description.ContainsKey(part))
                        {
                            part_unique.Add(part, required_name);
                            part_description.Add(part, name_part);
                        }

                    }
                    //total number of the parts will be calculated
                    total_items = rowCount-1;

                foreach (KeyValuePair<string, string> name_number in part_unique)
                {


                    foreach (KeyValuePair<string, string> name_description in part_description)

                    { //Part and name AML structure will be created with unique part
                        if (name_number.Key == null)
                        {
                            continue;
                        }

                        else if(name_number.Key == name_description.Key)
                        {
                            var Part_items = new Dictionary<string, string>();
                            Part_items.Add("item_number", name_number.Key);
                            Part_items.Add("name", name_number.Value);
                            Part_items.Add("description", name_description.Value);

                            bool result = ArasInterface.Part_POST_response(Part_items, name_number.Key);

                            if(result)
                            {
                                new_items++;
                            }
                            //File.AppendAllText(path, "<Item type=\"Part\" action=\"add\"> \n  <item_number>" + name_number.Key + "</item_number> \n <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                            //File.AppendAllText(path, "<Item type=\"Part\" action=\"edit\" where=\"[item_number]='" + name_number.Key + "'\">  \n  <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                            
                        }
                    }
                }
                               
                            
                    

                    tbNoOfParts.Text = total_items + "  /  New_items = " + new_items;

                    toolStripStatusLabel1.Text = "Part with part number and name is created";

                if (new_items > 0)
                {
                    toolStripStatusLabel1.Text = new_items + " part imported";
                }



            }

               
            
            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }
        }



        private void Part_edit()
        {
            try
            {

                Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                int total_items = 0;
                int new_items = 0;

                Dictionary<string, string> part_unique = new Dictionary<string, string>();
                Dictionary<string, string> part_description = new Dictionary<string, string>();


                for (int i = 2; i <= rowCount; i++)
                {
                    string part = Convert.ToString(xlRange.Cells[i, 5].Value2);
                    string name_part = xlRange.Cells[i, 7].Value2;
                    string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                    if (!part_unique.ContainsKey(part) && !part_description.ContainsKey(part))
                    {
                        part_unique.Add(part, required_name);
                        part_description.Add(part, name_part);
                    }

                }
                //total number of the parts will be calculated
                total_items = part_unique.Keys.Count;

                foreach (KeyValuePair<string, string> name_number in part_unique)
                {

                    foreach (KeyValuePair<string, string> name_description in part_description)

                        //Part and name AML structure will be created with unique part
                        if (name_number.Key == null)
                        {
                            continue;
                        }
                        else
                        {
                            
                            if (name_number.Key == name_description.Key)
                            {
                                var Part_items = new Dictionary<string, string>();
                                Part_items.Add("item_number", name_number.Key);
                                Part_items.Add("name", name_number.Value);
                                Part_items.Add("description", name_description.Value);

                                bool result = ArasInterface.Part_Edit_response(name_number.Key,Part_items);

                                if (result == true)
                                {
                                    //File.AppendAllText(path, "<Item type=\"Part\" action=\"add\"> \n  <item_number>" + name_number.Key + "</item_number> \n <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                                    //File.AppendAllText(path, "<Item type=\"Part\" action=\"edit\" where=\"[item_number]='" + name_number.Key + "'\">  \n  <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                                    new_items++;
                                }
                            }

                        }
                }

                tbNoOfParts.Text = total_items + "  /  New_items = " + new_items;

                toolStripStatusLabel1.Text = "Part with part number and name is created";


                if (new_items > 0)
                {
                    toolStripStatusLabel1.Text = new_items + " part edit imported";
                }
            }



            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }
        }

        #endregion part


        #region Device

        private void Device_AML()
        {
            try
            {

                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //this.textBox4.Text = sfd.FileName;
                    string path = sfd.FileName;

                    if (!File.Exists(path))
                    {
                        using (File.Create(path)) ;
                        toolStripStatusLabel1.Text = "File created successfully";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "File Already exist";
                    }

                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    int total_items = 0;
                    int new_items = 0;

                    SortedDictionary<string, string> device_number = new SortedDictionary<string, string>();
                    Dictionary<string, string> part_description = new Dictionary<string, string>();


                    for (int i = 2; i <= rowCount; i++)
                    {
                        string device = Convert.ToString(xlRange.Cells[i, 1].Value2);
                        string name_part = xlRange.Cells[i, 7].Value2;
                        string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                        if (!device_number.ContainsKey(device) && !part_description.ContainsKey(device))
                        {
                            device_number.Add(device, required_name);
                            part_description.Add(device, name_part);
                        }

                    }

                    //total number of the parts will be calculated
                    total_items = device_number.Keys.Count;

                    foreach (KeyValuePair<string, string> name_number in device_number)
                    {
                        
                        foreach (KeyValuePair<string, string> name_description in part_description)

                            //Part and name AML structure will be created with unique part
                            if (name_number.Key == null)
                            {
                                continue;
                            }
                            else
                            { 
                               
                                if (name_number.Key == name_description.Key)
                                 {
                                    File.AppendAllText(path, "<Item type=\"Part\" action=\"add\"> \n  <item_number>" + name_number.Key + "</item_number> \n <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                                    //File.AppendAllText(path, "<Item type=\"Part\" action=\"edit\" where=\"[item_number]='" + name_number.Key + "'\">  \n  <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
                                    new_items++;
                                 }

                                
                            }
                    }


                    tbNoOfDevice.Text = total_items + "  /  New_items = " + new_items;

                    toolStripStatusLabel1.Text = "Device with part number created";

                    if (new_items > 0)
                    {
                        toolStripStatusLabel1.Text = new_items + " device imported";
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }

        }

        private void Device()
        {
            try
            {

               
                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    int total_items = 0;
                    int new_items = 0;

                SortedDictionary<string, string> device_name = new SortedDictionary<string, string>();
                Dictionary<string, string> part_description = new Dictionary<string, string>();


                for (int i = 2; i <= rowCount; i++)
                {
                    string device = Convert.ToString(xlRange.Cells[i, 1].Value2);
                    string name_part = xlRange.Cells[i, 7].Value2;
                    string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                    if (!device_name.ContainsKey(device) && !part_description.ContainsKey(device))
                    {
                        device_name.Add(device, required_name);
                        part_description.Add(device, name_part);
                    }

                }
                //total number of the parts will be calculated
                total_items = rowCount-1;

                foreach (KeyValuePair<string, string> name_number in device_name)
                {

                 
                    foreach (KeyValuePair<string, string> name_description in part_description)

                        //Part and name AML structure will be created with unique part
                        if (name_number.Key == null)
                        {
                            continue;
                        }
                        else
                        {
                           
                           if (name_number.Key == name_description.Key)
                            {
                                var device_items = new Dictionary<string, string>();
                                device_items.Add("item_number", name_number.Key);
                                device_items.Add("name", name_number.Value);
                                device_items.Add("description", name_description.Value);

                                bool result = ArasInterface.Device_POST_response(device_items, name_number.Key);

                                if (result)
                                {
                                    new_items++;
                                }
                            }

                        }
                }

              
                tbNoOfDevice.Text = total_items + "  /  New_items = " + new_items;


                toolStripStatusLabel1.Text = "Device with part number created";

                if (new_items > 0)
                {
                    toolStripStatusLabel1.Text = new_items + " device imported";
                }


            }
            

            catch (Exception e)
            {
                Console.WriteLine("exception " + e.ToString());
            }
            finally
            {
                excel_range.KillSpecificExcelFileProcess();
            }

        }

        //private void Device_Edit()
        //{
        //    try
        //    {

        //        Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

        //        int rowCount = xlRange.Rows.Count;
        //        int colCount = xlRange.Columns.Count;

        //        int total_items = 0;
        //        int new_items = 0;

        //        Dictionary<string, string> part_unique = new Dictionary<string, string>();
        //        Dictionary<string, string> part_description = new Dictionary<string, string>();


        //        for (int i = 2; i <= rowCount; i++)
        //        {
        //            string part = Convert.ToString(xlRange.Cells[i, 5].Value2);
        //            string name_part = xlRange.Cells[i, 7].Value2;
        //            string required_name = name_part.Substring(0, name_part.IndexOf("/"));
        //            if (!part_unique.ContainsKey(part) && !part_description.ContainsKey(part))
        //            {
        //                part_unique.Add(part, required_name);
        //                part_description.Add(part, name_part);
        //            }

        //        }
        //        //total number of the parts will be calculated
        //        total_items = part_unique.Keys.Count;

        //        foreach (KeyValuePair<string, string> name_number in part_unique)
        //        {

        //            foreach (KeyValuePair<string, string> name_description in part_description)

        //                //Part and name AML structure will be created with unique part
        //                if (name_number.Key == null)
        //                {
        //                    continue;
        //                }
        //                else
        //                {

        //                    if (name_number.Key == name_description.Key)
        //                    {
        //                        var Part_items = new Dictionary<string, string>();
        //                        Part_items.Add("item_number", name_number.Key);
        //                        Part_items.Add("name", name_number.Value);
        //                        Part_items.Add("description", name_description.Value);

        //                        // device edit will also use the same function
        //                        bool result = ArasInterface.Part_Edit_response(name_number.Key, Part_items);

        //                        if (result == true)
        //                        {
        //                            //File.AppendAllText(path, "<Item type=\"Part\" action=\"add\"> \n  <item_number>" + name_number.Key + "</item_number> \n <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
        //                            //File.AppendAllText(path, "<Item type=\"Part\" action=\"edit\" where=\"[item_number]='" + name_number.Key + "'\">  \n  <name>" + name_number.Value + "</name> \n <description>" + name_description.Value + "</description> \n </Item> \n  \n" + Environment.NewLine);
        //                            new_items++;
        //                        }
        //                    }

        //                }
        //        }

        //        tbNoOfParts.Text = total_items + "  /  New_items = " + new_items;

        //        toolStripStatusLabel1.Text = "Part with part number and name is created";


        //        if (new_items > 0)
        //        {
        //            toolStripStatusLabel1.Text = new_items + " device edit imported";
        //        }
        //    }



        //    catch (Exception e)
        //    {
        //        Console.WriteLine("exception " + e.ToString());
        //    }
        //    finally
        //    {
        //        excel_range.KillSpecificExcelFileProcess();
        //    }

        //}

        #endregion Device

        private void ShowHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void HelpFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.Show();
        }


        #region Part_AML_Relation

        private string Part_Relation()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                string path = sfd.FileName;
                int total_items = 0;
                int new_items = 0;

                if (!File.Exists(path))
                {
                    using (File.Create(path)) ;
                    toolStripStatusLabel1.Text = "File created successfully";
                }
                else
                {
                    toolStripStatusLabel1.Text = "File Already exist";
                }

                Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                total_items = rowCount - 1;

                for (int i = 2; i <= rowCount; i++)
                {

                    string name_part = xlRange.Cells[i, 7].Value2;
                    string required_name = name_part.Substring(0, name_part.IndexOf("/"));
                    string part_number = Convert.ToString(xlRange.Cells[i, 5].Value2);
                    string item_number = Convert.ToString(xlRange.Cells[i, 17].Value2);

                    //Part  AML structure will be created for building relationship with Parts
                    if (part_number == null || item_number == null)
                    {
                        continue;
                    }
                    else
                    {
                        new_items++;
                        File.AppendAllText(path, "<Item type=\"Part AML\" action=\"add\"> \n <source_id> \n <Item type= \"Part\" action = \"get\"> \n <item_number>" + part_number + "</item_number> \n </Item> \n </source_id> \n <related_id> \n <Item type=\"Manufacturer Part\" action=\"get\"> \n <item_number>" + item_number + "</item_number> \n <manufacturer> \n <Item type=\"Manufacturer\" action=\"get\">  \n  <name>" + xlRange.Cells[i, 14].Value2 + "</name> \n </Item> \n  </manufacturer> \n </Item> \n </related_id> \n </Item> \n  \n" + Environment.NewLine);
                    }

                }

                tbNoOfParts.Text = total_items + "  /  New_items = " + new_items;

                toolStripStatusLabel1.Text = "AML created for Part";

               
            }

            return sfd.FileName.ToString();

        }


        #endregion Part_AML_Relation

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        #region Device_BOM

        private void Device_BOM()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //this.textBox4.Text = sfd.FileName;
                string path = sfd.FileName;
                int total_items = 0;
                int new_items = 0;

                if (!File.Exists(path))
                {
                    using (File.Create(path)) ;
                    toolStripStatusLabel1.Text = "File created successfully";
                }
                else
                {
                    toolStripStatusLabel1.Text = "File Already exist";
                }


                //Range xlRange = excel_range.Excel_Range(open_BOM_File.FileName.ToString());
                Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                total_items = rowCount - 1;

                Dictionary<string, string> part_unique = new Dictionary<string, string>();
                Dictionary<string, double> quantity_unique = new Dictionary<string, double>();

                for (int i = 2; i <= rowCount; i++)
                {
                    string part = Convert.ToString(xlRange.Cells[i, 5].Value2);
                    string device = Convert.ToString(xlRange.Cells[i, 1].Value2);
                    double quantity = xlRange.Cells[i, 8].Value2;

                    if (!part_unique.ContainsKey(part) && !quantity_unique.ContainsKey(part))
                    {
                        part_unique.Add(part, device);
                        quantity_unique.Add(part, quantity);
                    }
                }

                List<string> add_quantity_entry = new List<string>();

                foreach (KeyValuePair<string, string> part_entry in part_unique)
                {
                    foreach (KeyValuePair<string, double> quantity_entry in quantity_unique)
                    {

                        if (part_entry.Key == null)
                        {
                            continue;
                        }

                        else
                        {

                            if (add_quantity_entry.Contains(part_entry.Key) || add_quantity_entry.Contains(quantity_entry.Key))
                            {
                                continue;
                            }
                            else
                            {
                                new_items++;
                                File.AppendAllText(path, "<Item type=\"Part BOM\" action=\"add\"> \n <quantity>" + quantity_entry.Value + "</quantity> \n <source_id> \n <Item type= \"Part\" action = \"get\"> \n <item_number>" + part_entry.Value + "</item_number> \n </Item> \n </source_id> \n <related_id> \n <Item type=\"Part\" action=\"get\"> \n <item_number>" + part_entry.Key + "</item_number> \n </Item> \n </related_id> \n </Item> \n  \n" + Environment.NewLine);
                            }
                            add_quantity_entry.Add(quantity_entry.Key);
                        }

                    }
                }

                tbNoOfDeviceBOM.Text = total_items + "  /  New_items = " + new_items;

                toolStripStatusLabel1.Text = "AML created for Device BOM";
            }
        }

        #endregion Device_BOM



        private void button6_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Please add the BOM Excel File";

            Device_BOM();
        }





        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    tbBOMFilename.Text = openFileDialog.FileName;

                    //string Excel_File_Attached_Path = open_BOM_File.FileName.ToString();
                    //string Excel_File_Attached_Path = tbBOMFilename.Text;

                    Range xlRange = excel_range.Excel_Range(tbBOMFilename.Text);

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;


                    //to do... filter out numbers
                    tbNoOfManufacturers.Text = "xx / new yy";
                    tbNoOfManufacturerParts.Text = "xx / new yy";
                    tbNoOfParts.Text = "xx / new yy";
                    tbNoOfPartAML.Text = "xx / new yy";
                    tbNoOfDevice.Text = "xx / new yy";
                    tbNoOfDeviceBOM.Text = "xx / new yy";

                }
            }
            toolStripStatusLabel1.Text = "BOM file selected, ready for import";
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //to do Use a option object and handover to form and get it back

            OptionsForm options = new OptionsForm();
            options.Show();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            //to do
            //import everything which is checked with checkboxes


            if (!cbManufacturers.Checked
            && !cbManufacturerParts.Checked
            && !cbPart_relation.Checked
            && !cbPart.Checked
            && !cbdevice.Checked
            && !cbDevice_BOM.Checked
            && !cbDevice_BOM.Checked
           )
            {
                MessageBox.Show("nothing selected. no import necessary...");
            }
            else
            {
                //Manufacture can be created using AML structure or by using the POST request
                if (Properties.Settings.Default.USE_AML && cbManufacturers.Checked)
                {
                    Manufacturer_AML();
                }
                else if (!Properties.Settings.Default.USE_AML && cbManufacturers.Checked )
                {
                    Manufacturer();
                    
                }
               

                if (Properties.Settings.Default.USE_AML && cbManufacturerParts.Checked)
                {
                    Manufacturer_Part_AML();
                }
                else if (!Properties.Settings.Default.USE_AML && cbManufacturerParts.Checked)
                {
                    Manufacturer_Part();
                }
                


                if (Properties.Settings.Default.USE_AML && cbPart.Checked)
                {
                    Part_AML();
                        
                }
                else if(!Properties.Settings.Default.USE_AML && cbPart.Checked )
                {
                    Part();
                }
                else if(!Properties.Settings.Default.USE_AML && cbPart.Checked )
                {
                    Part_edit();
                }

                if (Properties.Settings.Default.USE_AML && cbdevice.Checked)
                {
                    Device_AML();
                }
                else if (!Properties.Settings.Default.USE_AML && cbdevice.Checked)
                {
                    Device();
                }

                if(Properties.Settings.Default.USE_AML && cbPart_relation.Checked)
                {
                    Part_Relation();
                }

                if(Properties.Settings.Default.USE_AML && cbDevice_BOM.Checked)
                {
                    Device_BOM();
                }

            }

        }

        private void Excel_Text_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void cbBOM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpFd = new OpenFileDialog();
            this.timer1.Start();
            //OpFd.Filter = "JPG Files(";

            if(OpFd.ShowDialog() == DialogResult.OK)
            {
                string file_path = OpFd.FileName.ToString();
                attach_text_box.Text = file_path;

            }
            // yet to implemet if file upload status is true then progress bar should stop after the status is 200 and send message to tooltip as well
            //if (OpFd.Sh)
            //{
            //    this.timer1.Stop();
            //}
        }

       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            toolStripStatusLabel1.Text = "File Uploaded";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }
    }
}



