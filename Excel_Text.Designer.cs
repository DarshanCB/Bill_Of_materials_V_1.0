using Microsoft.Office.Interop.Excel;

namespace BOM_Importer
{
    partial class Excel_Text
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Excel_Text));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbBOMFilename = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNoOfDeviceBOM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNoOfDevice = new System.Windows.Forms.TextBox();
            this.tbNoOfPartAML = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNoOfParts = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNoOfManufacturerParts = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNoOfManufacturers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbdevice = new System.Windows.Forms.CheckBox();
            this.cbPart = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbDevice_BOM = new System.Windows.Forms.CheckBox();
            this.cbPart_relation = new System.Windows.Forms.CheckBox();
            this.cbManufacturerParts = new System.Windows.Forms.CheckBox();
            this.cbManufacturers = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.attach_text_box = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbBOMFilename
            // 
            this.tbBOMFilename.Location = new System.Drawing.Point(77, 22);
            this.tbBOMFilename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbBOMFilename.Name = "tbBOMFilename";
            this.tbBOMFilename.ReadOnly = true;
            this.tbBOMFilename.Size = new System.Drawing.Size(365, 22);
            this.tbBOMFilename.TabIndex = 1;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1071, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 62);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAboutToolStripMenuItem,
            this.helpFormToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showAboutToolStripMenuItem
            // 
            this.showAboutToolStripMenuItem.Name = "showAboutToolStripMenuItem";
            this.showAboutToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.showAboutToolStripMenuItem.Text = "About";
            this.showAboutToolStripMenuItem.Click += new System.EventHandler(this.ShowHelpToolStripMenuItem_Click);
            // 
            // helpFormToolStripMenuItem
            // 
            this.helpFormToolStripMenuItem.Name = "helpFormToolStripMenuItem";
            this.helpFormToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.helpFormToolStripMenuItem.Text = "HelpForm";
            this.helpFormToolStripMenuItem.Click += new System.EventHandler(this.HelpFormToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1482, 25);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(37, 55);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(180, 39);
            this.button7.TabIndex = 27;
            this.button7.Text = "Select BOM File";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbNoOfDeviceBOM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbNoOfDevice);
            this.groupBox1.Controls.Add(this.tbNoOfPartAML);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNoOfParts);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbNoOfManufacturerParts);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNoOfManufacturers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbBOMFilename);
            this.groupBox1.Location = new System.Drawing.Point(617, 208);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(451, 354);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 215);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "device";
            // 
            // tbNoOfDeviceBOM
            // 
            this.tbNoOfDeviceBOM.BackColor = System.Drawing.SystemColors.Control;
            this.tbNoOfDeviceBOM.Location = new System.Drawing.Point(164, 254);
            this.tbNoOfDeviceBOM.Name = "tbNoOfDeviceBOM";
            this.tbNoOfDeviceBOM.Size = new System.Drawing.Size(231, 22);
            this.tbNoOfDeviceBOM.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "device BOM";
            // 
            // tbNoOfDevice
            // 
            this.tbNoOfDevice.BackColor = System.Drawing.SystemColors.Control;
            this.tbNoOfDevice.Location = new System.Drawing.Point(164, 215);
            this.tbNoOfDevice.Name = "tbNoOfDevice";
            this.tbNoOfDevice.Size = new System.Drawing.Size(231, 22);
            this.tbNoOfDevice.TabIndex = 12;
            // 
            // tbNoOfPartAML
            // 
            this.tbNoOfPartAML.BackColor = System.Drawing.SystemColors.Control;
            this.tbNoOfPartAML.Location = new System.Drawing.Point(164, 177);
            this.tbNoOfPartAML.Name = "tbNoOfPartAML";
            this.tbNoOfPartAML.Size = new System.Drawing.Size(231, 22);
            this.tbNoOfPartAML.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "part relation";
            // 
            // tbNoOfParts
            // 
            this.tbNoOfParts.Location = new System.Drawing.Point(164, 144);
            this.tbNoOfParts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNoOfParts.Name = "tbNoOfParts";
            this.tbNoOfParts.ReadOnly = true;
            this.tbNoOfParts.Size = new System.Drawing.Size(231, 22);
            this.tbNoOfParts.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "parts";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbNoOfManufacturerParts
            // 
            this.tbNoOfManufacturerParts.Location = new System.Drawing.Point(164, 107);
            this.tbNoOfManufacturerParts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNoOfManufacturerParts.Name = "tbNoOfManufacturerParts";
            this.tbNoOfManufacturerParts.ReadOnly = true;
            this.tbNoOfManufacturerParts.Size = new System.Drawing.Size(231, 22);
            this.tbNoOfManufacturerParts.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "manufacturer parts";
            // 
            // tbNoOfManufacturers
            // 
            this.tbNoOfManufacturers.Location = new System.Drawing.Point(164, 70);
            this.tbNoOfManufacturers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNoOfManufacturers.Name = "tbNoOfManufacturers";
            this.tbNoOfManufacturers.ReadOnly = true;
            this.tbNoOfManufacturers.Size = new System.Drawing.Size(231, 22);
            this.tbNoOfManufacturers.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "manufacturers";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "BOM file";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbdevice);
            this.groupBox2.Controls.Add(this.cbPart);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.cbDevice_BOM);
            this.groupBox2.Controls.Add(this.cbPart_relation);
            this.groupBox2.Controls.Add(this.cbManufacturerParts);
            this.groupBox2.Controls.Add(this.cbManufacturers);
            this.groupBox2.Location = new System.Drawing.Point(37, 208);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(547, 298);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import";
            // 
            // cbdevice
            // 
            this.cbdevice.AutoSize = true;
            this.cbdevice.Location = new System.Drawing.Point(8, 158);
            this.cbdevice.Name = "cbdevice";
            this.cbdevice.Size = new System.Drawing.Size(71, 21);
            this.cbdevice.TabIndex = 30;
            this.cbdevice.Text = "device";
            this.cbdevice.UseVisualStyleBackColor = true;
            // 
            // cbPart
            // 
            this.cbPart.AutoSize = true;
            this.cbPart.Location = new System.Drawing.Point(8, 97);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(62, 21);
            this.cbPart.TabIndex = 29;
            this.cbPart.Text = "parts";
            this.cbPart.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(360, 252);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(180, 39);
            this.btnImport.TabIndex = 28;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // cbDevice_BOM
            // 
            this.cbDevice_BOM.AutoSize = true;
            this.cbDevice_BOM.Location = new System.Drawing.Point(8, 186);
            this.cbDevice_BOM.Margin = new System.Windows.Forms.Padding(4);
            this.cbDevice_BOM.Name = "cbDevice_BOM";
            this.cbDevice_BOM.Size = new System.Drawing.Size(106, 21);
            this.cbDevice_BOM.TabIndex = 3;
            this.cbDevice_BOM.Text = "device BOM";
            this.cbDevice_BOM.UseVisualStyleBackColor = true;
            this.cbDevice_BOM.CheckedChanged += new System.EventHandler(this.cbBOM_CheckedChanged);
            // 
            // cbPart_relation
            // 
            this.cbPart_relation.AutoSize = true;
            this.cbPart_relation.Location = new System.Drawing.Point(8, 125);
            this.cbPart_relation.Margin = new System.Windows.Forms.Padding(4);
            this.cbPart_relation.Name = "cbPart_relation";
            this.cbPart_relation.Size = new System.Drawing.Size(282, 21);
            this.cbPart_relation.TabIndex = 2;
            this.cbPart_relation.Text = "parts incl. relation to manufacturer parts";
            this.cbPart_relation.UseVisualStyleBackColor = true;
            // 
            // cbManufacturerParts
            // 
            this.cbManufacturerParts.AutoSize = true;
            this.cbManufacturerParts.Location = new System.Drawing.Point(8, 65);
            this.cbManufacturerParts.Margin = new System.Windows.Forms.Padding(4);
            this.cbManufacturerParts.Name = "cbManufacturerParts";
            this.cbManufacturerParts.Size = new System.Drawing.Size(150, 21);
            this.cbManufacturerParts.TabIndex = 1;
            this.cbManufacturerParts.Text = "manufacturer parts";
            this.cbManufacturerParts.UseVisualStyleBackColor = true;
            // 
            // cbManufacturers
            // 
            this.cbManufacturers.AutoSize = true;
            this.cbManufacturers.Location = new System.Drawing.Point(8, 37);
            this.cbManufacturers.Margin = new System.Windows.Forms.Padding(4);
            this.cbManufacturers.Name = "cbManufacturers";
            this.cbManufacturers.Size = new System.Drawing.Size(121, 21);
            this.cbManufacturers.TabIndex = 0;
            this.cbManufacturers.Text = "manufacturers";
            this.cbManufacturers.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 22);
            this.button1.TabIndex = 30;
            this.button1.Text = "File_Image_Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // attach_text_box
            // 
            this.attach_text_box.BackColor = System.Drawing.SystemColors.Control;
            this.attach_text_box.Location = new System.Drawing.Point(274, 139);
            this.attach_text_box.Name = "attach_text_box";
            this.attach_text_box.Size = new System.Drawing.Size(499, 22);
            this.attach_text_box.TabIndex = 33;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(816, 138);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(222, 23);
            this.progressBar1.TabIndex = 34;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Excel_Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1482, 703);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.attach_text_box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Excel_Text";
            this.Text = "BOM Importer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Excel_Text_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbBOMFilename;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem helpFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.TextBox tbNoOfParts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNoOfManufacturerParts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNoOfManufacturers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cbDevice_BOM;
        private System.Windows.Forms.CheckBox cbPart_relation;
        private System.Windows.Forms.CheckBox cbManufacturerParts;
        private System.Windows.Forms.CheckBox cbManufacturers;
        private System.Windows.Forms.CheckBox cbPart;
        private System.Windows.Forms.TextBox tbNoOfDevice;
        private System.Windows.Forms.TextBox tbNoOfPartAML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbdevice;
        private System.Windows.Forms.TextBox tbNoOfDeviceBOM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox attach_text_box;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label8;
    }
}