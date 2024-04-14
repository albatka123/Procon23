using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Procon23.Models
{
    public class ChessboardModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string[,] Squares { get; set; }



        // Các loại khu vực
        public enum AreaType { Neutral, Territory, Castle, Wall, Pond }
        public AreaType[,] Areas { get; set; }

        public ChessboardModel(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Squares = new string[Rows, Columns];
            Areas = new AreaType[Rows, Columns];
           

            // Khởi tạo giá trị ban đầu cho các loại khu vực (Trung lập)
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Areas[i, j] = AreaType.Neutral;
                }
            }

        }
    }
}