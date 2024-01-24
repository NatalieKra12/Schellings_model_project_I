using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

//Used Controls:
// **PictureBox gridPictureBox to display cells


namespace Schellings_model_project_I
{

    public partial class SchellingForm : Form
    {
        //Class declaration
        Grid grid;
        Parameters parameters;
        System.Windows.Forms.Timer timer;
        //SchellingForm constructor
        public SchellingForm()
        {
            parameters = new Parameters(); // getting info from GUI
            InitializeComponent();
            addElementsToPanel(); //adding controls to TableLayoutPanel layoutPanel
            panelSettings(); //other settings of layoutPanel
            elemetnsAdjustSize(); //adjusting size of layoutPanel (+controls) initially
            Reset(); //intial reset and redrawing of grid
            this.Resize += Form1_Resize; //starting event listening to change of Form1 size
 
        }

        //GUI setup
        public void addElementsToPanel() //adding controls to TableLayoutPanel layoutPanel
        {
            layoutPanel.Controls.Add(gridPictureBox, 0, 1);
            layoutPanel.Controls.Add(titleLabel, 0, 0);
            layoutPanel.Controls.Add(buttonsPanel, 1, 0);
            //
            buttonsPanel.Controls.Add(startButton, 0, 0);
            buttonsPanel.Controls.Add(stopButton, 1, 0);
            buttonsPanel.Controls.Add(resetButton, 2, 0);
            //
            layoutPanel.Controls.Add(parametersPanel, 1, 1);
            //
            parametersPanel.Controls.Add(sizeLabel, 0, 0);
            parametersPanel.Controls.Add(sizeSlider, 1, 0);
            parametersPanel.Controls.Add(toleranceLabel, 0, 1);
            parametersPanel.Controls.Add(toleranceSlider, 1, 1);
            parametersPanel.Controls.Add(color1Label, 0, 2);
            parametersPanel.Controls.Add(color1Button, 1, 2);
            parametersPanel.Controls.Add(color2Label, 0, 3);
            parametersPanel.Controls.Add(color2Button, 1, 3);
            parametersPanel.Controls.Add(cellDistModeLabel, 0, 4);
            parametersPanel.Controls.Add(cellDistModeGroupBox, 1, 4);
            //
            cellDistModeGroupBox.Controls.Add(cellDistRandButton);
            cellDistModeGroupBox.Controls.Add(cellDistManualButton);
            //
            parametersPanel.Controls.Add(cellRatioLabel, 0, 5);
            parametersPanel.Controls.Add(cellRatioSlider, 1, 5);
            parametersPanel.Controls.Add(emptyRatioLabel, 0, 6);
            parametersPanel.Controls.Add(emptyRatioSlider, 1, 6);
        }
        public void panelSettings() //setting of layoutPanel and position of elements
        {
            layoutPanel.BackColor = Color.Black;
            //
            layoutPanel.Dock = DockStyle.Fill;
            //
            gridPictureBox.Dock = DockStyle.Fill;
            gridPictureBoxProperties();
            titleLabel.Dock = DockStyle.Fill;
            titleLabelProperties();
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanelProperties();
            //
            startButton.Dock = DockStyle.Fill;
            stopButton.Dock = DockStyle.Fill;
            resetButton.Dock = DockStyle.Fill;
            //
            parametersPanel.Dock = DockStyle.Fill;
            parametersPanelProperties();
            //
            sizeLabel.Dock = DockStyle.Fill;
            sizeSlider.Dock = DockStyle.Fill;
            sizeSlider.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            //
            toleranceLabel.Dock = DockStyle.Fill;
            toleranceSlider.Dock = DockStyle.Fill;
            toleranceSlider.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            //
            color1Label.Dock = DockStyle.Fill;
            color1Button.Dock = DockStyle.Fill;
            //
            color2Label.Dock = DockStyle.Fill;
            color2Button.Dock = DockStyle.Fill;
            //
            cellDistModeLabel.Dock = DockStyle.Fill;
            cellDistModeGroupBox.Dock = DockStyle.Fill;
            //
            cellRatioLabel.Dock = DockStyle.Fill;
            cellRatioSlider.Dock = DockStyle.Fill;
            cellRatioSlider.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            //
            emptyRatioLabel.Dock = DockStyle.Fill;
            emptyRatioSlider.Dock = DockStyle.Fill;
            emptyRatioSlider.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }

        //picture box setup
        public void gridPictureBoxProperties()
        {
            gridPictureBox.BackColor = Color.Black;
        }

        //title label
        public void titleLabelProperties()
        {
            titleLabel.BackColor = Color.Black;
            titleLabel.ForeColor = Color.LightGray;
            titleLabel.Font = new Font("Sans", 14);
            titleLabel.Text = "Schelling's model of segregation";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
        }
        public void buttonsPanelProperties()
        {
            buttonsPanel.BackColor = Color.Black;
            //
            startButton.Text = "Start";
            startButton.TextAlign = ContentAlignment.MiddleCenter;
            startButton.Font = new Font("Sans", 9);
            startButton.ForeColor = Color.Black;
            startButton.BackColor = Color.LightGray;
            //
            stopButton.Text = "Stop";
            stopButton.TextAlign = ContentAlignment.MiddleCenter;
            stopButton.Font = new Font("Sans", 9);
            stopButton.ForeColor = Color.Black;
            stopButton.BackColor = Color.LightGray;
            //
            resetButton.Text = "Reset";
            resetButton.TextAlign = ContentAlignment.MiddleCenter;
            resetButton.Font = new Font("Sans", 9);
            resetButton.ForeColor = Color.Black;
            resetButton.BackColor = Color.LightGray;
        }
        public void parametersPanelProperties()
        {
            parametersPanel.BackColor = Color.Black;
            //
            sizeLabel.BackColor = Color.Black;
            sizeLabel.ForeColor = Color.LightGray;
            sizeLabel.Font = new Font("Sans", 12);
            sizeLabel.Text = "Size 5x5";
            sizeLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            sizeSlider.Minimum = 5;
            sizeSlider.Maximum = 100;
            sizeSlider.Value = 5;
            sizeSlider.TickFrequency = 20;
            sizeSlider.SmallChange = 1;
            sizeSlider.LargeChange = 10;
            sizeSlider.TickStyle = TickStyle.BottomRight;
            //
            toleranceLabel.BackColor = Color.Black;
            toleranceLabel.ForeColor = Color.LightGray;
            toleranceLabel.Font = new Font("Sans", 12);
            toleranceLabel.Text = "Tolerance 50%";
            toleranceLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            toleranceSlider.Minimum = 0;
            toleranceSlider.Maximum = 100;
            toleranceSlider.Value = 50;
            toleranceSlider.TickFrequency = 20;
            toleranceSlider.SmallChange = 1;
            toleranceSlider.LargeChange = 10;
            toleranceSlider.TickStyle = TickStyle.BottomRight;
            //
            color1Label.BackColor = Color.Black;
            color1Label.ForeColor = Color.LightGray;
            color1Label.Font = new Font("Sans", 12);
            color1Label.Text = "Color 1";
            color1Label.TextAlign = ContentAlignment.MiddleLeft;
            //
            color1Button.Text = "Choose Color";
            color1Button.TextAlign = ContentAlignment.MiddleCenter;
            color1Button.Font = new Font("Sans", 9);
            color1Button.ForeColor = Color.Black;
            color1Button.BackColor = Color.LightGreen;
            //
            color2Label.BackColor = Color.Black;
            color2Label.ForeColor = Color.LightGray;
            color2Label.Font = new Font("Sans", 12);
            color2Label.Text = "Color 2";
            color2Label.TextAlign = ContentAlignment.MiddleLeft;
            //
            color2Button.Text = "Choose Color";
            color2Button.TextAlign = ContentAlignment.MiddleCenter;
            color2Button.Font = new Font("Sans", 9);
            color2Button.ForeColor = Color.Black;
            color2Button.BackColor = Color.Turquoise;
            //
            cellDistModeLabel.BackColor = Color.Black;
            cellDistModeLabel.ForeColor = Color.LightGray;
            cellDistModeLabel.Font = new Font("Sans", 12);
            cellDistModeLabel.Text = "Cell initial grid mode";
            cellDistModeLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            cellDistModeGroupBox.Text = "";
            cellDistModeGroupBox.FlatStyle = FlatStyle.Flat;
            //
            cellDistRandButton.Text = "Random";
            cellDistRandButton.Font = new Font("Sans", 12);
            cellDistRandButton.ForeColor = Color.LightGray;
            cellDistRandButton.Checked = true;
            //
            cellDistManualButton.Text = "Grid example";
            cellDistManualButton.Font = new Font("Sans", 12);
            cellDistManualButton.ForeColor = Color.LightGray;
            cellDistManualButton.Checked = false;
            //
            cellRatioLabel.BackColor = Color.Black;
            cellRatioLabel.ForeColor = Color.LightGray;
            cellRatioLabel.Font = new Font("Sans", 12);
            cellRatioLabel.Text = "Cells ratio 50/50";
            cellRatioLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            cellRatioSlider.Minimum = 0;
            cellRatioSlider.Maximum = 100;
            cellRatioSlider.Value = 50;
            cellRatioSlider.TickFrequency = 20;
            cellRatioSlider.SmallChange = 1;
            cellRatioSlider.LargeChange = 10;
            cellRatioSlider.TickStyle = TickStyle.BottomRight;
            //
            emptyRatioLabel.BackColor = Color.Black;
            emptyRatioLabel.ForeColor = Color.LightGray;
            emptyRatioLabel.Font = new Font("Sans", 12);
            emptyRatioLabel.Text = "Empty cells 50%";
            emptyRatioLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            emptyRatioSlider.Minimum = 0;
            emptyRatioSlider.Maximum = 100;
            emptyRatioSlider.Value = 50;
            emptyRatioSlider.TickFrequency = 20;
            emptyRatioSlider.SmallChange = 1;
            emptyRatioSlider.LargeChange = 10;
            emptyRatioSlider.TickStyle = TickStyle.BottomRight;
        }
        public void elemetnsAdjustSize() //adjusting size of layoutPanel (+controls) initially
        {
            layoutPanel.Size = new System.Drawing.Size(this.Width, this.Height);
        }
        private void Form1_Resize(object sender, EventArgs e) //event when Form1 size changes
        {
            elemetnsAdjustSize(); //adjusting size of GUI
            Reset(); //resettiung grid
        }
        private void sizeSlider_Scroll(object sender, EventArgs e)  //getting number of cells from slider
        {
            string labelText = "Size " + sizeSlider.Value + "x" + sizeSlider.Value;
            sizeLabel.Text = labelText;
            parameters.cellsNumber = sizeSlider.Value;
            Reset();
        }
        private void toleranceSlider_Scroll(object sender, EventArgs e) //getting tolerance value from scroll
        {
            string labelText = "Tolerance " + toleranceSlider.Value + "%";
            toleranceLabel.Text = labelText;
            parameters.tolerance = toleranceSlider.Value;
            Reset();
        }
        private void color1Button_Click(object sender, EventArgs e) //getting color no 1 of cells 
        {
            if (color1Dialog.ShowDialog() == DialogResult.OK)
            { 
                Color color1 = color1Dialog.Color;
                color1Button.BackColor = color1;
                parameters.color1 = color1;
                Reset();
            }
        }
        private void color2Button_Click(object sender, EventArgs e) //getting color no 2 of cells
        {
            if (color2Dialog.ShowDialog() == DialogResult.OK)
            {
                Color color2 = color2Dialog.Color;
                color2Button.BackColor = color2;
                parameters.color2 = color2;
                Reset();
            }
        }
        private void cellDistRandButton_CheckedChanged(object sender, EventArgs e)  //getting info how cells are initialized (randomly)
        {
            parameters.color1 = Color.LightGreen;
            parameters.color2 = Color.Turquoise;
            sizeSlider.Enabled = true;
            color1Button.Enabled = true;
            color2Button.Enabled = true;
            toleranceSlider.Enabled = true;
            cellRatioSlider.Enabled = true;
            emptyRatioSlider.Enabled = true;
            Reset();
        }

        private void cellDistManualButton_CheckedChanged(object sender, EventArgs e)    //getting info how cells are initialized (randomly)
        {
            parameters.cellsDistMode = 1;
            parameters.cellsNumber = 30;
            parameters.tolerance = 40;
            parameters.color1 = Color.Aqua;
            parameters.color2 = Color.Navy;
            parameters.color1CellsRatio = 50;
            parameters.emptyCellsRatio = 10;
            string labelSizeText = "Size " + 30 + "x" + 30;
            sizeLabel.Text = labelSizeText;
            sizeSlider.Value = 30;
            string labelToleranceText = "Tolerance " + 40 + "%";
            toleranceLabel.Text = labelToleranceText;
            toleranceSlider.Value = 40;
            string labelRatioText = "Cells ratio " + 50 + "/" + 50;
            cellRatioLabel.Text = labelRatioText;
            cellRatioSlider.Value = 50;
            string labelEmptyText = "Empty cells " + 10 + "%";
            emptyRatioLabel.Text = labelEmptyText;
            emptyRatioSlider.Value = 20;
            sizeSlider.Enabled = false;
            color1Button.Enabled = false;
            color2Button.Enabled = false;
            toleranceSlider.Enabled = false;
            cellRatioSlider.Enabled = false;
            emptyRatioSlider.Enabled = false;
            Reset();
        }

        private void cellRatioSlider_Scroll(object sender, EventArgs e) //getting info on color 1 to cell 2 ratio
        {
            string labelText = "Cells ratio " + cellRatioSlider.Value + "/" + (100 - cellRatioSlider.Value);
            cellRatioLabel.Text = labelText;
            parameters.color1CellsRatio = cellRatioSlider.Value;
            Reset();
        }

        private void emptyRatioSlider_Scroll(object sender, EventArgs e) // getting info on color to empty cells ratio
        {
            string labelText = "Empty cells " + emptyRatioSlider.Value + "%";
            emptyRatioLabel.Text = labelText;
            parameters.emptyCellsRatio = emptyRatioSlider.Value;
            Reset();
        }

        private void enableSettings()
        {
            sizeSlider.Enabled = true;
            toleranceSlider.Enabled = true;
            color1Button.Enabled = true;
            color2Button.Enabled = true;
            cellDistRandButton.Enabled = true;
            cellDistManualButton.Enabled = true;
            cellRatioSlider.Enabled = true;
            emptyRatioSlider.Enabled = true;
        }
        private void disableSettings()
        {
            sizeSlider.Enabled = false;
            toleranceSlider.Enabled = false;
            color1Button.Enabled = false;
            color2Button.Enabled = false;
            cellDistRandButton.Enabled = false;
            cellDistManualButton.Enabled = false;
            cellRatioSlider.Enabled = false;
            emptyRatioSlider.Enabled = false;
        }


        private void timer1_Tick(object sender, EventArgs e)    //updating grid every interval
        {
            grid.update();
            Render();
        }
        private void startButton_Click(object sender, EventArgs e)  //action after clicking start button
        {
                timer = new System.Windows.Forms.Timer();   //setting up timer
                timer.Interval = 500;
                timer.Tick += new System.EventHandler(timer1_Tick);
                timer.Start();
                //    
                stopButton.Enabled = true;
                startButton.Enabled = false;
                disableSettings();
        }

        private void stopButton_Click(object sender, EventArgs e)   //action after clicking stop button
        {
            grid.clear();
            timer.Stop();
            //
            startButton.Enabled = true;
            stopButton.Enabled = false;
            enableSettings();
        }

        private void resetButton_Click(object sender, EventArgs e)  //action after clicking reset button
        {
            Reset();
        }

        //Generating and drawing grid
        private void Reset() //reset settings of grid and render a new one
        {
            grid = new Grid(gridPictureBox.Width, gridPictureBox.Height, parameters);
            Render(); //render new display
        }
        private void Render()   //rendering new display
        {
            Bitmap bmp = new Bitmap(grid.Width, grid.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            SolidBrush cellBrush;
            gfx.Clear(Color.Black);
            Size cellSize = new Size(grid.cellWidth, grid.cellHeight);
            //Console.WriteLine(parameters.cellsNumber + " " + gridPictureBox.Width + " " + gridPictureBox.Height + " " + grid.cellWidth + " " + grid.cellHeight);
            //drawing grid with cells as rectangles
            for (int row = 0; row < parameters.cellsNumber; row++)
            {
                for (int col = 0; col < parameters.cellsNumber; col++)
                {
                    Point CellLocation = new Point(col * cellSize.Width, row * cellSize.Height);
                    Rectangle cellRect = new Rectangle(CellLocation, cellSize);
                    cellBrush = new SolidBrush(grid.Cells[row, col].cellColor);
                    gfx.FillRectangle(cellBrush, cellRect);
                }
            }
            gridPictureBox.Image = bmp;
        }
    }
  }
