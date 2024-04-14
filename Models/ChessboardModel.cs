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
        // Thiết lập các khu vực đặc biệt như Lâu đài và Ao
        private void SetInitialSpecialAreas()
        {
            Random rand = new Random();
            int castleCount = rand.Next(2, 6); // Số lượng Lâu đài ramdom từ 2 đến 5

            // Lặp qua các ô trên bàn cờ để đặt Lâu đài và Ao
            for (int i = 0; i < castleCount; i++)
            {
                int row = rand.Next(1, Rows - 1); // Tránh việc đặt ở hàng đầu hoặc hàng cuối
                int column = rand.Next(1, Columns - 1); // Tránh việc đặt ở cột đầu tiên hoặc cột cuối cùng

                // Đặt Lâu đài
                Areas[row, column] = AreaType.Castle;

                // Đặt Ao (khu vực xung quanh Lâu đài)
                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = column - 1; c <= column + 1; c++)
                    {
                        if (r >= 0 && r < Rows && c >= 0 && c < Columns && !(r == row && c == column))
                        {
                            Areas[r, c] = AreaType.Pond;
                        }
                    }
                }
            }
        }
    }
}