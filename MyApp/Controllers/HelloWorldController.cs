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

        //http://localhost:8080/HelloWorld/UserData
        public ActionResult UserData()
        {

            // 1. 요청함수(Action) 만든 데이터 View 전달

            // 1. 요청 받기
            // 2. 데이터 처리
            // 2.1 클라이언트에서 넘어온 데이터      
            // Parameter public ActionResult UserData(string a, string b)
            // url http://localhost:8080/HelloWorld/UserData/100/200/300

            // 2.2 DAO를 통해서 생성된 데이터
            // Model에 객체 요청 >> EmpData.cs >> CRUD 구현
            // EmpData emp = new EmpData();
            // List<emp> emplist = emp.list()<>;

            // 3. 데이터를 View(*.chtml - razor 문법 적용된)에 전달
            // 3.1 ViewBag = empList;
            // 3.2 return View(emplist);

            // ViewBag.User = myuser;

            // View.cshtml > @ViewBag.User.UserNO
            // View.cshtml > @ViewBag.User.UserName

            // View(myuser)
            // View.cshtml > @Model.UserNo
            // View.cshtml > @Model.UserName

            var myuser = new User();
            myuser.UserNo = 100;
            myuser.UserName = "김유신";
            
            return View(myuser);
        }

    }
}