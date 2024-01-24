using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schellings_model_project_I
{
    internal class Parameters
    {
        //variables taken from GUI
        public int cellsNumber { get; set; }
        public int tolerance { get; set; }
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public int cellsDistMode { get; set; } //0 for Random, 1 for Manual
        public int color1CellsRatio { get; set; }
        public int emptyCellsRatio { get; set; }
        public Parameters()
        { 
            //default values
            cellsNumber = 5;
            tolerance = 50;
            color1 = Color.LightGreen;
            color2 = Color.Turquoise;
            cellsDistMode = 0;
            color1CellsRatio = 50;
            emptyCellsRatio = 50;
        }
    }
}
