namespace RayTracing
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.renderDisplay = new System.Windows.Forms.PictureBox();
            this.sceneComboBox = new System.Windows.Forms.ComboBox();
            this.sceneLabel = new System.Windows.Forms.Label();
            this.renderLabel = new System.Windows.Forms.Label();
            this.renderComboBox = new System.Windows.Forms.ComboBox();
            this.shadingLabel = new System.Windows.Forms.Label();
            this.shadingComboBox = new System.Windows.Forms.ComboBox();
            this.renderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bvhCheckbox = new System.Windows.Forms.CheckBox();
            this.posXTrackbar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.posYTrackbar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.posZTrackbar = new System.Windows.Forms.TrackBar();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.focalLengthValueLabel = new System.Windows.Forms.Label();
            this.rotYValueLabel = new System.Windows.Forms.Label();
            this.rotXValueLabel = new System.Windows.Forms.Label();
            this.zValueLabel = new System.Windows.Forms.Label();
            this.yValueLabel = new System.Windows.Forms.Label();
            this.xValueLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.focalLengthTrackbar = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rotYTrackbar = new System.Windows.Forms.TrackBar();
            this.rotXTrackbar = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.shininessTrackbar = new System.Windows.Forms.TrackBar();
            this.materialSpecularBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.materialDiffuseBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.materialAmbientBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lightSpecularBox = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lightDiffuseBox = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lightAmbientBox = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lightsListBox = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.exportObjButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.renderProgressBar = new System.Windows.Forms.ProgressBar();
            this.renderBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.reportBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.shininessValueLabel = new System.Windows.Forms.Label();
            this.materialListBox = new System.Windows.Forms.ListBox();
            this.meshListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.renderDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posXTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posYTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posZTrackbar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focalLengthTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotYTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotXTrackbar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shininessTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialSpecularBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDiffuseBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialAmbientBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightSpecularBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightDiffuseBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightAmbientBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderDisplay
            // 
            this.renderDisplay.BackColor = System.Drawing.Color.Black;
            this.renderDisplay.Location = new System.Drawing.Point(0, 0);
            this.renderDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.renderDisplay.Name = "renderDisplay";
            this.renderDisplay.Size = new System.Drawing.Size(1280, 720);
            this.renderDisplay.TabIndex = 0;
            this.renderDisplay.TabStop = false;
            // 
            // sceneComboBox
            // 
            this.sceneComboBox.FormattingEnabled = true;
            this.sceneComboBox.Items.AddRange(new object[] {
            "Teapot",
            "Suzanne",
            "Textured Cube",
            "Sphere"});
            this.sceneComboBox.Location = new System.Drawing.Point(1356, 14);
            this.sceneComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.sceneComboBox.Name = "sceneComboBox";
            this.sceneComboBox.Size = new System.Drawing.Size(217, 21);
            this.sceneComboBox.TabIndex = 1;
            this.sceneComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // sceneLabel
            // 
            this.sceneLabel.AutoSize = true;
            this.sceneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneLabel.Location = new System.Drawing.Point(1284, 15);
            this.sceneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sceneLabel.Name = "sceneLabel";
            this.sceneLabel.Size = new System.Drawing.Size(55, 20);
            this.sceneLabel.TabIndex = 2;
            this.sceneLabel.Text = "Scene";
            this.sceneLabel.Click += new System.EventHandler(this.sceneLabel_Click);
            // 
            // renderLabel
            // 
            this.renderLabel.AutoSize = true;
            this.renderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renderLabel.Location = new System.Drawing.Point(1284, 43);
            this.renderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.renderLabel.Name = "renderLabel";
            this.renderLabel.Size = new System.Drawing.Size(62, 20);
            this.renderLabel.TabIndex = 3;
            this.renderLabel.Text = "Render";
            this.renderLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // renderComboBox
            // 
            this.renderComboBox.FormattingEnabled = true;
            this.renderComboBox.Items.AddRange(new object[] {
            "Preview",
            "Final"});
            this.renderComboBox.Location = new System.Drawing.Point(1356, 42);
            this.renderComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.renderComboBox.Name = "renderComboBox";
            this.renderComboBox.Size = new System.Drawing.Size(217, 21);
            this.renderComboBox.TabIndex = 4;
            this.renderComboBox.SelectedIndexChanged += new System.EventHandler(this.renderComboBox_SelectedIndexChanged);
            // 
            // shadingLabel
            // 
            this.shadingLabel.AutoSize = true;
            this.shadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shadingLabel.Location = new System.Drawing.Point(1284, 73);
            this.shadingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shadingLabel.Name = "shadingLabel";
            this.shadingLabel.Size = new System.Drawing.Size(68, 20);
            this.shadingLabel.TabIndex = 5;
            this.shadingLabel.Text = "Shading";
            // 
            // shadingComboBox
            // 
            this.shadingComboBox.FormattingEnabled = true;
            this.shadingComboBox.Items.AddRange(new object[] {
            "Flat",
            "Gouraud",
            "Phong"});
            this.shadingComboBox.Location = new System.Drawing.Point(1356, 72);
            this.shadingComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.shadingComboBox.Name = "shadingComboBox";
            this.shadingComboBox.Size = new System.Drawing.Size(217, 21);
            this.shadingComboBox.TabIndex = 6;
            this.shadingComboBox.SelectedIndexChanged += new System.EventHandler(this.shadingComboBox_SelectedIndexChanged);
            // 
            // renderButton
            // 
            this.renderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renderButton.Location = new System.Drawing.Point(1288, 657);
            this.renderButton.Margin = new System.Windows.Forms.Padding(2);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(88, 28);
            this.renderButton.TabIndex = 7;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(978, 441);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 8;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // bvhCheckbox
            // 
            this.bvhCheckbox.AutoSize = true;
            this.bvhCheckbox.Checked = true;
            this.bvhCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bvhCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bvhCheckbox.Location = new System.Drawing.Point(1285, 96);
            this.bvhCheckbox.Name = "bvhCheckbox";
            this.bvhCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bvhCheckbox.Size = new System.Drawing.Size(95, 24);
            this.bvhCheckbox.TabIndex = 10;
            this.bvhCheckbox.Text = "Use BVH";
            this.bvhCheckbox.UseVisualStyleBackColor = true;
            this.bvhCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // posXTrackbar
            // 
            this.posXTrackbar.Location = new System.Drawing.Point(116, 12);
            this.posXTrackbar.Maximum = 5;
            this.posXTrackbar.Minimum = -5;
            this.posXTrackbar.Name = "posXTrackbar";
            this.posXTrackbar.Size = new System.Drawing.Size(155, 45);
            this.posXTrackbar.TabIndex = 11;
            this.posXTrackbar.Scroll += new System.EventHandler(this.posXTrackbar_Scroll);
            this.posXTrackbar.ValueChanged += new System.EventHandler(this.posXTrackbar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pos X:";
            this.label2.Click += new System.EventHandler(this.label2_Click_3);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Pos Y:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // posYTrackbar
            // 
            this.posYTrackbar.Location = new System.Drawing.Point(116, 63);
            this.posYTrackbar.Maximum = 5;
            this.posYTrackbar.Minimum = -5;
            this.posYTrackbar.Name = "posYTrackbar";
            this.posYTrackbar.Size = new System.Drawing.Size(155, 45);
            this.posYTrackbar.TabIndex = 13;
            this.posYTrackbar.ValueChanged += new System.EventHandler(this.posYTrackbar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Pos Z:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // posZTrackbar
            // 
            this.posZTrackbar.Location = new System.Drawing.Point(116, 114);
            this.posZTrackbar.Minimum = 4;
            this.posZTrackbar.Name = "posZTrackbar";
            this.posZTrackbar.Size = new System.Drawing.Size(155, 45);
            this.posZTrackbar.TabIndex = 15;
            this.posZTrackbar.Value = 4;
            this.posZTrackbar.ValueChanged += new System.EventHandler(this.posZTrackbar_ValueChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(1386, 96);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox2.Size = new System.Drawing.Size(118, 24);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Draw Facets";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1288, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 526);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.focalLengthValueLabel);
            this.tabPage1.Controls.Add(this.rotYValueLabel);
            this.tabPage1.Controls.Add(this.rotXValueLabel);
            this.tabPage1.Controls.Add(this.zValueLabel);
            this.tabPage1.Controls.Add(this.yValueLabel);
            this.tabPage1.Controls.Add(this.xValueLabel);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.focalLengthTrackbar);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.rotYTrackbar);
            this.tabPage1.Controls.Add(this.rotXTrackbar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.posZTrackbar);
            this.tabPage1.Controls.Add(this.posXTrackbar);
            this.tabPage1.Controls.Add(this.posYTrackbar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(277, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Camera";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // focalLengthValueLabel
            // 
            this.focalLengthValueLabel.AutoSize = true;
            this.focalLengthValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focalLengthValueLabel.Location = new System.Drawing.Point(8, 292);
            this.focalLengthValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.focalLengthValueLabel.Name = "focalLengthValueLabel";
            this.focalLengthValueLabel.Size = new System.Drawing.Size(60, 20);
            this.focalLengthValueLabel.TabIndex = 28;
            this.focalLengthValueLabel.Text = "Value:";
            // 
            // rotYValueLabel
            // 
            this.rotYValueLabel.AutoSize = true;
            this.rotYValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotYValueLabel.Location = new System.Drawing.Point(6, 241);
            this.rotYValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rotYValueLabel.Name = "rotYValueLabel";
            this.rotYValueLabel.Size = new System.Drawing.Size(60, 20);
            this.rotYValueLabel.TabIndex = 27;
            this.rotYValueLabel.Text = "Value:";
            // 
            // rotXValueLabel
            // 
            this.rotXValueLabel.AutoSize = true;
            this.rotXValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotXValueLabel.Location = new System.Drawing.Point(8, 190);
            this.rotXValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rotXValueLabel.Name = "rotXValueLabel";
            this.rotXValueLabel.Size = new System.Drawing.Size(60, 20);
            this.rotXValueLabel.TabIndex = 26;
            this.rotXValueLabel.Text = "Value:";
            // 
            // zValueLabel
            // 
            this.zValueLabel.AutoSize = true;
            this.zValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zValueLabel.Location = new System.Drawing.Point(8, 139);
            this.zValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zValueLabel.Name = "zValueLabel";
            this.zValueLabel.Size = new System.Drawing.Size(60, 20);
            this.zValueLabel.TabIndex = 25;
            this.zValueLabel.Text = "Value:";
            // 
            // yValueLabel
            // 
            this.yValueLabel.AutoSize = true;
            this.yValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yValueLabel.Location = new System.Drawing.Point(7, 88);
            this.yValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yValueLabel.Name = "yValueLabel";
            this.yValueLabel.Size = new System.Drawing.Size(60, 20);
            this.yValueLabel.TabIndex = 24;
            this.yValueLabel.Text = "Value:";
            // 
            // xValueLabel
            // 
            this.xValueLabel.AutoSize = true;
            this.xValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xValueLabel.Location = new System.Drawing.Point(5, 37);
            this.xValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(60, 20);
            this.xValueLabel.TabIndex = 23;
            this.xValueLabel.Text = "Value:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 267);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 20);
            this.label15.TabIndex = 22;
            this.label15.Text = "Focal Length";
            // 
            // focalLengthTrackbar
            // 
            this.focalLengthTrackbar.Location = new System.Drawing.Point(116, 267);
            this.focalLengthTrackbar.Minimum = 1;
            this.focalLengthTrackbar.Name = "focalLengthTrackbar";
            this.focalLengthTrackbar.Size = new System.Drawing.Size(156, 45);
            this.focalLengthTrackbar.TabIndex = 21;
            this.focalLengthTrackbar.Value = 2;
            this.focalLengthTrackbar.ValueChanged += new System.EventHandler(this.focalLengthTrackbar_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 165);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Rot X:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 216);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "Rot Y:";
            // 
            // rotYTrackbar
            // 
            this.rotYTrackbar.Location = new System.Drawing.Point(116, 216);
            this.rotYTrackbar.Maximum = 90;
            this.rotYTrackbar.Minimum = -90;
            this.rotYTrackbar.Name = "rotYTrackbar";
            this.rotYTrackbar.Size = new System.Drawing.Size(156, 45);
            this.rotYTrackbar.SmallChange = 5;
            this.rotYTrackbar.TabIndex = 19;
            this.rotYTrackbar.ValueChanged += new System.EventHandler(this.rotYTrackbar_ValueChanged);
            // 
            // rotXTrackbar
            // 
            this.rotXTrackbar.LargeChange = 15;
            this.rotXTrackbar.Location = new System.Drawing.Point(116, 165);
            this.rotXTrackbar.Maximum = 90;
            this.rotXTrackbar.Minimum = -90;
            this.rotXTrackbar.Name = "rotXTrackbar";
            this.rotXTrackbar.Size = new System.Drawing.Size(155, 45);
            this.rotXTrackbar.SmallChange = 5;
            this.rotXTrackbar.TabIndex = 17;
            this.rotXTrackbar.ValueChanged += new System.EventHandler(this.rotXTrackbar_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.shininessValueLabel);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.shininessTrackbar);
            this.tabPage2.Controls.Add(this.materialSpecularBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.materialDiffuseBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.materialAmbientBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.materialListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(277, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Materials";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 223);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Shininess";
            // 
            // shininessTrackbar
            // 
            this.shininessTrackbar.Location = new System.Drawing.Point(94, 223);
            this.shininessTrackbar.Maximum = 64;
            this.shininessTrackbar.Minimum = 1;
            this.shininessTrackbar.Name = "shininessTrackbar";
            this.shininessTrackbar.Size = new System.Drawing.Size(177, 45);
            this.shininessTrackbar.TabIndex = 26;
            this.shininessTrackbar.Value = 1;
            this.shininessTrackbar.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // materialSpecularBox
            // 
            this.materialSpecularBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialSpecularBox.Location = new System.Drawing.Point(78, 165);
            this.materialSpecularBox.Name = "materialSpecularBox";
            this.materialSpecularBox.Size = new System.Drawing.Size(40, 40);
            this.materialSpecularBox.TabIndex = 25;
            this.materialSpecularBox.TabStop = false;
            this.materialSpecularBox.Click += new System.EventHandler(this.materialSpecularBox_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Specular";
            // 
            // materialDiffuseBox
            // 
            this.materialDiffuseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialDiffuseBox.Location = new System.Drawing.Point(78, 117);
            this.materialDiffuseBox.Name = "materialDiffuseBox";
            this.materialDiffuseBox.Size = new System.Drawing.Size(40, 40);
            this.materialDiffuseBox.TabIndex = 23;
            this.materialDiffuseBox.TabStop = false;
            this.materialDiffuseBox.Click += new System.EventHandler(this.materialDiffuseBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 127);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Diffuse";
            // 
            // materialAmbientBox
            // 
            this.materialAmbientBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialAmbientBox.Location = new System.Drawing.Point(78, 68);
            this.materialAmbientBox.Name = "materialAmbientBox";
            this.materialAmbientBox.Size = new System.Drawing.Size(40, 40);
            this.materialAmbientBox.TabIndex = 21;
            this.materialAmbientBox.TabStop = false;
            this.materialAmbientBox.Click += new System.EventHandler(this.materialAmbientBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Ambient";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 20;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lightSpecularBox);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.lightDiffuseBox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.lightAmbientBox);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.lightsListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(277, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lights";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lightSpecularBox
            // 
            this.lightSpecularBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightSpecularBox.Location = new System.Drawing.Point(77, 165);
            this.lightSpecularBox.Name = "lightSpecularBox";
            this.lightSpecularBox.Size = new System.Drawing.Size(40, 40);
            this.lightSpecularBox.TabIndex = 32;
            this.lightSpecularBox.TabStop = false;
            this.lightSpecularBox.Click += new System.EventHandler(this.lightSpecularBox_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 175);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "Specular";
            // 
            // lightDiffuseBox
            // 
            this.lightDiffuseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightDiffuseBox.Location = new System.Drawing.Point(77, 117);
            this.lightDiffuseBox.Name = "lightDiffuseBox";
            this.lightDiffuseBox.Size = new System.Drawing.Size(40, 40);
            this.lightDiffuseBox.TabIndex = 30;
            this.lightDiffuseBox.TabStop = false;
            this.lightDiffuseBox.Click += new System.EventHandler(this.lightDiffuseBox_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 127);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Diffuse";
            // 
            // lightAmbientBox
            // 
            this.lightAmbientBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightAmbientBox.Location = new System.Drawing.Point(77, 68);
            this.lightAmbientBox.Name = "lightAmbientBox";
            this.lightAmbientBox.Size = new System.Drawing.Size(40, 40);
            this.lightAmbientBox.TabIndex = 28;
            this.lightAmbientBox.TabStop = false;
            this.lightAmbientBox.Click += new System.EventHandler(this.lightAmbientBox_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Ambient";
            // 
            // lightsListBox
            // 
            this.lightsListBox.FormattingEnabled = true;
            this.lightsListBox.Location = new System.Drawing.Point(6, 6);
            this.lightsListBox.Name = "lightsListBox";
            this.lightsListBox.Size = new System.Drawing.Size(264, 56);
            this.lightsListBox.TabIndex = 26;
            this.lightsListBox.SelectedIndexChanged += new System.EventHandler(this.lightsListBox_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.meshListBox);
            this.tabPage4.Controls.Add(this.exportObjButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(277, 500);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Meshes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // exportObjButton
            // 
            this.exportObjButton.Location = new System.Drawing.Point(6, 72);
            this.exportObjButton.Name = "exportObjButton";
            this.exportObjButton.Size = new System.Drawing.Size(87, 30);
            this.exportObjButton.TabIndex = 0;
            this.exportObjButton.Text = "Export as .obj";
            this.exportObjButton.UseVisualStyleBackColor = true;
            this.exportObjButton.Click += new System.EventHandler(this.exportObjButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1380, 657);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 28);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // renderProgressBar
            // 
            this.renderProgressBar.Location = new System.Drawing.Point(1450, 658);
            this.renderProgressBar.Name = "renderProgressBar";
            this.renderProgressBar.Size = new System.Drawing.Size(123, 26);
            this.renderProgressBar.TabIndex = 21;
            // 
            // renderBackgroundWorker
            // 
            this.renderBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.renderBackgroundWorker_ProgressChanged);
            this.renderBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.renderBackgroundWorker_RunWorkerCompleted);
            // 
            // reportBackgroundWorker
            // 
            this.reportBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.reportBackgroundWorker_RunWorkerCompleted);
            // 
            // shininessValueLabel
            // 
            this.shininessValueLabel.AutoSize = true;
            this.shininessValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shininessValueLabel.Location = new System.Drawing.Point(5, 243);
            this.shininessValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shininessValueLabel.Name = "shininessValueLabel";
            this.shininessValueLabel.Size = new System.Drawing.Size(60, 20);
            this.shininessValueLabel.TabIndex = 28;
            this.shininessValueLabel.Text = "Value:";
            // 
            // materialListBox
            // 
            this.materialListBox.FormattingEnabled = true;
            this.materialListBox.Location = new System.Drawing.Point(7, 6);
            this.materialListBox.Name = "materialListBox";
            this.materialListBox.Size = new System.Drawing.Size(264, 56);
            this.materialListBox.TabIndex = 0;
            this.materialListBox.SelectedIndexChanged += new System.EventHandler(this.materialListBox_SelectedIndexChanged);
            // 
            // meshListBox
            // 
            this.meshListBox.FormattingEnabled = true;
            this.meshListBox.Location = new System.Drawing.Point(7, 7);
            this.meshListBox.Name = "meshListBox";
            this.meshListBox.Size = new System.Drawing.Size(264, 56);
            this.meshListBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1584, 696);
            this.Controls.Add(this.renderProgressBar);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.bvhCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.shadingComboBox);
            this.Controls.Add(this.shadingLabel);
            this.Controls.Add(this.renderComboBox);
            this.Controls.Add(this.renderLabel);
            this.Controls.Add(this.sceneLabel);
            this.Controls.Add(this.sceneComboBox);
            this.Controls.Add(this.renderDisplay);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Raytracer by Damian H.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.renderDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posXTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posYTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posZTrackbar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focalLengthTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotYTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotXTrackbar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shininessTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialSpecularBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDiffuseBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialAmbientBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightSpecularBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightDiffuseBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightAmbientBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox renderDisplay;
        private System.Windows.Forms.ComboBox sceneComboBox;
        private System.Windows.Forms.Label sceneLabel;
        private System.Windows.Forms.Label renderLabel;
        private System.Windows.Forms.ComboBox renderComboBox;
        private System.Windows.Forms.Label shadingLabel;
        private System.Windows.Forms.ComboBox shadingComboBox;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox bvhCheckbox;
        private System.Windows.Forms.TrackBar posXTrackbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar posYTrackbar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar posZTrackbar;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar shininessTrackbar;
        private System.Windows.Forms.PictureBox materialSpecularBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox materialDiffuseBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox materialAmbientBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar focalLengthTrackbar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar rotYTrackbar;
        private System.Windows.Forms.TrackBar rotXTrackbar;
        private System.Windows.Forms.PictureBox lightSpecularBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox lightDiffuseBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox lightAmbientBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lightsListBox;
        private System.Windows.Forms.Label focalLengthValueLabel;
        private System.Windows.Forms.Label rotYValueLabel;
        private System.Windows.Forms.Label rotXValueLabel;
        private System.Windows.Forms.Label zValueLabel;
        private System.Windows.Forms.Label yValueLabel;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ProgressBar renderProgressBar;
        private System.ComponentModel.BackgroundWorker renderBackgroundWorker;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button exportObjButton;
        private System.ComponentModel.BackgroundWorker reportBackgroundWorker;
        private System.Windows.Forms.Label shininessValueLabel;
        private System.Windows.Forms.ListBox materialListBox;
        private System.Windows.Forms.ListBox meshListBox;
    }
}

