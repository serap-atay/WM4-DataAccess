namespace NorthwindDb
{
    partial class SiparisForm
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
            this.txtAra = new System.Windows.Forms.TextBox();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.lstCart = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAzalt = new System.Windows.Forms.Button();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbShippers = new System.Windows.Forms.ComboBox();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.txtShipAdress = new System.Windows.Forms.TextBox();
            this.txtShipPostalCode = new System.Windows.Forms.TextBox();
            this.txtShipCity = new System.Windows.Forms.TextBox();
            this.txtShipCountry = new System.Windows.Forms.TextBox();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.txtShipRegion = new System.Windows.Forms.TextBox();
            this.nFreight = new System.Windows.Forms.NumericUpDown();
            this.btnArttır = new System.Windows.Forms.Button();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nFreight)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(21, 27);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(314, 31);
            this.txtAra.TabIndex = 0;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // lstProducts
            // 
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 25;
            this.lstProducts.Location = new System.Drawing.Point(21, 95);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(317, 404);
            this.lstProducts.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(21, 526);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(314, 59);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // lstCart
            // 
            this.lstCart.HideSelection = false;
            this.lstCart.Location = new System.Drawing.Point(356, 95);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(346, 404);
            this.lstCart.TabIndex = 3;
            this.lstCart.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Toplam : 00 TL";
            // 
            // btnAzalt
            // 
            this.btnAzalt.Location = new System.Drawing.Point(409, 526);
            this.btnAzalt.Name = "btnAzalt";
            this.btnAzalt.Size = new System.Drawing.Size(117, 59);
            this.btnAzalt.TabIndex = 5;
            this.btnAzalt.Text = "Azalt";
            this.btnAzalt.UseVisualStyleBackColor = true;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(728, 104);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(300, 33);
            this.cmbEmployee.TabIndex = 6;
            // 
            // cmbShippers
            // 
            this.cmbShippers.FormattingEnabled = true;
            this.cmbShippers.Location = new System.Drawing.Point(728, 157);
            this.cmbShippers.Name = "cmbShippers";
            this.cmbShippers.Size = new System.Drawing.Size(300, 33);
            this.cmbShippers.TabIndex = 7;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Location = new System.Drawing.Point(728, 219);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(300, 31);
            this.dtpRequiredDate.TabIndex = 8;
            // 
            // txtShipAdress
            // 
            this.txtShipAdress.Location = new System.Drawing.Point(728, 308);
            this.txtShipAdress.Name = "txtShipAdress";
            this.txtShipAdress.Size = new System.Drawing.Size(144, 31);
            this.txtShipAdress.TabIndex = 10;
            // 
            // txtShipPostalCode
            // 
            this.txtShipPostalCode.Location = new System.Drawing.Point(880, 308);
            this.txtShipPostalCode.Name = "txtShipPostalCode";
            this.txtShipPostalCode.Size = new System.Drawing.Size(144, 31);
            this.txtShipPostalCode.TabIndex = 11;
            // 
            // txtShipCity
            // 
            this.txtShipCity.Location = new System.Drawing.Point(728, 361);
            this.txtShipCity.Name = "txtShipCity";
            this.txtShipCity.Size = new System.Drawing.Size(144, 31);
            this.txtShipCity.TabIndex = 12;
            // 
            // txtShipCountry
            // 
            this.txtShipCountry.Location = new System.Drawing.Point(728, 414);
            this.txtShipCountry.Name = "txtShipCountry";
            this.txtShipCountry.Size = new System.Drawing.Size(144, 31);
            this.txtShipCountry.TabIndex = 13;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(884, 361);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(144, 31);
            this.txtShipName.TabIndex = 14;
            // 
            // txtShipRegion
            // 
            this.txtShipRegion.Location = new System.Drawing.Point(880, 414);
            this.txtShipRegion.Name = "txtShipRegion";
            this.txtShipRegion.Size = new System.Drawing.Size(144, 31);
            this.txtShipRegion.TabIndex = 15;
            // 
            // nFreight
            // 
            this.nFreight.DecimalPlaces = 2;
            this.nFreight.Location = new System.Drawing.Point(876, 478);
            this.nFreight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nFreight.Name = "nFreight";
            this.nFreight.Size = new System.Drawing.Size(148, 31);
            this.nFreight.TabIndex = 16;
            this.nFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnArttır
            // 
            this.btnArttır.Location = new System.Drawing.Point(572, 526);
            this.btnArttır.Name = "btnArttır";
            this.btnArttır.Size = new System.Drawing.Size(117, 59);
            this.btnArttır.TabIndex = 17;
            this.btnArttır.Text = "Arttır";
            this.btnArttır.UseVisualStyleBackColor = true;
            // 
            // btnOnayla
            // 
            this.btnOnayla.Location = new System.Drawing.Point(728, 526);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(300, 59);
            this.btnOnayla.TabIndex = 18;
            this.btnOnayla.Text = "Onayla";
            this.btnOnayla.UseVisualStyleBackColor = true;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(730, 266);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(296, 33);
            this.cmbCustomer.TabIndex = 19;
            // 
            // SiparisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 699);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnArttır);
            this.Controls.Add(this.nFreight);
            this.Controls.Add(this.txtShipRegion);
            this.Controls.Add(this.txtShipName);
            this.Controls.Add(this.txtShipCountry);
            this.Controls.Add(this.txtShipCity);
            this.Controls.Add(this.txtShipPostalCode);
            this.Controls.Add(this.txtShipAdress);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.cmbShippers);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.btnAzalt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCart);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.txtAra);
            this.Name = "SiparisForm";
            this.Text = "SiparisForm";
            this.Load += new System.EventHandler(this.SiparisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nFreight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.ListView lstCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAzalt;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbShippers;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.TextBox txtShipAdress;
        private System.Windows.Forms.TextBox txtShipPostalCode;
        private System.Windows.Forms.TextBox txtShipCity;
        private System.Windows.Forms.TextBox txtShipCountry;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.TextBox txtShipRegion;
        private System.Windows.Forms.NumericUpDown nFreight;
        private System.Windows.Forms.Button btnArttır;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.ComboBox cmbCustomer;
    }
}