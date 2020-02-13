namespace netnetcafe
{
    partial class trans
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
            this.cbTransType = new System.Windows.Forms.ComboBox();
            this.lbltransaction = new System.Windows.Forms.Label();
            this.lblPapertype = new System.Windows.Forms.Label();
            this.cbPaperType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbPurpose = new System.Windows.Forms.ComboBox();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTransType
            // 
            this.cbTransType.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransType.FormattingEnabled = true;
            this.cbTransType.Location = new System.Drawing.Point(353, 130);
            this.cbTransType.Name = "cbTransType";
            this.cbTransType.Size = new System.Drawing.Size(221, 26);
            this.cbTransType.TabIndex = 0;
            this.cbTransType.SelectedIndexChanged += new System.EventHandler(this.cbTransType_SelectedIndexChanged);
            // 
            // lbltransaction
            // 
            this.lbltransaction.AutoSize = true;
            this.lbltransaction.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltransaction.Location = new System.Drawing.Point(207, 133);
            this.lbltransaction.Name = "lbltransaction";
            this.lbltransaction.Size = new System.Drawing.Size(140, 18);
            this.lbltransaction.TabIndex = 1;
            this.lbltransaction.Text = "Transaction Type:";
            // 
            // lblPapertype
            // 
            this.lblPapertype.AutoSize = true;
            this.lblPapertype.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPapertype.Location = new System.Drawing.Point(207, 168);
            this.lblPapertype.Name = "lblPapertype";
            this.lblPapertype.Size = new System.Drawing.Size(97, 18);
            this.lblPapertype.TabIndex = 2;
            this.lblPapertype.Text = "Paper Type:";
            this.lblPapertype.Visible = false;
            // 
            // cbPaperType
            // 
            this.cbPaperType.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaperType.FormattingEnabled = true;
            this.cbPaperType.Location = new System.Drawing.Point(353, 165);
            this.cbPaperType.Name = "cbPaperType";
            this.cbPaperType.Size = new System.Drawing.Size(221, 26);
            this.cbPaperType.TabIndex = 3;
            this.cbPaperType.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(353, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 26);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbPurpose
            // 
            this.cbPurpose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPurpose.FormattingEnabled = true;
            this.cbPurpose.Location = new System.Drawing.Point(353, 165);
            this.cbPurpose.Name = "cbPurpose";
            this.cbPurpose.Size = new System.Drawing.Size(221, 26);
            this.cbPurpose.TabIndex = 5;
            this.cbPurpose.Visible = false;
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurpose.Location = new System.Drawing.Point(207, 168);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(80, 18);
            this.lblPurpose.TabIndex = 6;
            this.lblPurpose.Text = "Purpose:";
            this.lblPurpose.Visible = false;
            // 
            // trans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 512);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.cbPurpose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbPaperType);
            this.Controls.Add(this.lblPapertype);
            this.Controls.Add(this.lbltransaction);
            this.Controls.Add(this.cbTransType);
            this.Name = "trans";
            this.Text = "trans";
            this.Load += new System.EventHandler(this.trans_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTransType;
        private System.Windows.Forms.Label lbltransaction;
        private System.Windows.Forms.Label lblPapertype;
        private System.Windows.Forms.ComboBox cbPaperType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbPurpose;
        private System.Windows.Forms.Label lblPurpose;
    }
}