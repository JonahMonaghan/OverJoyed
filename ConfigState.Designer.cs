namespace OverJoyedWINFORM
{
    partial class ConfigState
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.lblProfileNE = new System.Windows.Forms.Label();
            this.pnlProfiles = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlDirections = new System.Windows.Forms.Panel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblRightNE = new System.Windows.Forms.Label();
            this.lblLeftNE = new System.Windows.Forms.Label();
            this.lblDownNE = new System.Windows.Forms.Label();
            this.lblUpNE = new System.Windows.Forms.Label();
            this.pnlClicks = new System.Windows.Forms.Panel();
            this.chkReturnRC = new System.Windows.Forms.CheckBox();
            this.chkReturnLC = new System.Windows.Forms.CheckBox();
            this.btnRC = new System.Windows.Forms.Button();
            this.btnLC = new System.Windows.Forms.Button();
            this.lblRCNE = new System.Windows.Forms.Label();
            this.lblLC = new System.Windows.Forms.Label();
            this.pnlDeadzone = new System.Windows.Forms.Panel();
            this.cbOtherOps = new System.Windows.Forms.CheckBox();
            this.txtDeadzoneSize = new System.Windows.Forms.TextBox();
            this.lblSizeNE = new System.Windows.Forms.Label();
            this.lblDeadzoneNE = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlOrigin = new System.Windows.Forms.Panel();
            this.lblOriginYNE = new System.Windows.Forms.Label();
            this.lblOriginXNE = new System.Windows.Forms.Label();
            this.txtOriginY = new System.Windows.Forms.TextBox();
            this.txtOriginX = new System.Windows.Forms.TextBox();
            this.lblOriginNE = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlProfiles.SuspendLayout();
            this.pnlDirections.SuspendLayout();
            this.pnlClicks.SuspendLayout();
            this.pnlDeadzone.SuspendLayout();
            this.pnlOrigin.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboProfiles
            // 
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(3, 34);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(180, 21);
            this.comboProfiles.TabIndex = 0;
            // 
            // lblProfileNE
            // 
            this.lblProfileNE.AutoSize = true;
            this.lblProfileNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileNE.Location = new System.Drawing.Point(3, 7);
            this.lblProfileNE.Name = "lblProfileNE";
            this.lblProfileNE.Size = new System.Drawing.Size(67, 24);
            this.lblProfileNE.TabIndex = 1;
            this.lblProfileNE.Text = "Profile:";
            // 
            // pnlProfiles
            // 
            this.pnlProfiles.Controls.Add(this.btnLoad);
            this.pnlProfiles.Controls.Add(this.btnSave);
            this.pnlProfiles.Controls.Add(this.lblProfileNE);
            this.pnlProfiles.Controls.Add(this.comboProfiles);
            this.pnlProfiles.Location = new System.Drawing.Point(12, 12);
            this.pnlProfiles.Name = "pnlProfiles";
            this.pnlProfiles.Size = new System.Drawing.Size(357, 71);
            this.pnlProfiles.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(271, 31);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(190, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pnlDirections
            // 
            this.pnlDirections.Controls.Add(this.btnRight);
            this.pnlDirections.Controls.Add(this.btnLeft);
            this.pnlDirections.Controls.Add(this.btnDown);
            this.pnlDirections.Controls.Add(this.btnUp);
            this.pnlDirections.Controls.Add(this.lblRightNE);
            this.pnlDirections.Controls.Add(this.lblLeftNE);
            this.pnlDirections.Controls.Add(this.lblDownNE);
            this.pnlDirections.Controls.Add(this.lblUpNE);
            this.pnlDirections.Location = new System.Drawing.Point(12, 90);
            this.pnlDirections.Name = "pnlDirections";
            this.pnlDirections.Size = new System.Drawing.Size(164, 225);
            this.pnlDirections.TabIndex = 3;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(86, 144);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 7;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(86, 99);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 6;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(86, 57);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(86, 18);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblRightNE
            // 
            this.lblRightNE.AutoSize = true;
            this.lblRightNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightNE.Location = new System.Drawing.Point(7, 144);
            this.lblRightNE.Name = "lblRightNE";
            this.lblRightNE.Size = new System.Drawing.Size(58, 24);
            this.lblRightNE.TabIndex = 3;
            this.lblRightNE.Text = "Right:";
            // 
            // lblLeftNE
            // 
            this.lblLeftNE.AutoSize = true;
            this.lblLeftNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftNE.Location = new System.Drawing.Point(7, 99);
            this.lblLeftNE.Name = "lblLeftNE";
            this.lblLeftNE.Size = new System.Drawing.Size(44, 24);
            this.lblLeftNE.TabIndex = 2;
            this.lblLeftNE.Text = "Left:";
            // 
            // lblDownNE
            // 
            this.lblDownNE.AutoSize = true;
            this.lblDownNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownNE.Location = new System.Drawing.Point(7, 57);
            this.lblDownNE.Name = "lblDownNE";
            this.lblDownNE.Size = new System.Drawing.Size(64, 24);
            this.lblDownNE.TabIndex = 1;
            this.lblDownNE.Text = "Down:";
            // 
            // lblUpNE
            // 
            this.lblUpNE.AutoSize = true;
            this.lblUpNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpNE.Location = new System.Drawing.Point(7, 18);
            this.lblUpNE.Name = "lblUpNE";
            this.lblUpNE.Size = new System.Drawing.Size(39, 24);
            this.lblUpNE.TabIndex = 0;
            this.lblUpNE.Text = "Up:";
            // 
            // pnlClicks
            // 
            this.pnlClicks.Controls.Add(this.chkReturnRC);
            this.pnlClicks.Controls.Add(this.chkReturnLC);
            this.pnlClicks.Controls.Add(this.btnRC);
            this.pnlClicks.Controls.Add(this.btnLC);
            this.pnlClicks.Controls.Add(this.lblRCNE);
            this.pnlClicks.Controls.Add(this.lblLC);
            this.pnlClicks.Location = new System.Drawing.Point(194, 90);
            this.pnlClicks.Name = "pnlClicks";
            this.pnlClicks.Size = new System.Drawing.Size(337, 112);
            this.pnlClicks.TabIndex = 8;
            // 
            // chkReturnRC
            // 
            this.chkReturnRC.AutoSize = true;
            this.chkReturnRC.Location = new System.Drawing.Point(217, 54);
            this.chkReturnRC.Name = "chkReturnRC";
            this.chkReturnRC.Size = new System.Drawing.Size(108, 17);
            this.chkReturnRC.TabIndex = 11;
            this.chkReturnRC.Text = "Return To Center";
            this.chkReturnRC.UseVisualStyleBackColor = true;
            // 
            // chkReturnLC
            // 
            this.chkReturnLC.AutoSize = true;
            this.chkReturnLC.Location = new System.Drawing.Point(217, 22);
            this.chkReturnLC.Name = "chkReturnLC";
            this.chkReturnLC.Size = new System.Drawing.Size(104, 17);
            this.chkReturnLC.TabIndex = 10;
            this.chkReturnLC.Text = "Return to Center";
            this.chkReturnLC.UseVisualStyleBackColor = true;
            // 
            // btnRC
            // 
            this.btnRC.Location = new System.Drawing.Point(122, 54);
            this.btnRC.Name = "btnRC";
            this.btnRC.Size = new System.Drawing.Size(75, 23);
            this.btnRC.TabIndex = 9;
            this.btnRC.UseVisualStyleBackColor = true;
            this.btnRC.Click += new System.EventHandler(this.btnRC_Click);
            // 
            // btnLC
            // 
            this.btnLC.Location = new System.Drawing.Point(122, 18);
            this.btnLC.Name = "btnLC";
            this.btnLC.Size = new System.Drawing.Size(75, 23);
            this.btnLC.TabIndex = 3;
            this.btnLC.UseVisualStyleBackColor = true;
            this.btnLC.Click += new System.EventHandler(this.btnLC_Click);
            // 
            // lblRCNE
            // 
            this.lblRCNE.AutoSize = true;
            this.lblRCNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRCNE.Location = new System.Drawing.Point(12, 54);
            this.lblRCNE.Name = "lblRCNE";
            this.lblRCNE.Size = new System.Drawing.Size(104, 24);
            this.lblRCNE.TabIndex = 2;
            this.lblRCNE.Text = "Right-Click:";
            // 
            // lblLC
            // 
            this.lblLC.AutoSize = true;
            this.lblLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLC.Location = new System.Drawing.Point(12, 18);
            this.lblLC.Name = "lblLC";
            this.lblLC.Size = new System.Drawing.Size(90, 24);
            this.lblLC.TabIndex = 0;
            this.lblLC.Text = "Left-Click:";
            // 
            // pnlDeadzone
            // 
            this.pnlDeadzone.Controls.Add(this.cbOtherOps);
            this.pnlDeadzone.Controls.Add(this.txtDeadzoneSize);
            this.pnlDeadzone.Controls.Add(this.lblSizeNE);
            this.pnlDeadzone.Controls.Add(this.lblDeadzoneNE);
            this.pnlDeadzone.Location = new System.Drawing.Point(194, 209);
            this.pnlDeadzone.Name = "pnlDeadzone";
            this.pnlDeadzone.Size = new System.Drawing.Size(213, 100);
            this.pnlDeadzone.TabIndex = 9;
            // 
            // cbOtherOps
            // 
            this.cbOtherOps.AutoSize = true;
            this.cbOtherOps.Location = new System.Drawing.Point(119, 49);
            this.cbOtherOps.Name = "cbOtherOps";
            this.cbOtherOps.Size = new System.Drawing.Size(91, 17);
            this.cbOtherOps.TabIndex = 7;
            this.cbOtherOps.Text = "Other Options";
            this.cbOtherOps.UseVisualStyleBackColor = true;
            // 
            // txtDeadzoneSize
            // 
            this.txtDeadzoneSize.Location = new System.Drawing.Point(38, 49);
            this.txtDeadzoneSize.Name = "txtDeadzoneSize";
            this.txtDeadzoneSize.Size = new System.Drawing.Size(52, 20);
            this.txtDeadzoneSize.TabIndex = 6;
            // 
            // lblSizeNE
            // 
            this.lblSizeNE.AutoSize = true;
            this.lblSizeNE.Location = new System.Drawing.Point(5, 52);
            this.lblSizeNE.Name = "lblSizeNE";
            this.lblSizeNE.Size = new System.Drawing.Size(27, 13);
            this.lblSizeNE.TabIndex = 5;
            this.lblSizeNE.Text = "Size";
            // 
            // lblDeadzoneNE
            // 
            this.lblDeadzoneNE.AutoSize = true;
            this.lblDeadzoneNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadzoneNE.Location = new System.Drawing.Point(4, 9);
            this.lblDeadzoneNE.Name = "lblDeadzoneNE";
            this.lblDeadzoneNE.Size = new System.Drawing.Size(97, 24);
            this.lblDeadzoneNE.TabIndex = 0;
            this.lblDeadzoneNE.Text = "Deadzone";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlOrigin
            // 
            this.pnlOrigin.Controls.Add(this.lblOriginYNE);
            this.pnlOrigin.Controls.Add(this.lblOriginXNE);
            this.pnlOrigin.Controls.Add(this.txtOriginY);
            this.pnlOrigin.Controls.Add(this.txtOriginX);
            this.pnlOrigin.Controls.Add(this.lblOriginNE);
            this.pnlOrigin.Location = new System.Drawing.Point(413, 209);
            this.pnlOrigin.Name = "pnlOrigin";
            this.pnlOrigin.Size = new System.Drawing.Size(135, 100);
            this.pnlOrigin.TabIndex = 11;
            // 
            // lblOriginYNE
            // 
            this.lblOriginYNE.AutoSize = true;
            this.lblOriginYNE.Location = new System.Drawing.Point(4, 65);
            this.lblOriginYNE.Name = "lblOriginYNE";
            this.lblOriginYNE.Size = new System.Drawing.Size(44, 13);
            this.lblOriginYNE.TabIndex = 5;
            this.lblOriginYNE.Text = "Origin Y";
            // 
            // lblOriginXNE
            // 
            this.lblOriginXNE.AutoSize = true;
            this.lblOriginXNE.Location = new System.Drawing.Point(4, 39);
            this.lblOriginXNE.Name = "lblOriginXNE";
            this.lblOriginXNE.Size = new System.Drawing.Size(44, 13);
            this.lblOriginXNE.TabIndex = 4;
            this.lblOriginXNE.Text = "Origin X";
            // 
            // txtOriginY
            // 
            this.txtOriginY.Location = new System.Drawing.Point(59, 62);
            this.txtOriginY.Name = "txtOriginY";
            this.txtOriginY.Size = new System.Drawing.Size(59, 20);
            this.txtOriginY.TabIndex = 3;
            // 
            // txtOriginX
            // 
            this.txtOriginX.Location = new System.Drawing.Point(59, 36);
            this.txtOriginX.Name = "txtOriginX";
            this.txtOriginX.Size = new System.Drawing.Size(59, 20);
            this.txtOriginX.TabIndex = 2;
            // 
            // lblOriginNE
            // 
            this.lblOriginNE.AutoSize = true;
            this.lblOriginNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginNE.Location = new System.Drawing.Point(3, 9);
            this.lblOriginNE.Name = "lblOriginNE";
            this.lblOriginNE.Size = new System.Drawing.Size(61, 24);
            this.lblOriginNE.TabIndex = 1;
            this.lblOriginNE.Text = "Origin";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(649, 271);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(130, 38);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 327);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pnlOrigin);
            this.Controls.Add(this.pnlDeadzone);
            this.Controls.Add(this.pnlClicks);
            this.Controls.Add(this.pnlDirections);
            this.Controls.Add(this.pnlProfiles);
            this.Name = "Form2";
            this.Text = "New Config";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.pnlProfiles.ResumeLayout(false);
            this.pnlProfiles.PerformLayout();
            this.pnlDirections.ResumeLayout(false);
            this.pnlDirections.PerformLayout();
            this.pnlClicks.ResumeLayout(false);
            this.pnlClicks.PerformLayout();
            this.pnlDeadzone.ResumeLayout(false);
            this.pnlDeadzone.PerformLayout();
            this.pnlOrigin.ResumeLayout(false);
            this.pnlOrigin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.Label lblProfileNE;
        private System.Windows.Forms.Panel pnlProfiles;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlDirections;
        private System.Windows.Forms.Label lblRightNE;
        private System.Windows.Forms.Label lblLeftNE;
        private System.Windows.Forms.Label lblDownNE;
        private System.Windows.Forms.Label lblUpNE;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel pnlClicks;
        private System.Windows.Forms.Label lblRCNE;
        private System.Windows.Forms.Label lblLC;
        private System.Windows.Forms.Button btnLC;
        private System.Windows.Forms.Button btnRC;
        private System.Windows.Forms.CheckBox chkReturnRC;
        private System.Windows.Forms.CheckBox chkReturnLC;
        private System.Windows.Forms.Panel pnlDeadzone;
        private System.Windows.Forms.TextBox txtDeadzoneSize;
        private System.Windows.Forms.Label lblSizeNE;
        private System.Windows.Forms.Label lblDeadzoneNE;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox cbOtherOps;
        private System.Windows.Forms.Panel pnlOrigin;
        private System.Windows.Forms.Label lblOriginYNE;
        private System.Windows.Forms.Label lblOriginXNE;
        private System.Windows.Forms.TextBox txtOriginY;
        private System.Windows.Forms.TextBox txtOriginX;
        private System.Windows.Forms.Label lblOriginNE;
        private System.Windows.Forms.Button btnSubmit;
    }
}