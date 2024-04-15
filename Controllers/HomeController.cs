using Procon23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Procon23.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // Tạo một đối tượng ChessboardModel
            var model = new ChessboardModel(rows: 8, columns: 8); // Ví dụ: Bàn cờ 8x8                                                                  // Trả về view "Index" và truyền model tới view
            return View(model);
        }

        [HttpPost]
        public ActionResult Move(int currentRow, int currentColumn)
        {
            var chessboard = new ChessboardModel(8, 8); // Tạo một bàn cờ mới với kích thước 8x8
            chessboard.UpdateWorkerPosition(currentRow, currentColumn); // Cập nhật vị trí của Worker
            return Json(new { success = true }); // Trả về một JSON response
        }
    }
}