namespace Schellings_model_project_I
{
    partial class SchellingForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPictureBox = new System.Windows.Forms.PictureBox();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.parametersPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeSlider = new System.Windows.Forms.TrackBar();
            this.toleranceLabel = new System.Windows.Forms.Label();
            this.toleranceSlider = new System.Windows.Forms.TrackBar();
            this.color1Label = new System.Windows.Forms.Label();
            this.color1Button = new System.Windows.Forms.Button();
            this.color2Label = new System.Windows.Forms.Label();
            this.color2Button = new System.Windows.Forms.Button();
            this.cellRatioLabel = new System.Windows.Forms.Label();
            this.cellRatioSlider = new System.Windows.Forms.TrackBar();
            this.cellDistModeLabel = new System.Windows.Forms.Label();
            this.cellDistModeGroupBox = new System.Windows.Forms.GroupBox();
            this.cellDistManualButton = new System.Windows.Forms.RadioButton();
            this.cellDistRandButton = new System.Windows.Forms.RadioButton();
            this.emptyRatioLabel = new System.Windows.Forms.Label();
            this.emptyRatioSlider = new System.Windows.Forms.TrackBar();
            this.color1Dialog = new System.Windows.Forms.ColorDialog();
            this.color2Dialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridPictureBox)).BeginInit();
            this.layoutPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.parametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellRatioSlider)).BeginInit();
            this.cellDistModeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptyRatioSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPictureBox
            // 
            this.gridPictureBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.gridPictureBox.Location = new System.Drawing.Point(3, 45);
            this.gridPictureBox.Name = "gridPictureBox";
            this.gridPictureBox.Size = new System.Drawing.Size(559, 395);
            this.gridPictureBox.TabIndex = 0;
            this.gridPictureBox.TabStop = false;
            // 
            // layoutPanel
            // 
            this.layoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.layoutPanel.Controls.Add(this.gridPictureBox, 0, 1);
            this.layoutPanel.Controls.Add(this.titleLabel, 0, 0);
            this.layoutPanel.Controls.Add(this.buttonsPanel, 1, 0);
            this.layoutPanel.Controls.Add(this.parametersPanel, 1, 1);
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.73684F));
            this.layoutPanel.Size = new System.Drawing.Size(1266, 802);
            this.layoutPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(265, 16);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Schelling\'s model of segregation simulation";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.ColumnCount = 3;
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.buttonsPanel.Controls.Add(this.startButton, 0, 0);
            this.buttonsPanel.Controls.Add(this.stopButton, 1, 0);
            this.buttonsPanel.Controls.Add(this.resetButton, 2, 0);
            this.buttonsPanel.Location = new System.Drawing.Point(907, 3);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.RowCount = 1;
            this.buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsPanel.Size = new System.Drawing.Size(200, 36);
            this.buttonsPanel.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "button1";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(69, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(60, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "button1";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(135, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(62, 23);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "button1";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // parametersPanel
            // 
            this.parametersPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.parametersPanel.ColumnCount = 2;
            this.parametersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.parametersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.parametersPanel.Controls.Add(this.sizeLabel, 0, 0);
            this.parametersPanel.Controls.Add(this.sizeSlider, 1, 0);
            this.parametersPanel.Controls.Add(this.toleranceLabel, 0, 1);
            this.parametersPanel.Controls.Add(this.toleranceSlider, 1, 1);
            this.parametersPanel.Controls.Add(this.color1Label, 0, 2);
            this.parametersPanel.Controls.Add(this.color1Button, 1, 2);
            this.parametersPanel.Controls.Add(this.color2Label, 0, 3);
            this.parametersPanel.Controls.Add(this.color2Button, 1, 3);
            this.parametersPanel.Controls.Add(this.cellRatioLabel, 0, 5);
            this.parametersPanel.Controls.Add(this.cellRatioSlider, 1, 5);
            this.parametersPanel.Controls.Add(this.cellDistModeLabel, 0, 4);
            this.parametersPanel.Controls.Add(this.cellDistModeGroupBox, 1, 4);
            this.parametersPanel.Controls.Add(this.emptyRatioLabel, 0, 6);
            this.parametersPanel.Controls.Add(this.emptyRatioSlider, 1, 6);
            this.parametersPanel.Location = new System.Drawing.Point(907, 64);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.RowCount = 7;
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.parametersPanel.Size = new System.Drawing.Size(356, 716);
            this.parametersPanel.TabIndex = 3;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(3, 0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(44, 16);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "label1";
            // 
            // sizeSlider
            // 
            this.sizeSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sizeSlider.Location = new System.Drawing.Point(166, 23);
            this.sizeSlider.Name = "sizeSlider";
            this.sizeSlider.Size = new System.Drawing.Size(130, 56);
            this.sizeSlider.TabIndex = 1;
            this.sizeSlider.Scroll += new System.EventHandler(this.sizeSlider_Scroll);
            // 
            // toleranceLabel
            // 
            this.toleranceLabel.AutoSize = true;
            this.toleranceLabel.Location = new System.Drawing.Point(3, 102);
            this.toleranceLabel.Name = "toleranceLabel";
            this.toleranceLabel.Size = new System.Drawing.Size(44, 16);
            this.toleranceLabel.TabIndex = 2;
            this.toleranceLabel.Text = "label1";
            // 
            // toleranceSlider
            // 
            this.toleranceSlider.Location = new System.Drawing.Point(109, 105);
            this.toleranceSlider.Name = "toleranceSlider";
            this.toleranceSlider.Size = new System.Drawing.Size(104, 56);
            this.toleranceSlider.TabIndex = 3;
            this.toleranceSlider.Scroll += new System.EventHandler(this.toleranceSlider_Scroll);
            // 
            // color1Label
            // 
            this.color1Label.AutoSize = true;
            this.color1Label.Location = new System.Drawing.Point(3, 204);
            this.color1Label.Name = "color1Label";
            this.color1Label.Size = new System.Drawing.Size(44, 16);
            this.color1Label.TabIndex = 4;
            this.color1Label.Text = "label1";
            // 
            // color1Button
            // 
            this.color1Button.Location = new System.Drawing.Point(109, 207);
            this.color1Button.Name = "color1Button";
            this.color1Button.Size = new System.Drawing.Size(75, 23);
            this.color1Button.TabIndex = 5;
            this.color1Button.Text = "button1";
            this.color1Button.UseVisualStyleBackColor = true;
            this.color1Button.Click += new System.EventHandler(this.color1Button_Click);
            // 
            // color2Label
            // 
            this.color2Label.AutoSize = true;
            this.color2Label.Location = new System.Drawing.Point(3, 306);
            this.color2Label.Name = "color2Label";
            this.color2Label.Size = new System.Drawing.Size(44, 16);
            this.color2Label.TabIndex = 6;
            this.color2Label.Text = "label1";
            // 
            // color2Button
            // 
            this.color2Button.Location = new System.Drawing.Point(109, 309);
            this.color2Button.Name = "color2Button";
            this.color2Button.Size = new System.Drawing.Size(75, 23);
            this.color2Button.TabIndex = 7;
            this.color2Button.Text = "button1";
            this.color2Button.UseVisualStyleBackColor = true;
            this.color2Button.Click += new System.EventHandler(this.color2Button_Click);
            // 
            // cellRatioLabel
            // 
            this.cellRatioLabel.AutoSize = true;
            this.cellRatioLabel.Location = new System.Drawing.Point(3, 510);
            this.cellRatioLabel.Name = "cellRatioLabel";
            this.cellRatioLabel.Size = new System.Drawing.Size(44, 16);
            this.cellRatioLabel.TabIndex = 8;
            this.cellRatioLabel.Text = "label1";
            // 
            // cellRatioSlider
            // 
            this.cellRatioSlider.Location = new System.Drawing.Point(109, 513);
            this.cellRatioSlider.Name = "cellRatioSlider";
            this.cellRatioSlider.Size = new System.Drawing.Size(187, 56);
            this.cellRatioSlider.TabIndex = 9;
            this.cellRatioSlider.Scroll += new System.EventHandler(this.cellRatioSlider_Scroll);
            // 
            // cellDistModeLabel
            // 
            this.cellDistModeLabel.AutoSize = true;
            this.cellDistModeLabel.Location = new System.Drawing.Point(3, 408);
            this.cellDistModeLabel.Name = "cellDistModeLabel";
            this.cellDistModeLabel.Size = new System.Drawing.Size(44, 16);
            this.cellDistModeLabel.TabIndex = 10;
            this.cellDistModeLabel.Text = "label1";
            // 
            // cellDistModeGroupBox
            // 
            this.cellDistModeGroupBox.Controls.Add(this.cellDistManualButton);
            this.cellDistModeGroupBox.Controls.Add(this.cellDistRandButton);
            this.cellDistModeGroupBox.Location = new System.Drawing.Point(109, 411);
            this.cellDistModeGroupBox.Name = "cellDistModeGroupBox";
            this.cellDistModeGroupBox.Size = new System.Drawing.Size(200, 96);
            this.cellDistModeGroupBox.TabIndex = 11;
            this.cellDistModeGroupBox.TabStop = false;
            this.cellDistModeGroupBox.Text = "groupBox1";
            // 
            // cellDistManualButton
            // 
            this.cellDistManualButton.AutoSize = true;
            this.cellDistManualButton.Location = new System.Drawing.Point(26, 61);
            this.cellDistManualButton.Name = "cellDistManualButton";
            this.cellDistManualButton.Size = new System.Drawing.Size(103, 20);
            this.cellDistManualButton.TabIndex = 1;
            this.cellDistManualButton.TabStop = true;
            this.cellDistManualButton.Text = "radioButton2";
            this.cellDistManualButton.UseVisualStyleBackColor = true;
            this.cellDistManualButton.CheckedChanged += new System.EventHandler(this.cellDistManualButton_CheckedChanged);
            // 
            // cellDistRandButton
            // 
            this.cellDistRandButton.AutoSize = true;
            this.cellDistRandButton.Location = new System.Drawing.Point(26, 21);
            this.cellDistRandButton.Name = "cellDistRandButton";
            this.cellDistRandButton.Size = new System.Drawing.Size(103, 20);
            this.cellDistRandButton.TabIndex = 0;
            this.cellDistRandButton.TabStop = true;
            this.cellDistRandButton.Text = "radioButton1";
            this.cellDistRandButton.UseVisualStyleBackColor = true;
            this.cellDistRandButton.CheckedChanged += new System.EventHandler(this.cellDistRandButton_CheckedChanged);
            // 
            // emptyRatioLabel
            // 
            this.emptyRatioLabel.AutoSize = true;
            this.emptyRatioLabel.Location = new System.Drawing.Point(3, 612);
            this.emptyRatioLabel.Name = "emptyRatioLabel";
            this.emptyRatioLabel.Size = new System.Drawing.Size(44, 16);
            this.emptyRatioLabel.TabIndex = 12;
            this.emptyRatioLabel.Text = "label1";
            // 
            // emptyRatioSlider
            // 
            this.emptyRatioSlider.Location = new System.Drawing.Point(109, 615);
            this.emptyRatioSlider.Name = "emptyRatioSlider";
            this.emptyRatioSlider.Size = new System.Drawing.Size(104, 56);
            this.emptyRatioSlider.TabIndex = 13;
            this.emptyRatioSlider.Scroll += new System.EventHandler(this.emptyRatioSlider_Scroll);
            // 
            // SchellingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1412, 761);
            this.Controls.Add(this.layoutPanel);
            this.Name = "SchellingForm";
            this.Text = "Schellings_model_of_segregation";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridPictureBox)).EndInit();
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.parametersPanel.ResumeLayout(false);
            this.parametersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellRatioSlider)).EndInit();
            this.cellDistModeGroupBox.ResumeLayout(false);
            this.cellDistModeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptyRatioSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gridPictureBox;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TableLayoutPanel parametersPanel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.TrackBar sizeSlider;
        private System.Windows.Forms.Label toleranceLabel;
        private System.Windows.Forms.TrackBar toleranceSlider;
        private System.Windows.Forms.Label color1Label;
        private System.Windows.Forms.ColorDialog color1Dialog;
        private System.Windows.Forms.Button color1Button;
        private System.Windows.Forms.Label color2Label;
        private System.Windows.Forms.Button color2Button;
        private System.Windows.Forms.ColorDialog color2Dialog;
        private System.Windows.Forms.Label cellRatioLabel;
        private System.Windows.Forms.TrackBar cellRatioSlider;
        private System.Windows.Forms.Label cellDistModeLabel;
        private System.Windows.Forms.GroupBox cellDistModeGroupBox;
        private System.Windows.Forms.RadioButton cellDistManualButton;
        private System.Windows.Forms.RadioButton cellDistRandButton;
        private System.Windows.Forms.Label emptyRatioLabel;
        private System.Windows.Forms.TrackBar emptyRatioSlider;
    }
}

