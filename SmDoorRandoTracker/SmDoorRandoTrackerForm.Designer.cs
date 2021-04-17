
namespace SmDoorRandoTracker
{
    partial class SmDoorRandoTrackerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmDoorRandoTrackerForm));
            this.crateria = new System.Windows.Forms.Button();
            this.brinstar = new System.Windows.Forms.Button();
            this.wrecked = new System.Windows.Forms.Button();
            this.maridia = new System.Windows.Forms.Button();
            this.norfair = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.doorlabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crateria
            // 
            this.crateria.BackColor = System.Drawing.Color.LightSkyBlue;
            this.crateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crateria.Location = new System.Drawing.Point(3, 3);
            this.crateria.Name = "crateria";
            this.crateria.Size = new System.Drawing.Size(76, 23);
            this.crateria.TabIndex = 1;
            this.crateria.Text = "Crateria";
            this.crateria.UseVisualStyleBackColor = false;
            this.crateria.Click += new System.EventHandler(this.FocusArea_Click);
            // 
            // button2
            // 
            this.brinstar.BackColor = System.Drawing.Color.OliveDrab;
            this.brinstar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brinstar.Location = new System.Drawing.Point(85, 3);
            this.brinstar.Name = "button2";
            this.brinstar.Size = new System.Drawing.Size(76, 23);
            this.brinstar.TabIndex = 2;
            this.brinstar.Text = "Brinstar";
            this.brinstar.UseVisualStyleBackColor = false;
            this.brinstar.Click += new System.EventHandler(this.FocusArea_Click);
            // 
            // wrecked
            // 
            this.wrecked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.wrecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wrecked.Location = new System.Drawing.Point(167, 3);
            this.wrecked.Name = "wrecked";
            this.wrecked.Size = new System.Drawing.Size(84, 23);
            this.wrecked.TabIndex = 3;
            this.wrecked.Text = "WreckedShip";
            this.wrecked.UseVisualStyleBackColor = false;
            this.wrecked.Click += new System.EventHandler(this.FocusArea_Click);
            // 
            // maridia
            // 
            this.maridia.BackColor = System.Drawing.Color.DodgerBlue;
            this.maridia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maridia.Location = new System.Drawing.Point(257, 3);
            this.maridia.Name = "maridia";
            this.maridia.Size = new System.Drawing.Size(76, 23);
            this.maridia.TabIndex = 4;
            this.maridia.Text = "Maridia";
            this.maridia.UseVisualStyleBackColor = false;
            this.maridia.Click += new System.EventHandler(this.FocusArea_Click);
            // 
            // norfair
            // 
            this.norfair.BackColor = System.Drawing.Color.Red;
            this.norfair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.norfair.Location = new System.Drawing.Point(339, 3);
            this.norfair.Name = "norfair";
            this.norfair.Size = new System.Drawing.Size(76, 23);
            this.norfair.TabIndex = 5;
            this.norfair.Text = "Norfair";
            this.norfair.UseVisualStyleBackColor = false;
            this.norfair.Click += new System.EventHandler(this.FocusArea_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.crateria);
            this.flowLayoutPanel1.Controls.Add(this.brinstar);
            this.flowLayoutPanel1.Controls.Add(this.wrecked);
            this.flowLayoutPanel1.Controls.Add(this.maridia);
            this.flowLayoutPanel1.Controls.Add(this.norfair);
            this.flowLayoutPanel1.Controls.Add(this.doorlabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(856, 33);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // doorlabel
            // 
            this.doorlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.doorlabel.AutoSize = true;
            this.doorlabel.ForeColor = System.Drawing.Color.White;
            this.doorlabel.Location = new System.Drawing.Point(421, 0);
            this.doorlabel.Name = "doorlabel";
            this.doorlabel.Size = new System.Drawing.Size(38, 29);
            this.doorlabel.TabIndex = 7;
            this.doorlabel.Text = "Doors";
            this.doorlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SmDoorRandoTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(859, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmDoorRandoTrackerForm";
            this.Text = "SmDoorRandoTracker";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button crateria;
        private System.Windows.Forms.Button brinstar;
        private System.Windows.Forms.Button wrecked;
        private System.Windows.Forms.Button maridia;
        private System.Windows.Forms.Button norfair;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label doorlabel;
    }
}

