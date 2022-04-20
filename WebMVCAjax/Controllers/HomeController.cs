using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCAjax.Models;        // DTO, DAO 있는 프로젝트.폴더 using 추가

namespace WebMVCAjax.Controllers
{
    public class HomeController : Controller
    {
        // DAO 작업을...
        // Action 발생 ... 호출하면 그안에서 필요하다면 DAO 작업 수행
        EmployeeDB empDB = new EmployeeDB();

        // 요청 (Action) >> List(), Add(Employee emp), update(Employee emp), Delete(int ID)

        // 전체조회
        public JsonResult List()
        {
            return Json(empDB.ListAll(),JsonRequestBehavior.AllowGet);
        }

        // 조건조회
        public JsonResult GetbyID(int id)       // 별도의 DAO 함수가 존재하지는 조건 select
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(id));
            return Json(Employee,JsonRequestBehavior.AllowGet);
        }

        // 데이터 추가
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }

        // 데이터 수정
        public JsonResult Update(Employee emp)
        {
            return Json(empDB.update(emp), JsonRequestBehavior.AllowGet);
        }

        // 데이터 수정
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}