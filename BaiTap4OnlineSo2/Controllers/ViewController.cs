using BaiTap4OnlineSo2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTap4OnlineSo2.Controllers
{
    public class ViewController : Controller
    {
        private readonly BaiTapOnlineSo2Context _context;

        public ViewController(BaiTapOnlineSo2Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Lấy dữ liệu từ View 1: Thống kê dịch vụ
            var dichVuStats = await _context.ThongkeDichvus.ToListAsync();

            // Lấy dữ liệu từ View 2: Thống kê sử dụng nhiệm vụ
            var suDungStats = await _context.ThongkeSudungNhiemvus.FirstOrDefaultAsync();

            // Lấy dữ liệu từ View 3: Thống kê nhiệm vụ theo thiết bị
            var thietBiStats = await _context.ThongkeNhiemvuTheothietbis.ToListAsync();

            // Truyền dữ liệu vào View
            ViewBag.DichVuStats = dichVuStats;
            ViewBag.SuDungStats = suDungStats;
            ViewBag.ThietBiStats = thietBiStats;

            return View();
        }


    }
}
