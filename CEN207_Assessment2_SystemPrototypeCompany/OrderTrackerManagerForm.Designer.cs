
namespace CEN207_Assessment2_SystemPrototypeCompany
{
    partial class OrderTrackerManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvConsumerData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearUser = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.txtbxClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumerData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConsumerData
            // 
            this.dgvConsumerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumerData.Location = new System.Drawing.Point(13, 13);
            this.dgvConsumerData.Name = "dgvConsumerData";
            this.dgvConsumerData.RowTemplate.Height = 25;
            this.dgvConsumerData.Size = new System.Drawing.Size(600, 325);
            this.dgvConsumerData.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearUser);
            this.groupBox1.Controls.Add(this.btnSendOrder);
            this.groupBox1.Controls.Add(this.txtbxClientName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(629, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Order";
            // 
            // btnClearUser
            // 
            this.btnClearUser.Location = new System.Drawing.Point(151, 127);
            this.btnClearUser.Name = "btnClearUser";
            this.btnClearUser.Size = new System.Drawing.Size(75, 23);
            this.btnClearUser.TabIndex = 3;
            this.btnClearUser.Text = "Clear User";
            this.btnClearUser.UseVisualStyleBackColor = true;
            this.btnClearUser.Click += new System.EventHandler(this.btnClearUser_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Location = new System.Drawing.Point(151, 81);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSendOrder.TabIndex = 2;
            this.btnSendOrder.Text = "Send Order";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // txtbxClientName
            // 
            this.txtbxClientName.Location = new System.Drawing.Point(87, 38);
            this.txtbxClientName.Name = "txtbxClientName";
            this.txtbxClientName.Size = new System.Drawing.Size(139, 23);
            this.txtbxClientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Name";
            // 
            // OrderTrackerManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvConsumerData);
            this.Name = "OrderTrackerManagerForm";
            this.Text = "Order Tracking Manager";
            this.Load += new System.EventHandler(this.OrderTrackerManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumerData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsumerData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbxClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearUser;
        private System.Windows.Forms.Button btnSendOrder;
    }
}

