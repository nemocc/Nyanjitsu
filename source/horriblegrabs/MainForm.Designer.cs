
namespace horriblegrabs
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.listViewG = new System.Windows.Forms.ListViewNF();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.label8 = new System.Windows.Forms.Label();
			this.numericUpDown4_up = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.numericUpDown3_down = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.textboxSearch = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.rgdrop2 = new System.Windows.Forms.ComboBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.rgtreebox = new System.Windows.Forms.MyTreeView();
			this.button2 = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.checkedListBoxWatchlist = new System.Windows.Forms.CheckedListBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.infobutton1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numericRGid = new System.Windows.Forms.NumericUpDown();
			this.button4 = new System.Windows.Forms.Button();
			this.textBoxrgname = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.rgdrop1 = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button8 = new System.Windows.Forms.Button();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.button10 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.button9 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4_up)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3_down)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericRGid)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(139, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(175, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(754, 501);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.listViewG);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.numericUpDown4_up);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.numericUpDown3_down);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.numericUpDown2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(746, 475);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Downloads";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// listViewG
			// 
			this.listViewG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader8,
									this.columnHeader9,
									this.columnHeader10,
									this.columnHeader11,
									this.columnHeader12,
									this.columnHeader13,
									this.columnHeader14});
			this.listViewG.FullRowSelect = true;
			this.listViewG.Location = new System.Drawing.Point(-1, 30);
			this.listViewG.Name = "listViewG";
			this.listViewG.Size = new System.Drawing.Size(747, 449);
			this.listViewG.TabIndex = 7;
			this.listViewG.UseCompatibleStateImageBehavior = false;
			this.listViewG.View = System.Windows.Forms.View.Details;
			this.listViewG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListViewGMouseUp);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Name";
			this.columnHeader8.Width = 307;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Progress";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader9.Width = 74;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Downloaded";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader10.Width = 105;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Speed";
			this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Peers";
			this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Status";
			this.columnHeader13.Width = 98;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Filename";
			this.columnHeader14.Width = 0;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(492, 3);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(142, 20);
			this.label8.TabIndex = 6;
			this.label8.Text = "max KB/s up (0=unlimited)";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDown4_up
			// 
			this.numericUpDown4_up.Location = new System.Drawing.Point(435, 4);
			this.numericUpDown4_up.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.numericUpDown4_up.Name = "numericUpDown4_up";
			this.numericUpDown4_up.Size = new System.Drawing.Size(51, 20);
			this.numericUpDown4_up.TabIndex = 5;
			this.numericUpDown4_up.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(257, 3);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(155, 20);
			this.label7.TabIndex = 4;
			this.label7.Text = "max KB/s down (0=unlimited)";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDown3_down
			// 
			this.numericUpDown3_down.Location = new System.Drawing.Point(197, 4);
			this.numericUpDown3_down.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.numericUpDown3_down.Name = "numericUpDown3_down";
			this.numericUpDown3_down.Size = new System.Drawing.Size(54, 20);
			this.numericUpDown3_down.TabIndex = 3;
			this.numericUpDown3_down.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(63, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "active downloads";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(9, 3);
			this.numericUpDown2.Maximum = new decimal(new int[] {
									50,
									0,
									0,
									0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(47, 20);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown2.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.checkBox2);
			this.tabPage2.Controls.Add(this.checkBox1);
			this.tabPage2.Controls.Add(this.rgtreebox);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(746, 475);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Search";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Location = new System.Drawing.Point(556, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 53);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "New Release Watchlist";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(13, 19);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(147, 23);
			this.button6.TabIndex = 0;
			this.button6.Text = "Check for new releases";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.textboxSearch);
			this.groupBox6.Controls.Add(this.button5);
			this.groupBox6.Location = new System.Drawing.Point(292, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(200, 54);
			this.groupBox6.TabIndex = 18;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Search Nyaa.eu";
			// 
			// textboxSearch
			// 
			this.textboxSearch.Location = new System.Drawing.Point(13, 21);
			this.textboxSearch.Name = "textboxSearch";
			this.textboxSearch.Size = new System.Drawing.Size(100, 20);
			this.textboxSearch.TabIndex = 14;
			this.textboxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(119, 21);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(66, 21);
			this.button5.TabIndex = 13;
			this.button5.Text = "Search";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.button1);
			this.groupBox5.Controls.Add(this.rgdrop2);
			this.groupBox5.Location = new System.Drawing.Point(6, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(230, 54);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Releasegroup Catalogs";
			// 
			// rgdrop2
			// 
			this.rgdrop2.FormattingEnabled = true;
			this.rgdrop2.Location = new System.Drawing.Point(12, 21);
			this.rgdrop2.Name = "rgdrop2";
			this.rgdrop2.Size = new System.Drawing.Size(121, 21);
			this.rgdrop2.TabIndex = 10;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(205, 82);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(272, 21);
			this.checkBox2.TabIndex = 16;
			this.checkBox2.Text = "Ignore whole series if any torrent has 0 Seeders";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(6, 82);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(173, 21);
			this.checkBox1.TabIndex = 15;
			this.checkBox1.Text = "Ignore torrents with 0 Seeders";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// rgtreebox
			// 
			this.rgtreebox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rgtreebox.CheckBoxes = true;
			this.rgtreebox.Location = new System.Drawing.Point(6, 111);
			this.rgtreebox.Name = "rgtreebox";
			this.rgtreebox.Size = new System.Drawing.Size(732, 358);
			this.rgtreebox.TabIndex = 12;
			this.rgtreebox.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.RgtreeboxAfterCheck);
			this.rgtreebox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RgtreeboxMouseClick);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(611, 82);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(127, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "download selected";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.groupBox2);
			this.tabPage6.Controls.Add(this.groupBox4);
			this.tabPage6.Controls.Add(this.groupBox3);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(746, 475);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Settings";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.checkedListBoxWatchlist);
			this.groupBox2.Location = new System.Drawing.Point(281, 133);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(269, 190);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Edit release watchlist";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 150);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 34);
			this.label2.TabIndex = 2;
			this.label2.Text = "To add a series to the watchlist, rightclick a single torrent in the search resul" +
			"ts.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(24, 121);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(219, 23);
			this.button7.TabIndex = 1;
			this.button7.Text = "Delete selected";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// checkedListBoxWatchlist
			// 
			this.checkedListBoxWatchlist.FormattingEnabled = true;
			this.checkedListBoxWatchlist.HorizontalScrollbar = true;
			this.checkedListBoxWatchlist.Location = new System.Drawing.Point(24, 22);
			this.checkedListBoxWatchlist.Name = "checkedListBoxWatchlist";
			this.checkedListBoxWatchlist.Size = new System.Drawing.Size(219, 94);
			this.checkedListBoxWatchlist.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.infobutton1);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.numericRGid);
			this.groupBox4.Controls.Add(this.button4);
			this.groupBox4.Controls.Add(this.textBoxrgname);
			this.groupBox4.Controls.Add(this.button3);
			this.groupBox4.Controls.Add(this.rgdrop1);
			this.groupBox4.Location = new System.Drawing.Point(6, 133);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(269, 190);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Edit ReleaseGroup Catalogs";
			// 
			// infobutton1
			// 
			this.infobutton1.Location = new System.Drawing.Point(23, 157);
			this.infobutton1.Name = "infobutton1";
			this.infobutton1.Size = new System.Drawing.Size(215, 23);
			this.infobutton1.TabIndex = 7;
			this.infobutton1.Text = "How do I get user IDs for releasegroups?";
			this.infobutton1.UseVisualStyleBackColor = true;
			this.infobutton1.Click += new System.EventHandler(this.Infobutton1Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(158, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "NYAA User ID";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(23, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Releasegroup Name";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// numericRGid
			// 
			this.numericRGid.Location = new System.Drawing.Point(158, 77);
			this.numericRGid.Maximum = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.numericRGid.Name = "numericRGid";
			this.numericRGid.Size = new System.Drawing.Size(80, 20);
			this.numericRGid.TabIndex = 4;
			this.numericRGid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(23, 106);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "Delete";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// textBoxrgname
			// 
			this.textBoxrgname.Location = new System.Drawing.Point(23, 77);
			this.textBoxrgname.Name = "textBoxrgname";
			this.textBoxrgname.Size = new System.Drawing.Size(129, 20);
			this.textBoxrgname.TabIndex = 2;
			this.textBoxrgname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(104, 106);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(134, 23);
			this.button3.TabIndex = 1;
			this.button3.Text = "Save";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// rgdrop1
			// 
			this.rgdrop1.FormattingEnabled = true;
			this.rgdrop1.Location = new System.Drawing.Point(23, 22);
			this.rgdrop1.Name = "rgdrop1";
			this.rgdrop1.Size = new System.Drawing.Size(215, 21);
			this.rgdrop1.TabIndex = 0;
			this.rgdrop1.SelectedIndexChanged += new System.EventHandler(this.Rgdrop1SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button8);
			this.groupBox3.Controls.Add(this.checkBox3);
			this.groupBox3.Controls.Add(this.button10);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.button9);
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.numericUpDownPort);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Location = new System.Drawing.Point(6, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(544, 100);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Bittorrent options";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(129, 39);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(43, 23);
			this.button8.TabIndex = 11;
			this.button8.Text = "Apply";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(286, 54);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(243, 28);
			this.checkBox3.TabIndex = 10;
			this.checkBox3.Text = "Don\'t move finished downloads, keep seeding";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(474, 27);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(44, 23);
			this.button10.TabIndex = 8;
			this.button10.Text = "Open";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10Click);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(286, 15);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(177, 12);
			this.label13.TabIndex = 9;
			this.label13.Text = "Move finished downloads to:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(429, 29);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(34, 20);
			this.button9.TabIndex = 8;
			this.button9.Text = "...";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9Click);
			// 
			// textBox4
			// 
			this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox4.Location = new System.Drawing.Point(286, 30);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(143, 18);
			this.textBox4.TabIndex = 7;
			// 
			// numericUpDownPort
			// 
			this.numericUpDownPort.Location = new System.Drawing.Point(60, 40);
			this.numericUpDownPort.Maximum = new decimal(new int[] {
									65000,
									0,
									0,
									0});
			this.numericUpDownPort.Minimum = new decimal(new int[] {
									200,
									0,
									0,
									0});
			this.numericUpDownPort.Name = "numericUpDownPort";
			this.numericUpDownPort.Size = new System.Drawing.Size(63, 20);
			this.numericUpDownPort.TabIndex = 6;
			this.numericUpDownPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPort.Value = new decimal(new int[] {
									6789,
									0,
									0,
									0});
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(9, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 20);
			this.label12.TabIndex = 5;
			this.label12.Text = "Port";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripProgressBar1,
									this.toolStripStatusLabel1,
									this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 500);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(929, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(812, 17);
			this.toolStripStatusLabel2.Spring = true;
			this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.label6.BackColor = System.Drawing.Color.White;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Blue;
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.label6.Location = new System.Drawing.Point(0, 0);
			this.label6.Margin = new System.Windows.Forms.Padding(0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(173, 501);
			this.label6.TabIndex = 6;
			this.label6.Text = "Version";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Nyanjitsu Torrent Grabber";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1DoubleClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(929, 522);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(800, 200);
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.Text = "Nyanjitsu";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4_up)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3_down)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericRGid)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.CheckedListBox checkedListBoxWatchlist;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox1;
		
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textboxSearch;
		private System.Windows.Forms.MyTreeView rgtreebox;
		private System.Windows.Forms.ComboBox rgdrop2;
		private System.Windows.Forms.Button infobutton1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox rgdrop1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBoxrgname;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.NumericUpDown numericRGid;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ListViewNF listViewG;
		private System.Windows.Forms.NumericUpDown numericUpDownPort;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numericUpDown4_up;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericUpDown3_down;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button1;
	}
}
