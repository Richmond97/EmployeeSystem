namespace LoginForm
{
    partial class ManageForm
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
            this.createPanel = new System.Windows.Forms.Panel();
            this.cbxRole = new System.Windows.Forms.ComboBox();
            this.cbxDept = new System.Windows.Forms.ComboBox();
            this.btnCreateEmploy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.editPanel = new System.Windows.Forms.Panel();
            this.chbxDetails = new System.Windows.Forms.CheckBox();
            this.cbxERole = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdID = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.cbxEDept = new System.Windows.Forms.ComboBox();
            this.btnDeleteEmploy = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditEmploy = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtECounty = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEPassword = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtEStreet = new System.Windows.Forms.TextBox();
            this.txtEDateJoined = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtECity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEEmail = new System.Windows.Forms.TextBox();
            this.txtETele = new System.Windows.Forms.TextBox();
            this.txtELast = new System.Windows.Forms.TextBox();
            this.txtEPost = new System.Windows.Forms.TextBox();
            this.txtEFirst = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.createEmployee1 = new Component_A_ClassLibrary.CreateEmployee(this.components);
            this.editEmployee1 = new Component_A_ClassLibrary.EditEmployee(this.components);
            this.deleteEmployee1 = new Component_A_ClassLibrary.DeleteEmployee(this.components);
            this.createPanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // createPanel
            // 
            this.createPanel.Controls.Add(this.cbxRole);
            this.createPanel.Controls.Add(this.cbxDept);
            this.createPanel.Controls.Add(this.btnCreateEmploy);
            this.createPanel.Controls.Add(this.label7);
            this.createPanel.Controls.Add(this.txtCounty);
            this.createPanel.Controls.Add(this.label20);
            this.createPanel.Controls.Add(this.label6);
            this.createPanel.Controls.Add(this.txtStreet);
            this.createPanel.Controls.Add(this.label8);
            this.createPanel.Controls.Add(this.txtCity);
            this.createPanel.Controls.Add(this.label5);
            this.createPanel.Controls.Add(this.label4);
            this.createPanel.Controls.Add(this.label3);
            this.createPanel.Controls.Add(this.label26);
            this.createPanel.Controls.Add(this.label2);
            this.createPanel.Controls.Add(this.label23);
            this.createPanel.Controls.Add(this.label25);
            this.createPanel.Controls.Add(this.label19);
            this.createPanel.Controls.Add(this.label1);
            this.createPanel.Controls.Add(this.txtEmail);
            this.createPanel.Controls.Add(this.txtNumber);
            this.createPanel.Controls.Add(this.txtSurname);
            this.createPanel.Controls.Add(this.txtPostcode);
            this.createPanel.Controls.Add(this.txtName);
            this.createPanel.Location = new System.Drawing.Point(22, 457);
            this.createPanel.Name = "createPanel";
            this.createPanel.Size = new System.Drawing.Size(86, 52);
            this.createPanel.TabIndex = 0;
            // 
            // cbxRole
            // 
            this.cbxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRole.FormattingEnabled = true;
            this.cbxRole.Location = new System.Drawing.Point(646, 182);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(121, 21);
            this.cbxRole.TabIndex = 9;
            // 
            // cbxDept
            // 
            this.cbxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Location = new System.Drawing.Point(646, 123);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Size = new System.Drawing.Size(121, 21);
            this.cbxDept.TabIndex = 8;
            // 
            // btnCreateEmploy
            // 
            this.btnCreateEmploy.Location = new System.Drawing.Point(371, 388);
            this.btnCreateEmploy.Name = "btnCreateEmploy";
            this.btnCreateEmploy.Size = new System.Drawing.Size(109, 37);
            this.btnCreateEmploy.TabIndex = 10;
            this.btnCreateEmploy.Text = "CREATE";
            this.btnCreateEmploy.UseVisualStyleBackColor = true;
            this.btnCreateEmploy.Click += new System.EventHandler(this.BtnCreateEmploy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(347, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "County";
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(350, 241);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(150, 20);
            this.txtCounty.TabIndex = 6;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(345, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(172, 25);
            this.label20.TabIndex = 17;
            this.label20.Text = "Home Address ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(347, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Street address ";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(350, 123);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(150, 20);
            this.txtStreet.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(347, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "City/Town";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(350, 182);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 20);
            this.txtCity.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(347, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Postcode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(47, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Email Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(47, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Telephone number";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label26.ForeColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(643, 156);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 17);
            this.label26.TabIndex = 6;
            this.label26.Text = "Role";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(47, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last name";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(641, 36);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 25);
            this.label23.TabIndex = 5;
            this.label23.Text = "Job Role";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label25.ForeColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(643, 97);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 17);
            this.label25.TabIndex = 5;
            this.label25.Text = "Department";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(45, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(185, 25);
            this.label19.TabIndex = 5;
            this.label19.Text = "Personal Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(47, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "First name ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(50, 300);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(50, 241);
            this.txtNumber.MaxLength = 11;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(150, 20);
            this.txtNumber.TabIndex = 2;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(50, 182);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(150, 20);
            this.txtSurname.TabIndex = 1;
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(350, 300);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(150, 20);
            this.txtPostcode.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 123);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCreate.Location = new System.Drawing.Point(-2, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(217, 37);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "ADD EMPLOYEE";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEdit.Location = new System.Drawing.Point(207, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(217, 37);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "EDIT EMPLOYEE";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.Location = new System.Drawing.Point(421, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(217, 37);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "DELETE EMPLOYEE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.chbxDetails);
            this.editPanel.Controls.Add(this.cbxERole);
            this.editPanel.Controls.Add(this.groupBox1);
            this.editPanel.Controls.Add(this.cbxEDept);
            this.editPanel.Controls.Add(this.btnDeleteEmploy);
            this.editPanel.Controls.Add(this.dataGridView1);
            this.editPanel.Controls.Add(this.btnEditEmploy);
            this.editPanel.Controls.Add(this.txtSearch);
            this.editPanel.Controls.Add(this.btnSearch);
            this.editPanel.Controls.Add(this.label9);
            this.editPanel.Controls.Add(this.txtECounty);
            this.editPanel.Controls.Add(this.label18);
            this.editPanel.Controls.Add(this.txtEPassword);
            this.editPanel.Controls.Add(this.label22);
            this.editPanel.Controls.Add(this.label10);
            this.editPanel.Controls.Add(this.label17);
            this.editPanel.Controls.Add(this.label21);
            this.editPanel.Controls.Add(this.txtEStreet);
            this.editPanel.Controls.Add(this.txtEDateJoined);
            this.editPanel.Controls.Add(this.label11);
            this.editPanel.Controls.Add(this.txtECity);
            this.editPanel.Controls.Add(this.label12);
            this.editPanel.Controls.Add(this.label13);
            this.editPanel.Controls.Add(this.label14);
            this.editPanel.Controls.Add(this.label15);
            this.editPanel.Controls.Add(this.label16);
            this.editPanel.Controls.Add(this.txtEEmail);
            this.editPanel.Controls.Add(this.txtETele);
            this.editPanel.Controls.Add(this.txtELast);
            this.editPanel.Controls.Add(this.txtEPost);
            this.editPanel.Controls.Add(this.txtEFirst);
            this.editPanel.Location = new System.Drawing.Point(72, 70);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(95, 73);
            this.editPanel.TabIndex = 4;
            // 
            // chbxDetails
            // 
            this.chbxDetails.AutoSize = true;
            this.chbxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chbxDetails.ForeColor = System.Drawing.Color.White;
            this.chbxDetails.Location = new System.Drawing.Point(687, 192);
            this.chbxDetails.Name = "chbxDetails";
            this.chbxDetails.Size = new System.Drawing.Size(131, 21);
            this.chbxDetails.TabIndex = 10;
            this.chbxDetails.Text = "Sensitive Details";
            this.chbxDetails.UseVisualStyleBackColor = true;
            this.chbxDetails.CheckedChanged += new System.EventHandler(this.ChbxDetails_CheckedChanged);
            // 
            // cbxERole
            // 
            this.cbxERole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxERole.Enabled = false;
            this.cbxERole.FormattingEnabled = true;
            this.cbxERole.Location = new System.Drawing.Point(499, 264);
            this.cbxERole.Name = "cbxERole";
            this.cbxERole.Size = new System.Drawing.Size(150, 21);
            this.cbxERole.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdID);
            this.groupBox1.Controls.Add(this.rdName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(570, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 36);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // rdID
            // 
            this.rdID.AutoSize = true;
            this.rdID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdID.ForeColor = System.Drawing.Color.White;
            this.rdID.Location = new System.Drawing.Point(92, 11);
            this.rdID.Name = "rdID";
            this.rdID.Size = new System.Drawing.Size(39, 20);
            this.rdID.TabIndex = 1;
            this.rdID.TabStop = true;
            this.rdID.Text = "ID";
            this.rdID.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdName.ForeColor = System.Drawing.Color.White;
            this.rdName.Location = new System.Drawing.Point(9, 13);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(53, 17);
            this.rdName.TabIndex = 0;
            this.rdName.TabStop = true;
            this.rdName.Text = "Name";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // cbxEDept
            // 
            this.cbxEDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEDept.Enabled = false;
            this.cbxEDept.FormattingEnabled = true;
            this.cbxEDept.Location = new System.Drawing.Point(499, 215);
            this.cbxEDept.Name = "cbxEDept";
            this.cbxEDept.Size = new System.Drawing.Size(150, 21);
            this.cbxEDept.TabIndex = 11;
            // 
            // btnDeleteEmploy
            // 
            this.btnDeleteEmploy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmploy.Location = new System.Drawing.Point(699, 344);
            this.btnDeleteEmploy.Name = "btnDeleteEmploy";
            this.btnDeleteEmploy.Size = new System.Drawing.Size(109, 37);
            this.btnDeleteEmploy.TabIndex = 15;
            this.btnDeleteEmploy.Text = "DELETE";
            this.btnDeleteEmploy.UseVisualStyleBackColor = true;
            this.btnDeleteEmploy.Click += new System.EventHandler(this.BtnDeleteEmploy_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(213, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(436, 113);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // btnEditEmploy
            // 
            this.btnEditEmploy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEmploy.Location = new System.Drawing.Point(699, 344);
            this.btnEditEmploy.Name = "btnEditEmploy";
            this.btnEditEmploy.Size = new System.Drawing.Size(109, 37);
            this.btnEditEmploy.TabIndex = 39;
            this.btnEditEmploy.Text = "EDIT";
            this.btnEditEmploy.UseVisualStyleBackColor = true;
            this.btnEditEmploy.Click += new System.EventHandler(this.BtnEditEmploy_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(284, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(442, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 22);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(271, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 35;
            this.label9.Text = "County";
            // 
            // txtECounty
            // 
            this.txtECounty.Location = new System.Drawing.Point(274, 312);
            this.txtECounty.Name = "txtECounty";
            this.txtECounty.Size = new System.Drawing.Size(150, 20);
            this.txtECounty.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(496, 291);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 17);
            this.label18.TabIndex = 33;
            this.label18.Text = "Password";
            // 
            // txtEPassword
            // 
            this.txtEPassword.Enabled = false;
            this.txtEPassword.Location = new System.Drawing.Point(499, 312);
            this.txtEPassword.Name = "txtEPassword";
            this.txtEPassword.Size = new System.Drawing.Size(150, 20);
            this.txtEPassword.TabIndex = 13;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label22.ForeColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(496, 242);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 17);
            this.label22.TabIndex = 6;
            this.label22.Text = "Role";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(271, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Street address ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label17.ForeColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(496, 340);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 17);
            this.label17.TabIndex = 31;
            this.label17.Text = "Date Joined";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label21.ForeColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(496, 193);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 17);
            this.label21.TabIndex = 5;
            this.label21.Text = "Department";
            // 
            // txtEStreet
            // 
            this.txtEStreet.Location = new System.Drawing.Point(273, 214);
            this.txtEStreet.Name = "txtEStreet";
            this.txtEStreet.Size = new System.Drawing.Size(150, 20);
            this.txtEStreet.TabIndex = 6;
            // 
            // txtEDateJoined
            // 
            this.txtEDateJoined.Enabled = false;
            this.txtEDateJoined.Location = new System.Drawing.Point(499, 361);
            this.txtEDateJoined.Name = "txtEDateJoined";
            this.txtEDateJoined.Size = new System.Drawing.Size(150, 20);
            this.txtEDateJoined.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(271, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "City / Town";
            // 
            // txtECity
            // 
            this.txtECity.Location = new System.Drawing.Point(274, 263);
            this.txtECity.Name = "txtECity";
            this.txtECity.Size = new System.Drawing.Size(150, 20);
            this.txtECity.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(271, 340);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Postcode";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(45, 340);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Email Address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(45, 291);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Telephone number";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(45, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "Last name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(45, 193);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 17);
            this.label16.TabIndex = 25;
            this.label16.Text = "First name ";
            // 
            // txtEEmail
            // 
            this.txtEEmail.Location = new System.Drawing.Point(48, 361);
            this.txtEEmail.Name = "txtEEmail";
            this.txtEEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEEmail.TabIndex = 5;
            // 
            // txtETele
            // 
            this.txtETele.Location = new System.Drawing.Point(48, 312);
            this.txtETele.Name = "txtETele";
            this.txtETele.Size = new System.Drawing.Size(150, 20);
            this.txtETele.TabIndex = 4;
            // 
            // txtELast
            // 
            this.txtELast.Location = new System.Drawing.Point(48, 263);
            this.txtELast.Name = "txtELast";
            this.txtELast.Size = new System.Drawing.Size(150, 20);
            this.txtELast.TabIndex = 3;
            // 
            // txtEPost
            // 
            this.txtEPost.Location = new System.Drawing.Point(273, 361);
            this.txtEPost.Name = "txtEPost";
            this.txtEPost.Size = new System.Drawing.Size(150, 20);
            this.txtEPost.TabIndex = 9;
            // 
            // txtEFirst
            // 
            this.txtEFirst.Location = new System.Drawing.Point(48, 214);
            this.txtEFirst.Name = "txtEFirst";
            this.txtEFirst.Size = new System.Drawing.Size(150, 20);
            this.txtEFirst.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnLogout.Location = new System.Drawing.Point(636, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(217, 37);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(852, 480);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.createPanel);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageForm";
            this.createPanel.ResumeLayout(false);
            this.createPanel.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel createPanel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Button btnCreateEmploy;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Button btnEditEmploy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtECounty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEStreet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtECity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtEEmail;
        private System.Windows.Forms.TextBox txtETele;
        private System.Windows.Forms.TextBox txtELast;
        private System.Windows.Forms.TextBox txtEPost;
        private System.Windows.Forms.TextBox txtEFirst;
        private System.Windows.Forms.Button btnDeleteEmploy;
        private Component_A_ClassLibrary.CreateEmployee createEmployee1;
        private System.Windows.Forms.ComboBox cbxRole;
        private System.Windows.Forms.ComboBox cbxDept;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Component_A_ClassLibrary.EditEmployee editEmployee1;
        private Component_A_ClassLibrary.DeleteEmployee deleteEmployee1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdID;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEPassword;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEDateJoined;
        private System.Windows.Forms.CheckBox chbxDetails;
        private System.Windows.Forms.ComboBox cbxERole;
        private System.Windows.Forms.ComboBox cbxEDept;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
    }
}