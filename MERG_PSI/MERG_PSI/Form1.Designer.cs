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
            this.noInfoRoomNumber = new System.Windows.Forms.CheckBox();
            this.numberOfRoomsTo = new System.Windows.Forms.TextBox();
            this.numberOfRoomsFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.noInfoBuildYear = new System.Windows.Forms.CheckBox();
            this.buildYearTo = new System.Windows.Forms.TextBox();
            this.buildYearFrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pricePerSqMTo = new System.Windows.Forms.TextBox();
            this.pricePerSqMFrom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.showAdList = new System.Windows.Forms.Button();
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
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.noInfoRoomNumber);
            this.panel2.Controls.Add(this.numberOfRoomsTo);
            this.panel2.Controls.Add(this.numberOfRoomsFrom);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.noInfoBuildYear);
            this.panel2.Controls.Add(this.buildYearTo);
            this.panel2.Controls.Add(this.buildYearFrom);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.pricePerSqMTo);
            this.panel2.Controls.Add(this.pricePerSqMFrom);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.search);
            this.panel2.Controls.Add(this.showAdList);
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
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 617);
            this.panel2.TabIndex = 0;
            // 
            // noInfoRoomNumber
            // 
            this.noInfoRoomNumber.AutoSize = true;
            this.noInfoRoomNumber.BackColor = System.Drawing.Color.Transparent;
            this.noInfoRoomNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.noInfoRoomNumber.Location = new System.Drawing.Point(141, 334);
            this.noInfoRoomNumber.Name = "noInfoRoomNumber";
            this.noInfoRoomNumber.Size = new System.Drawing.Size(81, 17);
            this.noInfoRoomNumber.TabIndex = 16;
            this.noInfoRoomNumber.Text = "Nenurodyta";
            this.noInfoRoomNumber.UseVisualStyleBackColor = false;
            // 
            // numberOfRoomsTo
            // 
            this.numberOfRoomsTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.numberOfRoomsTo.Location = new System.Drawing.Point(76, 331);
            this.numberOfRoomsTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numberOfRoomsTo.Name = "numberOfRoomsTo";
            this.numberOfRoomsTo.Size = new System.Drawing.Size(60, 20);
            this.numberOfRoomsTo.TabIndex = 15;
            this.numberOfRoomsTo.Text = "Iki";
            this.numberOfRoomsTo.Enter += new System.EventHandler(this.NumberOfRoomsTo_Enter);
            this.numberOfRoomsTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOfRoomsTo_KeyPress);
            this.numberOfRoomsTo.Leave += new System.EventHandler(this.NumberOfRoomsTo_Leave);
            // 
            // numberOfRoomsFrom
            // 
            this.numberOfRoomsFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.numberOfRoomsFrom.Location = new System.Drawing.Point(15, 331);
            this.numberOfRoomsFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numberOfRoomsFrom.Name = "numberOfRoomsFrom";
            this.numberOfRoomsFrom.Size = new System.Drawing.Size(60, 20);
            this.numberOfRoomsFrom.TabIndex = 14;
            this.numberOfRoomsFrom.Text = "Nuo";
            this.numberOfRoomsFrom.Enter += new System.EventHandler(this.NumberOfRoomsFrom_Enter);
            this.numberOfRoomsFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOfRoomsFrom_KeyPress);
            this.numberOfRoomsFrom.Leave += new System.EventHandler(this.NumberOfRoomsFrom_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(12, 312);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Kambarių skaičius";
            // 
            // noInfoBuildYear
            // 
            this.noInfoBuildYear.AutoSize = true;
            this.noInfoBuildYear.BackColor = System.Drawing.Color.Transparent;
            this.noInfoBuildYear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.noInfoBuildYear.Location = new System.Drawing.Point(141, 292);
            this.noInfoBuildYear.Name = "noInfoBuildYear";
            this.noInfoBuildYear.Size = new System.Drawing.Size(81, 17);
            this.noInfoBuildYear.TabIndex = 12;
            this.noInfoBuildYear.Text = "Nenurodyta";
            this.noInfoBuildYear.UseVisualStyleBackColor = false;
            // 
            // buildYearTo
            // 
            this.buildYearTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.buildYearTo.Location = new System.Drawing.Point(76, 290);
            this.buildYearTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buildYearTo.Name = "buildYearTo";
            this.buildYearTo.Size = new System.Drawing.Size(60, 20);
            this.buildYearTo.TabIndex = 11;
            this.buildYearTo.Text = "Iki";
            this.buildYearTo.Enter += new System.EventHandler(this.BuildYearTo_Enter);
            this.buildYearTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BuildYearTo_KeyPress);
            this.buildYearTo.Leave += new System.EventHandler(this.BuildYearTo_Leave);
            // 
            // buildYearFrom
            // 
            this.buildYearFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.buildYearFrom.Location = new System.Drawing.Point(14, 290);
            this.buildYearFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buildYearFrom.Name = "buildYearFrom";
            this.buildYearFrom.Size = new System.Drawing.Size(60, 20);
            this.buildYearFrom.TabIndex = 10;
            this.buildYearFrom.Text = "Nuo";
            this.buildYearFrom.Enter += new System.EventHandler(this.BuildYearFrom_Enter);
            this.buildYearFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BuildYearFrom_KeyPress);
            this.buildYearFrom.Leave += new System.EventHandler(this.BuildYearFrom_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(12, 271);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Pastatymo metai";
            // 
            // pricePerSqMTo
            // 
            this.pricePerSqMTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.pricePerSqMTo.Location = new System.Drawing.Point(76, 249);
            this.pricePerSqMTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pricePerSqMTo.Name = "pricePerSqMTo";
            this.pricePerSqMTo.Size = new System.Drawing.Size(60, 20);
            this.pricePerSqMTo.TabIndex = 8;
            this.pricePerSqMTo.Text = "Iki";
            this.pricePerSqMTo.Enter += new System.EventHandler(this.PricePerSqMTo_Enter);
            this.pricePerSqMTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PricePerSqMTo_KeyPress);
            this.pricePerSqMTo.Leave += new System.EventHandler(this.PricePerSqMTo_Leave);
            // 
            // pricePerSqMFrom
            // 
            this.pricePerSqMFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.pricePerSqMFrom.Location = new System.Drawing.Point(14, 249);
            this.pricePerSqMFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pricePerSqMFrom.Name = "pricePerSqMFrom";
            this.pricePerSqMFrom.Size = new System.Drawing.Size(60, 20);
            this.pricePerSqMFrom.TabIndex = 7;
            this.pricePerSqMFrom.Text = "Nuo";
            this.pricePerSqMFrom.Enter += new System.EventHandler(this.PricePerSqMFrom_Enter);
            this.pricePerSqMFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PricePerSqMFrom_KeyPress);
            this.pricePerSqMFrom.Leave += new System.EventHandler(this.PricePerSqMFrom_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(12, 230);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kaina per kv. metrą";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(31, 526);
            this.search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(94, 32);
            this.search.TabIndex = 5;
            this.search.Text = "Ieškoti";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.Search_Click);
            // 
            // showAdList
            // 
            this.showAdList.BackColor = System.Drawing.Color.Transparent;
            this.showAdList.Location = new System.Drawing.Point(31, 568);
            this.showAdList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showAdList.Name = "showAdList";
            this.showAdList.Size = new System.Drawing.Size(94, 31);
            this.showAdList.TabIndex = 1;
            this.showAdList.Text = "Rodyti sąrašą";
            this.showAdList.UseVisualStyleBackColor = false;
            // 
            // priceTo
            // 
            this.priceTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.priceTo.Location = new System.Drawing.Point(76, 165);
            this.priceTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.priceTo.Name = "priceTo";
            this.priceTo.Size = new System.Drawing.Size(60, 20);
            this.priceTo.TabIndex = 3;
            this.priceTo.Text = "Iki";
            this.priceTo.Enter += new System.EventHandler(this.PriceTo_Enter);
            this.priceTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceTo_KeyPress);
            this.priceTo.Leave += new System.EventHandler(this.PriceTo_Leave);
            // 
            // areaTo
            // 
            this.areaTo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.areaTo.Location = new System.Drawing.Point(76, 208);
            this.areaTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.areaTo.Name = "areaTo";
            this.areaTo.Size = new System.Drawing.Size(60, 20);
            this.areaTo.TabIndex = 3;
            this.areaTo.Text = "Iki";
            this.areaTo.Enter += new System.EventHandler(this.AreaTo_Enter);
            this.areaTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AreaTo_KeyPress);
            this.areaTo.Leave += new System.EventHandler(this.AreaTo_Leave);
            // 
            // areaFrom
            // 
            this.areaFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.areaFrom.Location = new System.Drawing.Point(14, 208);
            this.areaFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.areaFrom.Name = "areaFrom";
            this.areaFrom.Size = new System.Drawing.Size(60, 20);
            this.areaFrom.TabIndex = 3;
            this.areaFrom.Text = "Nuo";
            this.areaFrom.Enter += new System.EventHandler(this.AreaFrom_Enter);
            this.areaFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AreaFrom_KeyPress);
            this.areaFrom.Leave += new System.EventHandler(this.AreaFrom_Leave);
            // 
            // priceFrom
            // 
            this.priceFrom.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.priceFrom.Location = new System.Drawing.Point(14, 165);
            this.priceFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.priceFrom.Name = "priceFrom";
            this.priceFrom.Size = new System.Drawing.Size(60, 20);
            this.priceFrom.TabIndex = 3;
            this.priceFrom.Text = "Nuo";
            this.priceFrom.Enter += new System.EventHandler(this.PriceFrom_Enter);
            this.priceFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceFrom_KeyPress);
            this.priceFrom.Leave += new System.EventHandler(this.PriceFrom_Leave);
            // 
            // street
            // 
            this.street.AutoCompleteCustomSource.AddRange(new string[] {
            "Mokyklos g.",
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
            this.street.Location = new System.Drawing.Point(14, 124);
            this.street.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.street.Multiline = true;
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(123, 20);
            this.street.TabIndex = 2;
            this.street.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Street_KeyPress);
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
            this.municipality.Location = new System.Drawing.Point(14, 81);
            this.municipality.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.municipality.Name = "municipality";
            this.municipality.Size = new System.Drawing.Size(123, 20);
            this.municipality.TabIndex = 2;
            this.municipality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Municipality_KeyPress);
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
            this.objTipe.Location = new System.Drawing.Point(14, 42);
            this.objTipe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objTipe.Name = "objTipe";
            this.objTipe.Size = new System.Drawing.Size(123, 21);
            this.objTipe.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(11, 189);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Plotas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(10, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kaina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(10, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gatvė";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 11F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(11, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Savivaldybė";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Objekto tipas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "MERG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 59);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 59);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.map);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1068, 623);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(3, 0);
            this.map.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 24;
            this.map.MinZoom = 3;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(844, 603);
            this.map.TabIndex = 1;
            this.map.Zoom = 7D;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 602);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(849, 21);
            this.panel4.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 366);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(184, 155);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1068, 682);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.TextBox priceTo;
        private System.Windows.Forms.TextBox areaTo;
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
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox pricePerSqMTo;
        private System.Windows.Forms.TextBox pricePerSqMFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox noInfoRoomNumber;
        private System.Windows.Forms.TextBox numberOfRoomsTo;
        private System.Windows.Forms.TextBox numberOfRoomsFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox noInfoBuildYear;
        private System.Windows.Forms.TextBox buildYearTo;
        private System.Windows.Forms.TextBox buildYearFrom;
        private System.Windows.Forms.Label label8;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

