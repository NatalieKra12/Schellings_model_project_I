using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schellings_model_project_I
{
    internal class Grid
    {

        static Random rand = new Random();  //rand for choosing cells place

        public Cell[,] Cells; //2D array of cells
        public Cell[,] updatedCells; //2D array of updated cells
        List<Tuple<int, int>> emptyCellsList; //empty cells to which cells will move

        //Grid info
        public int Width;
        public int Height;
        public int cellWidth;
        public int cellHeight;
        Parameters parameters;  //info from GUI

        public Grid(int width, int height, Parameters parameters)
        {
            this.parameters = parameters;
            Width = width;  //panel width
            Height = height;    //panel height
            cellWidth = width / parameters.cellsNumber;
            cellHeight = height / parameters.cellsNumber;
            //
            Cells = new Cell[parameters.cellsNumber, parameters.cellsNumber];   //2D array of all cells
            updatedCells = new Cell[parameters.cellsNumber, parameters.cellsNumber];    //2D array of all cells
            emptyCellsList = new List<Tuple<int, int>> { };
            //
            initializeCells(parameters.cellsNumber);    //defining intial state of cells
            updatedCells = Cells.Clone() as Cell[,];    //copying initialized cells to updatedCells
        }

        //defining initial state of cells
        public void initializeCells(int cellsNumber)
        {
            //random cells distribution
            if (parameters.cellsDistMode == 0)
            {
                //Console.WriteLine("Cells Number = " + cellsNumber);
                for (int col = 0; col < cellsNumber; col++)
                {
                    for (int row = 0; row < cellsNumber; row++)
                    {
                        double rdFill = rand.NextDouble();
                        double rdColor = rand.NextDouble();
                        Cells[row, col] = new Cell(parameters, rdFill, rdColor);
                    }
                }
            }
            //preset grid example
            else if (parameters.cellsDistMode == 1)
            {
                int[,] fillCells = new int[30, 30] {{0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1},
                              {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
                              {1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1},
                              {1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                              {1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
                              {1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                              {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
                              {1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                              {1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
                              {1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1},
                              };
 
                int[,] fillColor = new int[30, 30] {{0, 1, 1, 1, 0, 2, 2, 0, 1, 2, 1, 2, 1, 2, 2, 2, 2, 1, 2, 1, 2, 1, 2, 1, 2, 0, 1, 1, 0, 1},
                              {2, 2, 2, 1, 2, 2, 1, 2, 2, 2, 2, 0, 2, 2, 2, 1, 1, 0, 1, 1, 2, 1, 2, 1, 0, 1, 0, 1, 2, 1},
                              {1, 1, 1, 2, 0, 1, 2, 2, 2, 1, 1, 2, 2, 1, 2, 1, 0, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 2, 1},
                              {2, 1, 2, 0, 2, 2, 1, 2, 2, 2, 2, 1, 2, 1, 2, 1, 2, 0, 1, 2, 1, 2, 1, 1, 1, 2, 2, 2, 0, 2},
                              {2, 1, 1, 1, 0, 1, 1, 0, 1, 2, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 2, 2, 2},
                              {1, 2, 0, 1, 0, 1, 0, 1, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1},
                              {1, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 1, 2, 1, 0, 1, 1, 2, 1, 2, 1, 2, 0, 1, 1, 2, 2, 2, 1},
                              {1, 2, 1, 2, 2, 1, 2, 1, 1, 2, 1, 2, 2, 2, 1, 1, 0, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2},
                              {0, 0, 2, 1, 1, 2, 0, 1, 1, 2, 2, 0, 1, 2, 0, 1, 2, 1, 1, 2, 0, 0, 1, 2, 2, 1, 1, 1, 0, 2},
                              {2, 2, 1, 1, 1, 1, 0, 1, 1, 1, 2, 2, 1, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 2, 1, 0},
                              {1, 2, 0, 1, 2, 1, 0, 1, 1, 2, 1, 1, 2, 2, 1, 2, 1, 1, 1, 2, 0, 2, 2, 2, 1, 2, 2, 1, 2, 1},
                              {0, 2, 0, 1, 1, 1, 1, 1, 1, 2, 2, 1, 2, 2, 1, 1, 2, 0, 2, 2, 2, 1, 2, 1, 1, 1, 0, 2, 1, 2},
                              {1, 2, 2, 1, 2, 1, 2, 2, 2, 1, 1, 2, 1, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 2, 1, 2, 1, 2, 2, 2},
                              {1, 1, 2, 1, 2, 1, 1, 1, 2, 1, 2, 2, 2, 2, 2, 1, 2, 1, 2, 1, 1, 1, 1, 0, 2, 2, 2, 2, 2, 2},
                              {2, 2, 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 1, 2, 1, 0, 1, 2, 2, 2, 1, 2, 2, 0, 1, 1, 1, 0, 0, 0},
                              {2, 2, 1, 1, 1, 2, 1, 1, 2, 0, 1, 1, 1, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 1, 2, 2},
                              {2, 2, 1, 1, 2, 2, 0, 2, 1, 0, 1, 1, 2, 1, 2, 2, 1, 1, 1, 0, 2, 2, 1, 2, 1, 2, 0, 2, 2, 2},
                              {2, 2, 2, 2, 0, 1, 2, 2, 1, 0, 1, 2, 1, 2, 2, 2, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 2, 1},
                              {1, 2, 0, 2, 0, 2, 2, 1, 1, 2, 1, 2, 2, 2, 1, 0, 2, 2, 2, 1, 2, 1, 1, 1, 2, 2, 2, 2, 1, 0},
                              {2, 1, 2, 1, 1, 1, 2, 1, 2, 0, 1, 1, 1, 2, 2, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 1, 1, 2, 2},
                              {1, 0, 2, 2, 1, 2, 0, 1, 0, 0, 2, 2, 2, 2, 2, 1, 2, 2, 0, 2, 1, 1, 2, 2, 1, 1, 0, 1, 1, 2},
                              {2, 1, 2, 2, 2, 1, 2, 1, 1, 1, 1, 2, 1, 2, 1, 1, 2, 2, 2, 0, 0, 2, 2, 2, 1, 1, 1, 2, 1, 1},
                              {2, 2, 0, 2, 1, 2, 1, 1, 1, 1, 2, 1, 2, 2, 2, 2, 2, 0, 2, 2, 2, 1, 2, 0, 1, 2, 1, 2, 2, 1},
                              {1, 2, 1, 1, 1, 2, 0, 2, 0, 2, 2, 2, 1, 0, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 1, 1, 1, 1},
                              {1, 2, 2, 2, 2, 2, 1, 1, 2, 2, 0, 1, 1, 2, 2, 1, 1, 2, 1, 0, 1, 1, 2, 2, 2, 2, 2, 2, 2, 0},
                              {2, 2, 2, 2, 2, 0, 2, 0, 1, 2, 0, 2, 1, 2, 2, 1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 2, 1, 2, 0, 2},
                              {1, 2, 0, 2, 2, 0, 2, 1, 0, 2, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 2, 1, 1, 0, 1, 1, 2, 2},
                              {1, 2, 2, 1, 1, 0, 2, 0, 1, 1, 2, 1, 1, 1, 2, 2, 2, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2},
                              {1, 1, 2, 2, 2, 1, 2, 1, 2, 0, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 0, 1, 2, 2, 1},
                              {1, 1, 1, 2, 0, 2, 1, 2, 2, 0, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 2, 0, 1, 2, 2, 0, 1, 1, 2, 2},
                              };
                for (int col = 0; col < cellsNumber; col++)
                {
                    for (int row = 0; row < cellsNumber; row++)
                    {
                        double rdFill = fillCells[col, row];
                        double rdColor = fillColor[col, row];
                        Cells[row, col] = new Cell(parameters, rdFill, rdColor);
                    }
                }
            }
        }

        //updating cells every interval
        public void update()
        {
            getEmptyCells();    //adding all empty cells to emptyCellsList
            gettingNeighbours();    //updating cells
            Cells = updatedCells.Clone() as Cell[,];
            emptyCellsList.Clear();
        }

        public void clear()
        {
            emptyCellsList.Clear();
        }

        //finding and adding all empty cells to emptyCellsList
        public void getEmptyCells()
        {
            for (int col = 0; col < parameters.cellsNumber - 1; col++)
            {
                for (int row = 0; row < parameters.cellsNumber - 1; row++)
                {
                    if (Cells[row, col].cellColor.ToArgb().Equals(Color.White.ToArgb()))
                    {
                        emptyCellsList.Add(new Tuple<int, int>(row, col));
                    }
                }
            }
        }

        //getting number of sameColorNerghbours
        public int getaSameColorNumber(List<Color> neighboursColors, Color currentCellColor)
        {
            int sameColorNeighbours = 0;
            foreach (Color neighbourColor in neighboursColors)
            {
                if (neighbourColor.ToArgb().Equals(currentCellColor.ToArgb())) //cell the same color as neighbour
                {
                    sameColorNeighbours++;
                }
            }
            return sameColorNeighbours;
        }

        //getting number of emptyNumber
        public int getEmptyNumber(List<Color> neighboursColors)
        {
            int emptyNeighbours = 0;
            foreach (Color neighbourColor in neighboursColors)
            {
                if (neighbourColor.ToArgb().Equals(Color.White.ToArgb())) //cell is empty
                {
                    emptyNeighbours++;
                }
            }
            return emptyNeighbours;
        }

        public bool cellToReplace(Cell currentCell, int oppositeColorNeighbours, int neighboursNumber)
        {
            bool cellToReplace = false;
            if (Convert.ToDouble(oppositeColorNeighbours) / neighboursNumber * 100 > parameters.tolerance)
            {
                cellToReplace = true;
            }
            return cellToReplace;
        }

        public void gettingNeighbours()
        {
            int cellsNumber = parameters.cellsNumber;
            int tolerance = parameters.tolerance;
            int sameColorNeighbours = 0;
            int oppositeColorNeighbours = 0;
            int emptyNeighbours = 0;
            List<Color> neighboursColors = new List<Color> { };
            //neighbours for cells in the corners
            int[] cornerRows = { 0, 0, cellsNumber - 1, cellsNumber - 1 };
            int[] cornerCols = { 0, cellsNumber - 1, 0, cellsNumber - 1 };
            for (int index = 0; index < 4; index++)
            {
                if (!(Cells[cornerRows[index], cornerCols[index]].cellColor.ToArgb().Equals(Color.White.ToArgb()))) //cell is not empty
                {
                    //adding neighbour's colors
                    neighboursColors.Clear();
                    //neighbour down
                    if (cornerRows[index] == 0)
                    {
                        neighboursColors.Add(Cells[1, cornerCols[index]].cellColor);
                    }
                    //neghbour up
                    else if (cornerRows[index] == cellsNumber - 1)
                    {
                        neighboursColors.Add(Cells[cellsNumber - 2, cornerCols[index]].cellColor);
                    }
                    //neighbour right
                    if (cornerCols[index] == 0)
                    {
                        neighboursColors.Add(Cells[cornerRows[index], 1].cellColor);
                    }
                    //neigbour left
                    else if (cornerCols[index] == cellsNumber - 1)
                    {
                        neighboursColors.Add(Cells[cornerRows[index], cellsNumber - 2].cellColor);
                    }
                    sameColorNeighbours = getaSameColorNumber(neighboursColors, Cells[cornerRows[index], cornerCols[index]].cellColor);
                    emptyNeighbours = getEmptyNumber(neighboursColors);
                    oppositeColorNeighbours = 2 - (sameColorNeighbours + emptyNeighbours);
                    if (cellToReplace(Cells[cornerRows[index], cornerCols[index]], oppositeColorNeighbours, 2))
                    {
                        if (emptyCellsList.Count != 0)
                        {
                            cellReplace(Cells[cornerRows[index], cornerCols[index]]);
                            Cells[cornerRows[index], cornerCols[index]].cellColor = Color.White;
                        }

                    }
                }
            }
            //neighbours for cells on the left edge -> Cells[index, 0]
            for (int index = 1; index < (cellsNumber - 1); index++)
            {
                if (!(Cells[index, 0].cellColor.ToArgb().Equals(Color.White.ToArgb()))) //cell is not empty
                {
                    neighboursColors.Clear();
                    neighboursColors.Add(Cells[index, 1].cellColor);
                    neighboursColors.Add(Cells[index - 1, 0].cellColor);
                    neighboursColors.Add(Cells[index + 1, 0].cellColor);
                    //
                    sameColorNeighbours = getaSameColorNumber(neighboursColors, Cells[index, 0].cellColor);
                    emptyNeighbours = getEmptyNumber(neighboursColors);
                    oppositeColorNeighbours = 3 - (sameColorNeighbours + emptyNeighbours);
                    if (cellToReplace(Cells[index, 0], oppositeColorNeighbours, 3))
                    {
                        if (emptyCellsList.Count != 0)
                        {
                            cellReplace(Cells[index, 0]);
                            Cells[index, 0].cellColor = Color.White;
                        }
                    }
                }
            }
            //neighbours on the right egde -> Cells[index, cellsNumber-1]
            for (int index = 1; index < (cellsNumber - 1); index++)
            {
                if (!(Cells[index, cellsNumber - 1].cellColor.ToArgb().Equals(Color.White.ToArgb()))) //cell is not empty
                {
                    neighboursColors.Clear();
                    neighboursColors.Add(Cells[index, cellsNumber - 2].cellColor);
                    neighboursColors.Add(Cells[index - 1, cellsNumber - 1].cellColor);
                    neighboursColors.Add(Cells[index + 1, cellsNumber - 1].cellColor);
                    //
                    sameColorNeighbours = getaSameColorNumber(neighboursColors, Cells[index, cellsNumber - 1].cellColor);
                    emptyNeighbours = getEmptyNumber(neighboursColors);
                    oppositeColorNeighbours = 3 - (sameColorNeighbours + emptyNeighbours);
                    if (cellToReplace(Cells[index, cellsNumber - 1], oppositeColorNeighbours, 3))
                    {
                        if (emptyCellsList.Count != 0)
                        {
                            cellReplace(Cells[index, cellsNumber - 1]);
                            Cells[index, cellsNumber - 1].cellColor = Color.White;
                        }
                    }
                }
            }
            //neighbours on the top edge -> Cells[0, index]
            for (int index = 1; index < (cellsNumber - 1); index++)
            {
                if (!(Cells[0, index].cellColor.ToArgb().Equals(Color.White.ToArgb()))) //cell is not empty
                {
                    neighboursColors.Clear();
                    neighboursColors.Add(Cells[1, index].cellColor);
                    neighboursColors.Add(Cells[0, index - 1].cellColor);
                    neighboursColors.Add(Cells[0, index + 1].cellColor);
                    //
                    sameColorNeighbours = getaSameColorNumber(neighboursColors, Cells[0, index].cellColor);
                    emptyNeighbours = getEmptyNumber(neighboursColors);
                    oppositeColorNeighbours = 3 - (sameColorNeighbours + emptyNeighbours);
                    if (cellToReplace(Cells[0, index], oppositeColorNeighbours, 3))
                    {
                        if (emptyCellsList.Count != 0)
                        {
                            cellReplace(Cells[0, index]);
                            Cells[0, index].cellColor = Color.White;
                        }
                    }
                }
            }
            //neighbours on the bottom edge -> Cells[cellsNumber-1, index]
            for (int index = 1; index < (cellsNumber - 1); index++)
            {
                if (!(Cells[cellsNumber - 1, index].cellColor.ToArgb().Equals(Color.White.ToArgb()))) //cell is not empty
                {
                    neighboursColors.Clear();
                    neighboursColors.Add(Cells[cellsNumber - 2, index].cellColor);
                    neighboursColors.Add(Cells[cellsNumber - 1, index - 1].cellColor);
                    neighboursColors.Add(Cells[cellsNumber - 1, index + 1].cellColor);
                    //
                    sameColorNeighbours = getaSameColorNumber(neighboursColors, Cells[cellsNumber - 1, index].cellColor);
                    emptyNeighbours = getEmptyNumber(neighboursColors);
                    oppositeColorNeighbours = 3 - (sameColorNeighbours + emptyNeighbours);
                    if (cellToReplace(Cells[cellsNumber - 1, index], oppositeColorNeighbours, 3))
                    {
                        if (emptyCellsList.Count != 0)
                        {
                            cellReplace(Cells[cellsNumber - 1, index]);
                            Cells[cellsNumber - 1, index].cellColor = Color.White;
                        }
                    }
                }
            }
            //
            //neigbours of cells not on the edges
            for (int col = 1; col < (cellsNumber - 1); col++)
            {
                for (int row = 1; row < (cellsNumber - 1); row++)
                {
                    if (!(Cells[row, col].cellColor.ToArgb().Equals(Color.White.ToArgb()))) //cell is not empty
                    {
                        neighboursColors.Clear();
                        neighboursColors.Add(Cells[row - 1, col].cellColor);
                        neighboursColors.Add(Cells[row, col - 1].cellColor);
                        neighboursColors.Add(Cells[row + 1, col].cellColor);
                        neighboursColors.Add(Cells[row, col + 1].cellColor);
                        //
                        sameColorNeighbours = getaSameColorNumber(neighboursColors, Cells[row, col].cellColor);
                        emptyNeighbours = getEmptyNumber(neighboursColors);
                        oppositeColorNeighbours = 4 - (sameColorNeighbours + emptyNeighbours);
                        if (cellToReplace(Cells[row, col], oppositeColorNeighbours, 4))
                        {
                            if (emptyCellsList.Count != 0)
                            {
                                cellReplace(Cells[row, col]);
                                Cells[row, col].cellColor = Color.White;
                            }
                        }
                    }
                }
            }
        }
        //moving cell to random empty cell
        public void cellReplace(Cell cell)
        {
            int rdEmptyCell = rand.Next(0, emptyCellsList.Count);
            updatedCells[emptyCellsList.ElementAt(rdEmptyCell).Item1, emptyCellsList.ElementAt(rdEmptyCell).Item2].cellColor = cell.cellColor;  //empty cell changes to color cell
            emptyCellsList.RemoveAt(rdEmptyCell);
        }
    }
}
