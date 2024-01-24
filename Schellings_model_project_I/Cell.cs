using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schellings_model_project_I
{
    internal class Cell
    {
        public Color cellColor { get; set; }

        //cell constructor 1
        public Cell(Color cellColor)
        { 
            this.cellColor = cellColor;
        }

        //cell constructor 2
        public Cell(Parameters parameters, double rdFill, double rdColor)
        {
            if (parameters.cellsDistMode == 0)  //random initialization of cells
            {
                if (rdFill > Convert.ToDouble(parameters.emptyCellsRatio) / 100)    //if cell is filled or empty
                {
                    if (rdColor > Convert.ToDouble(parameters.color1CellsRatio) / 100)  //if filled cell is color 1 or color 2
                    {
                        cellColor = parameters.color1;
                    }
                    else
                    {
                        cellColor = parameters.color2;
                    }
                }
                else
                {
                    cellColor = Color.White;

                }
            }
            else
            {
                //Manual Cells colors choosing
                if (rdFill == 1)
                {
                    if (rdColor == 1)
                    {
                        cellColor = parameters.color1;
                    }
                    else
                    {
                        cellColor = parameters.color2;
                    }
                }
                else
                {
                    cellColor = Color.White;
                }



            }
        }

    }
}
