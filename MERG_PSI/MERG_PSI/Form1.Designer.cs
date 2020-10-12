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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.showAdList = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel4 = new System.Windows.Forms.Panel();
            this.search = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.search);
            this.panel2.Controls.Add(this.showAdList);
            this.panel2.Controls.Add(this.panel3);
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
            this.panel2.Location = new System.Drawing.Point(0, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 950);
            this.panel2.TabIndex = 0;
            // 
            // showAdList
            // 
            this.showAdList.BackColor = System.Drawing.Color.Transparent;
            this.showAdList.Location = new System.Drawing.Point(74, 874);
            this.showAdList.Name = "showAdList";
            this.showAdList.Size = new System.Drawing.Size(141, 47);
            this.showAdList.TabIndex = 1;
            this.showAdList.Text = "Rodyti sąrašą";
            this.showAdList.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(21, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 278);
            this.panel3.TabIndex = 2;
            // 
            // advSearch
            // 
            this.advSearch.BackColor = System.Drawing.Color.Transparent;
            this.advSearch.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.advSearch.ForeColor = System.Drawing.Color.Black;
            this.advSearch.Location = new System.Drawing.Point(46, 377);
            this.advSearch.Name = "advSearch";
            this.advSearch.Size = new System.Drawing.Size(182, 42);
            this.advSearch.TabIndex = 4;
            this.advSearch.Text = "Detali paieška";
            this.advSearch.UseVisualStyleBackColor = false;
            this.advSearch.Click += new System.EventHandler(this.advSearch_Click);
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
            "Nadruvos g. ",
            "V. Nagevičiaus g. ",
            "Nakvišų g. ",
            "T. Narbuto g. ",
            "Naručio g. ",
            "Stanislovo Narutavičiaus g. ",
            "Nasturtų g. ",
            "Naugarduko g. ",
            "Naujakiemio g. ",
            "Naujakurių g. ",
            "Naujakurių g. ",
            "Naujakurių g. ",
            "Naujakurių g. ",
            "Naujakurių g. ",
            "Naujanerių g. ",
            "Naujanerių Sodų 1-oji g. ",
            "Naujanerių Sodų 2-oji g. ",
            "Naujanerių Sodų 3-ioji g.",
            "Naujanerių Sodų 4-oji g. ",
            "Naujanerių Sodų 5-oji g. ",
            "Naujanerių Sodų 6-oji g. ",
            "Naujanerių Sodų 7-oji g. ",
            "Adutiškio g.",
            "Afindevičių g. ",
            "Agrastų g. ",
            "Aguonų g. ",
            "Aido g. ",
            "Aidukaičių g.",
            "Airių g. ",
            "Jono Aisčio g. ",
            "Aismarių g. ",
            "Aitvarų g. ",
            "Ajerų g. ",
            "Akacijų g. ",
            "Akademijos g. ",
            "Akmenės g. ",
            "Akmenų g. ",
            "Alantos g. ",
            "Algirdo g. ",
            "Alytaus g. ",
            "Alko g. ",
            "Alksnyno g.",
            "Antavilių Sodų 1-oji g. ",
            "Antavilių Sodų 2-oji g.",
            "Antavilių Sodų 3-ioji g.",
            "Antavilių Sodų 4-oji g.",
            "Antavilių Sodų 5-oji g.",
            "Antavilių Sodų 6-oji g.",
            "Antavilių Sodų 7-oji g.",
            "Antavilių Sodų 8-oji g. ",
            "Antavilių Sodų 9-oji g. ",
            "Antavilių Sodų 10-oji g.",
            "Antavilių Sodų 11-oji g.",
            "Antavilių Sodų 12-oji g.",
            "Antežerių g. ",
            "M. Antokolskio g.",
            "Edinburgo g. ",
            "Eglinės Sodų g. ",
            "Eglinės Sodų 1-oji g. ",
            "Eglinės Sodų 2-oji g. ",
            "Eglinės Sodų 3-ioji g.",
            "Eglinės Sodų 4-oji g. ",
            "Eglinės Sodų 5-oji g. ",
            "Eglinės Sodų 6-oji g. ",
            "Eglinės Sodų 7-oji g. ",
            "Basanavičiaus g.",
            "Pievų g.",
            "Sodų g."});
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
            "",
            "Alytaus m.",
            "Alytaus r.",
            "Anykščių r.",
            "Birštono",
            "Biržų r.",
            "Druskininkų",
            "Elektrėnų",
            "Ignalinos r.",
            "Jonavos r.",
            "Joniškio r.",
            "Jurbarko r.",
            "Kaišiadorių r.",
            "Kalvarijos",
            "Kauno m.",
            "Kauno r.",
            "Kazlų Rūdos",
            "Kelmės r.",
            "Kėdainių r.",
            "Klaipėdos m.",
            "Klaipėdos r.",
            "Kretingos r.",
            "Kupiškio r.",
            "Lazdijų r.",
            "Marijampolės",
            "Mažeikių r.",
            "Molėtų r.",
            "Neringos",
            "Pagėgių",
            "Pakruojo r.",
            "Palangos m.",
            "Panevėžio m.",
            "Panevėžio r.",
            "Pasvalio r.",
            "Plungės r.",
            "Prienų r.",
            "Radviliškio r.",
            "Raseinių r.",
            "Rietavo",
            "Rokiškio r.",
            "Skuodo r.",
            "Šakių r.",
            "Šalčininkų r.",
            "Šiaulių m.",
            "Šiaulių r.",
            "Šilalės r.",
            "Šilutės r.",
            "Širvintų r.",
            "Švenčionių r.",
            "Tauragės r.",
            "Telšių r.",
            "Trakų r.",
            "Ukmergės r.",
            "Utenos r.",
            "Varėnos r.",
            "Vilkaviškio r.",
            "Vilniaus m.",
            "Vilniaus r.",
            "Visagino m.",
            "Zarasų r."});
            this.municipality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.municipality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.municipality.Location = new System.Drawing.Point(46, 126);
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
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(42, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Plotas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(41, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kaina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(41, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gatvė";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(42, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Savivaldybė";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(42, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Objekto tipas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "MERG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1602, 91);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 91);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser2);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1602, 959);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 1;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(0, 0);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1270, 927);
            this.webBrowser2.TabIndex = 2;
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1270, 927);
            this.webBrowser1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 927);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1270, 32);
            this.panel4.TabIndex = 0;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(74, 802);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(141, 49);
            this.search.TabIndex = 5;
            this.search.Text = "Ieškoti";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1602, 1050);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button advSearch;
        private System.Windows.Forms.TextBox priceTo;
        private System.Windows.Forms.TextBox areaTo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox areaFrom;
        private System.Windows.Forms.TextBox priceFrom;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.TextBox municipality;
        private System.Windows.Forms.ComboBox objTipe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showAdList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button search;
    }
}

