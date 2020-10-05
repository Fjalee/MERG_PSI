namespace MERG_PSI
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.advSearch = new System.Windows.Forms.Button();
            this.priceTo = new System.Windows.Forms.TextBox();
            this.areaTo = new System.Windows.Forms.TextBox();
            this.areaFrom = new System.Windows.Forms.TextBox();
            this.priceFrom = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.municipality = new System.Windows.Forms.TextBox();
            this.objTipe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "MERG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(27, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 723);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advSearch);
            this.panel2.Controls.Add(this.priceTo);
            this.panel2.Controls.Add(this.areaTo);
            this.panel2.Controls.Add(this.areaFrom);
            this.panel2.Controls.Add(this.priceFrom);
            this.panel2.Controls.Add(this.street);
            this.panel2.Controls.Add(this.municipality);
            this.panel2.Controls.Add(this.objTipe);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(27, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 720);
            this.panel2.TabIndex = 0;
            // 
            // advSearch
            // 
            this.advSearch.Location = new System.Drawing.Point(46, 377);
            this.advSearch.Name = "advSearch";
            this.advSearch.Size = new System.Drawing.Size(182, 42);
            this.advSearch.TabIndex = 4;
            this.advSearch.Text = "Detali paieška";
            this.advSearch.UseVisualStyleBackColor = true;
            // 
            // priceTo
            // 
            this.priceTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.priceTo.Location = new System.Drawing.Point(140, 256);
            this.priceTo.Name = "priceTo";
            this.priceTo.Size = new System.Drawing.Size(88, 26);
            this.priceTo.TabIndex = 3;
            this.priceTo.Text = "Iki";
            this.priceTo.Enter += new System.EventHandler(this.priceTo_Enter);
            this.priceTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTo_KeyPress);
            this.priceTo.Leave += new System.EventHandler(this.priceTo_Leave);
            // 
            // areaTo
            // 
            this.areaTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.areaTo.Location = new System.Drawing.Point(140, 321);
            this.areaTo.Name = "areaTo";
            this.areaTo.Size = new System.Drawing.Size(88, 26);
            this.areaTo.TabIndex = 3;
            this.areaTo.Text = "Iki";
            this.areaTo.Enter += new System.EventHandler(this.areaTo_Enter);
            this.areaTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.areaTo_KeyPress);
            this.areaTo.Leave += new System.EventHandler(this.areaTo_Leave);
            // 
            // areaFrom
            // 
            this.areaFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.areaFrom.Location = new System.Drawing.Point(46, 321);
            this.areaFrom.Name = "areaFrom";
            this.areaFrom.Size = new System.Drawing.Size(88, 26);
            this.areaFrom.TabIndex = 3;
            this.areaFrom.Text = "Nuo";
            this.areaFrom.Enter += new System.EventHandler(this.areaFrom_Enter);
            this.areaFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.areaFrom_KeyPress);
            this.areaFrom.Leave += new System.EventHandler(this.areaFrom_Leave);
            // 
            // priceFrom
            // 
            this.priceFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.priceFrom.Location = new System.Drawing.Point(46, 256);
            this.priceFrom.Name = "priceFrom";
            this.priceFrom.Size = new System.Drawing.Size(88, 26);
            this.priceFrom.TabIndex = 3;
            this.priceFrom.Text = "Nuo";
            this.priceFrom.Enter += new System.EventHandler(this.priceFrom_Enter);
            this.priceFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceFrom_KeyPress);
            this.priceFrom.Leave += new System.EventHandler(this.priceFrom_Leave);
            // 
            // street
            // 
            this.street.AutoCompleteCustomSource.AddRange(new string[] {
            "Basanavčiaus g.",
            "Geležinio vilko g.",
            "Pievų g. ",
            "Gėlių g. "});
            this.street.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.street.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.street.Location = new System.Drawing.Point(46, 192);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(182, 26);
            this.street.TabIndex = 2;
            this.street.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.street_KeyPress);
            // 
            // municipality
            // 
            this.municipality.AutoCompleteCustomSource.AddRange(new string[] {
            "Vilnius",
            "Kaunas",
            "Klaipėda",
            "Šiauliai",
            "Panebežys",
            "Vilkaviškis",
            "Alytus"});
            this.municipality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.municipality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.municipality.Location = new System.Drawing.Point(46, 130);
            this.municipality.Name = "municipality";
            this.municipality.Size = new System.Drawing.Size(182, 26);
            this.municipality.TabIndex = 2;
            this.municipality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.municipality_KeyPress);
            // 
            // objTipe
            // 
            this.objTipe.Cursor = System.Windows.Forms.Cursors.Default;
            this.objTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objTipe.FormattingEnabled = true;
            this.objTipe.Items.AddRange(new object[] {
            "Butas pardavimui",
            "Butas nuomai",
            "Namas pardavimui",
            "Namas nuomai",
            "Patalpos pardavimui",
            "Patalpos nuomai",
            "Sklypas pardavimui",
            "Sklypas nuomai"});
            this.objTipe.Location = new System.Drawing.Point(46, 66);
            this.objTipe.Name = "objTipe";
            this.objTipe.Size = new System.Drawing.Size(182, 28);
            this.objTipe.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Plotas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kaina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gatvė";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Savivaldybė";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Objekto tipas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(715, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "MAP?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1118, 842);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Rodyti sąrašą";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 910);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox objTipe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button advSearch;
        private System.Windows.Forms.TextBox priceTo;
        private System.Windows.Forms.TextBox areaTo;
        private System.Windows.Forms.TextBox areaFrom;
        private System.Windows.Forms.TextBox priceFrom;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.TextBox municipality;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}

