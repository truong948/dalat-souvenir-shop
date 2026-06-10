using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceMVC.Areas.Admin.Controllers
{

	[Area("admin")]
	[Route("admin")]
	[Route("admin/homeadmin")]
	public class HomeAdminController : Controller
	{
		private readonly Hshop2023Context db;

		public HomeAdminController(Hshop2023Context conetxt)
		{
			db = conetxt;
		}
		[Route("")]
		[Route("index")]
		public IActionResult Index()
		{
			return View();
		}
		[Route("Danhmucsanpham")]
		public IActionResult DanhMucSanPham()
		{
			var lstSanPham = db.HangHoas.ToList();
			return View(lstSanPham);

		}
		[Route("ThemSanPhamMoi")]
		[HttpGet]
		public IActionResult ThemSanPhamMoi()
		{
			//ViewBag.MaLoai = new SelectList(db.HangHoas.ToList(), "MaLoai", "Loai");
			//ViewBag.MaNCC = new SelectList(db.HangHoas.ToList(), "MaNCC", "NhaCungCap");


			return View();
		}
		[Route("ThemSanPhamMoi")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ThemSanPhamMoi(HangHoa sanPham)
		{
			if (ModelState.IsValid) {
				db.HangHoas.Add(sanPham);
				db.SaveChanges();
				return RedirectToAction("DanhMucSanPham");
			
			}
			return View();
		}
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            //ViewBag.MaLoai = new SelectList(db.HangHoas.ToList(), "MaLoai", "Loai");
            //ViewBag.MaNCC = new SelectList(db.HangHoas.ToList(), "MaNCC", "NhaCungCap");
			var sanPham=db.HangHoas.Find(maSanPham);

            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(HangHoa sanPham)
        {
            if (ModelState.IsValid)
            {
				db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");

            }
            return View(sanPham);
        }
    }
}
