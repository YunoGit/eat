namespace Eat
{
    partial class FoodMenuAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodMenuAdd));
            this.botLvUp = new System.Windows.Forms.Button();
            this.botYes = new System.Windows.Forms.Button();
            this.txtFoodPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.txtFoodDanWei = new System.Windows.Forms.TextBox();
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
            this.botLvUp.Location = new System.Drawing.Point(187, 186);
            this.botLvUp.Name = "botLvUp";
            this.botLvUp.Size = new System.Drawing.Size(112, 38);
            this.botLvUp.TabIndex = 65;
            this.botLvUp.TabStop = false;
            this.botLvUp.Text = "取消";
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
            this.botYes.Location = new System.Drawing.Point(42, 186);
            this.botYes.Name = "botYes";
            this.botYes.Size = new System.Drawing.Size(112, 38);
            this.botYes.TabIndex = 51;
            this.botYes.TabStop = false;
            this.botYes.Text = "添加";
            this.botYes.UseVisualStyleBackColor = false;
            this.botYes.Click += new System.EventHandler(this.botYes_Click);
            // 
            // txtFoodPrice
            // 
            this.txtFoodPrice.BackColor = System.Drawing.Color.White;
            this.txtFoodPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFoodPrice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFoodPrice.Location = new System.Drawing.Point(76, 122);
            this.txtFoodPrice.MaxLength = 10;
            this.txtFoodPrice.Name = "txtFoodPrice";
            this.txtFoodPrice.Size = new System.Drawing.Size(237, 22);
            this.txtFoodPrice.TabIndex = 63;
            this.txtFoodPrice.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(28, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 60;
            this.label5.Text = "价格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 59;
            this.label3.Text = "单位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 58;
            this.label2.Text = "菜名";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Silver;
            this.panel8.Location = new System.Drawing.Point(0, 156);
            this.panel8.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(335, 1);
            this.panel8.TabIndex = 56;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.Location = new System.Drawing.Point(0, 106);
            this.panel7.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(335, 1);
            this.panel7.TabIndex = 55;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Location = new System.Drawing.Point(0, 56);
            this.panel6.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(335, 1);
            this.panel6.TabIndex = 54;
            // 
            // txtFoodName
            // 
            this.txtFoodName.BackColor = System.Drawing.Color.White;
            this.txtFoodName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFoodName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFoodName.Location = new System.Drawing.Point(76, 22);
            this.txtFoodName.MaxLength = 10;
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(237, 22);
            this.txtFoodName.TabIndex = 52;
            this.txtFoodName.TabStop = false;
            // 
            // txtFoodDanWei
            // 
            this.txtFoodDanWei.BackColor = System.Drawing.Color.White;
            this.txtFoodDanWei.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFoodDanWei.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFoodDanWei.Location = new System.Drawing.Point(76, 71);
            this.txtFoodDanWei.MaxLength = 1;
            this.txtFoodDanWei.Name = "txtFoodDanWei";
            this.txtFoodDanWei.Size = new System.Drawing.Size(237, 22);
            this.txtFoodDanWei.TabIndex = 66;
            this.txtFoodDanWei.TabStop = false;
            // 
            // FoodMenuAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 239);
            this.Controls.Add(this.txtFoodDanWei);
            this.Controls.Add(this.botLvUp);
            this.Controls.Add(this.botYes);
            this.Controls.Add(this.txtFoodPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txtFoodName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FoodMenuAdd";
            this.Opacity = 0.94D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加菜品";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botLvUp;
        private System.Windows.Forms.Button botYes;
        private System.Windows.Forms.TextBox txtFoodPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.TextBox txtFoodDanWei;
    }
}