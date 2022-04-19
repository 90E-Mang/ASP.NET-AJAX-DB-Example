using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();      // --> views >> HelloWorld >> Index.chtml 이 잡혀야됨.
        }
        // localhost:58789/HelloWolrd
        /*
        public string Index()
        {
            //return View();      // view를 생성하고 싶다면 > views > HelloWorld > index.html > view 생성
            return "<h3>My Hello World Site</h3>";
        }
        */
        // localhost:58789/HelloWolrd/welcome           index() 말고 다른 함수는 action이라고 부르고 helloworld 뒤의 URL을 받음
        // action은 controller의 메서드이다.
        // http://localhost:58789/HelloWorld/welcome/12?name=Emang
        public string welcome(string name, int ID =1)
        {
            // HttpUtility.HtmlEncode() 함수는 해킹이나 유출을 방지해줌,.
            return HttpUtility.HtmlEncode($"Hello : {name}, numtime : {ID} ");
        }
        //http://localhost:58789/HelloWorld/welcome/world/100 <- 문제 없이 실행됨
        // ㄴ> Hello : world, numtime : 100
        //http://localhost:58789/HelloWorld/welcome/100/world <- 거꾸로 적으면 type가 안맞아서 default값을 출력함.
        // ㄴ> Hello : 100, numtime : 1

        [HttpPost]
        public JsonResult ajaxMethod(string name)
        {
            PersonModel person = new PersonModel
            {
                Name = name,
                DataTime = DateTime.Now.ToString()
            };
            return Json(person);
        }

        public JsonResult empMethod()
        {
            Employee emp = new Employee()
            {
                ID = "Emp23",
                Name = "Steven Clark",
                Mobile = "825415426"
            };
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult KosaWorld(string name, int num = 1)
        {
            ViewBag.message = "Hello world" + name;
            ViewBag.num = num;

            return View();
        }

        public ActionResult UserData()
        {
            var myuser = new User();
            myuser.UserNo = 100;
            myuser.UserName = "김유신";

            // ViewBag.User = myuser;

            // View.cshtml > @ViewBag.User.UserNO
            // View.cshtml > @ViewBag.User.UserName

            // View(myuser)
            // View.cshtml > @Model.UserNo
            // View.cshtml > @Model.UserName

            return View(myuser);
        }

    }
}