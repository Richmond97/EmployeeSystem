namespace Component_A_ClassLibrary
{
    partial class TelephoneComp
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.telephoneNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // telephoneNum
            // 
            this.telephoneNum.Location = new System.Drawing.Point(0, 0);
            this.telephoneNum.Name = "telephoneNum";
            this.telephoneNum.Size = new System.Drawing.Size(100, 20);
            this.telephoneNum.TabIndex = 0;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox telephoneNum;
    }
}
