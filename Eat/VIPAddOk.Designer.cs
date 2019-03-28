namespace Eat
{
    partial class VIPAddOk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VIPAddOk));
            this.botLvUp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            this.botLvUp.Location = new System.Drawing.Point(192, 77);
            this.botLvUp.Name = "botLvUp";
            this.botLvUp.Size = new System.Drawing.Size(112, 38);
            this.botLvUp.TabIndex = 51;
            this.botLvUp.TabStop = false;
            this.botLvUp.Text = "确认";
            this.botLvUp.UseVisualStyleBackColor = false;
            this.botLvUp.Click += new System.EventHandler(this.botLvUp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(77, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 21);
            this.label2.TabIndex = 54;
            this.label2.Text = "添加成功，请牢记卡号：";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Location = new System.Drawing.Point(0, 58);
            this.panel6.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(479, 1);
            this.panel6.TabIndex = 53;
            // 
            // textId
            // 
            this.textId.BackColor = System.Drawing.Color.White;
            this.textId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textId.ForeColor = System.Drawing.Color.Tomato;
            this.textId.Location = new System.Drawing.Point(269, 24);
            this.textId.MaxLength = 10;
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(129, 22);
            this.textId.TabIndex = 52;
            this.textId.TabStop = false;
            // 
            // VIPAddOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 136);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.botLvUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VIPAddOk";
            this.Opacity = 0.94D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加成功";
            this.Load += new System.EventHandler(this.VIPAddOk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botLvUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textId;
    }
}