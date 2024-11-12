namespace ACatsTalePOE
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKey = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.lblGenral = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabKey.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKey);
            this.tabControl1.Controls.Add(this.tabControl);
            this.tabControl1.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 531);
            this.tabControl1.TabIndex = 0;
            // 
            // tabKey
            // 
            this.tabKey.AutoScroll = true;
            this.tabKey.BackColor = System.Drawing.Color.SteelBlue;
            this.tabKey.Controls.Add(this.label4);
            this.tabKey.Controls.Add(this.label3);
            this.tabKey.Controls.Add(this.lblGenral);
            this.tabKey.Location = new System.Drawing.Point(4, 40);
            this.tabKey.Name = "tabKey";
            this.tabKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabKey.Size = new System.Drawing.Size(883, 487);
            this.tabKey.TabIndex = 0;
            this.tabKey.Text = "KEY";
            // 
            // tabControl
            // 
            this.tabControl.BackColor = System.Drawing.Color.SteelBlue;
            this.tabControl.Controls.Add(this.label1);
            this.tabControl.Controls.Add(this.label2);
            this.tabControl.Location = new System.Drawing.Point(4, 40);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(883, 487);
            this.tabControl.TabIndex = 1;
            this.tabControl.Text = "CONTROLS";
            // 
            // lblGenral
            // 
            this.lblGenral.AutoSize = true;
            this.lblGenral.BackColor = System.Drawing.Color.LightPink;
            this.lblGenral.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenral.Location = new System.Drawing.Point(17, 16);
            this.lblGenral.Name = "lblGenral";
            this.lblGenral.Size = new System.Drawing.Size(637, 208);
            this.lblGenral.TabIndex = 8;
            this.lblGenral.Text = "GENERAL:\r\n▼ = Hero\r\n       |HP: 40 |ATK: 5 |\r\n▓ = Locked Exit\r\n░ = Unlocked Exit\r" +
    "\n       |All enemies have to be defeat to unlock the exit.|\r\n█ = Wall\r\n       |Y" +
    "ou cannot move past the walls.|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightPink;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(639, 260);
            this.label3.TabIndex = 9;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightPink;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(465, 130);
            this.label4.TabIndex = 10;
            this.label4.Text = "PICKUP:\r\n♥ = Health Potions\r\n      |Restores 10HP.|\r\n* = Attack buff\r\n     |Doubl" +
    "es ATK power for 3 attacks.|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightPink;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 195);
            this.label2.TabIndex = 9;
            this.label2.Text = "MOVE:\r\nW - Move Up         \r\nD - Move Right     \r\nS - Move Down     \r\nA - Move Le" +
    "ft        \r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightPink;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 195);
            this.label1.TabIndex = 10;
            this.label1.Text = "ATTACK:\r\nI - Attack Up \r\nL - Attack Right\r\nK - Attack Down\r\nJ - Attack Left\r\n";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ACatsTalePOE.Properties.Resources.BlueBackground;
            this.ClientSize = new System.Drawing.Size(892, 545);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabKey.ResumeLayout(false);
            this.tabKey.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKey;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGenral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}