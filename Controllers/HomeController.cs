using QuanLyDatNen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyDatNen.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataContext _context;
        public HomeController()
        {
            _context = new DataContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadTable(string tennen, int trangthai = -1, string tennguoimua = null)
        {
            var data = _context.Nens.AsQueryable();
            if (!string.IsNullOrEmpty(tennen))
                data = data.Where(x => x.TenNen.Contains(tennen));
            if (!string.IsNullOrEmpty(tennguoimua))
                data = data.Where(x => x.HoTen.Contains(tennguoimua));
            if (trangthai != -1)
                data = data.Where(x => x.TinhTrang == trangthai);
            return View(data.ToList());
        }
        [HttpGet]
        public ActionResult AddOrUpdate(int id = 0)
        {
            var ListTinhTrang = new List<TinhTrang>() {
                new TinhTrang(){Id = 0, Ten = "Nền trống"},
                new TinhTrang(){Id = 1, Ten = "Đã giao"},
            };

            if (id == 0)
            {
                ViewBag.TinhTrang = new SelectList(ListTinhTrang, "Id", "Ten");
                return View(new Nen());
            }
            else
            {
                var entity = _context.Nens.Where(x => x.Id == id).FirstOrDefault();
                if (entity == default(Nen))
                    throw new Exception("Không tìm thấy dữ liệu");
                ViewBag.TinhTrang = new SelectList(ListTinhTrang, "Id", "Ten", entity.TinhTrang);
                return View(entity);
            }
        }
        [HttpPost]
        public ActionResult AddOrUpdate(Nen model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.Nens.Add(model);
                    _context.SaveChanges();
                    return Json(new GenericMessageVM()
                    {
                        Status = true,
                        Message = $"Thêm thành công!",
                        MessageType = GenericMessage.success,
                        Data = model
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var entity = _context.Nens.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (entity == default(Nen))
                        throw new Exception("Không tìm thấy dữ liệu.");
                    entity.TenNen = model.TenNen;
                    entity.DienTich = model.DienTich;
                    entity.GiaTri = model.GiaTri;
                    entity.TinhTrang = model.TinhTrang;
                    entity.DiaChi = model.DiaChi;
                    entity.GhiChu = model.GhiChu;
                    entity.HoTen = model.HoTen;
                    entity.CMND = model.CMND;
                    entity.NgayKy = model.NgayKy;
                    entity.SDT = model.SDT;

                    _context.SaveChanges();
                    return Json(new GenericMessageVM()
                    {
                        Status = true,
                        Message = $"Cập nhật thành công!",
                        MessageType = GenericMessage.success,
                        Data = model
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new GenericMessageVM()
                {
                    Status = false,
                    Message = $"{ex.Message}",
                    MessageType = GenericMessage.error
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _context.Nens.Where(x => x.Id == id).FirstOrDefault();
                _context.Nens.Remove(data);
                _context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}