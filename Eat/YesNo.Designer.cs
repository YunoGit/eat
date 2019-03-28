namespace Eat
{
    partial class YesNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YesNo));
            this.txtMessage = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.botLvUp = new System.Windows.Forms.Button();
            this.botYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.AutoEllipsis = true;
            this.txtMessage.AutoSize = true;
            this.txtMessage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMessage.Location = new System.Drawing.Point(28, 21);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.txtMessage.MaximumSize = new System.Drawing.Size(280, 0);
            this.txtMessage.MinimumSize = new System.Drawing.Size(280, 0);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(280, 21);
            this.txtMessage.TabIndex = 50;
            this.txtMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Silver;
            this.panel11.Location = new System.Drawing.Point(0, 55);
            this.panel11.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(335, 1);
            this.panel11.TabIndex = 57;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(49, 44);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 0);
            this.panel5.TabIndex = 56;
            // 
            // botLvUp
            // 
            this.botLvUp.BackColor = System.Drawing.Color.Transparent;
            this.botLvUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botLvUp.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.botLvUp.FlatAppearance.BorderSize = 2;
            this.botLvUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botLvUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botLvUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLvUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.botLvUp.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.botLvUp.Location = new System.Drawing.Point(180, 80);
            this.botLvUp.Name = "botLvUp";
            this.botLvUp.Size = new System.Drawing.Size(112, 38);
            this.botLvUp.TabIndex = 60;
            this.botLvUp.TabStop = false;
            this.botLvUp.Text = "不，谢谢";
            this.botLvUp.UseVisualStyleBackColor = false;
            this.botLvUp.Click += new System.EventHandler(this.botLvUp_Click);
            // 
            // botYes
            // 
            this.botYes.BackColor = System.Drawing.Color.Transparent;
            this.botYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botYes.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.botYes.FlatAppearance.BorderSize = 2;
            this.botYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botYes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.botYes.ForeColor = System.Drawing.Color.Tomato;
            this.botYes.Location = new System.Drawing.Point(35, 80);
            this.botYes.Name = "botYes";
            this.botYes.Size = new System.Drawing.Size(112, 38);
            this.botYes.TabIndex = 59;
            this.botYes.TabStop = false;
            this.botYes.Text = "好";
            this.botYes.UseVisualStyleBackColor = false;
            this.botYes.Click += new System.EventHandler(this.botYes_Click);
            // 
            // YesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 141);
            this.Controls.Add(this.botLvUp);
            this.Controls.Add(this.botYes);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YesNo";
            this.Opacity = 0.94D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "确认";
            this.Load += new System.EventHandler(this.YesNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button botLvUp;
        private System.Windows.Forms.Button botYes;
    }
}