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
        public string[,] Squares { get; set; } // Mảng 2 chiều đại diện cho các ô trên bàn cờ

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
        // Cập nhật loại khu vực cho một ô cụ thể
        public void UpdateAreaType(int row, int column, AreaType areaType)
        {
            if (row >= 0 && row < Rows && column >= 0 && column < Columns)
            {
                Areas[row, column] = areaType;
            }
        }

    }
}