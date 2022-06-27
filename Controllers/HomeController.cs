using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THU_FORM.Models;

namespace THU_FORM.Controllers
{
    public class HomeController : Controller
    {
        readonly IFirebaseClient client;
        public HomeController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "TszB5Hmop1Jb64FoePa2ITKEbYmL39ZzNavOVQvA",
                BasePath = "https://thu-form-default-rtdb.asia-southeast1.firebasedatabase.app/"
            };

            client = new FirebaseClient(config);
        }
        public ActionResult Index()
        {
            // Dictionary<string, SignUpList> list = new Dictionary<string, SignUpList>();
            FirebaseResponse response = client.Get("contact");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            List<SignUpList> signUpList = new List<SignUpList>();
            if (data != null)
            {
                Dictionary<string, dynamic> result = data.ToObject<Dictionary<string, dynamic>>();
                foreach (KeyValuePair<string, dynamic> element in result)
                {                   
                    signUpList.Add(new SignUpList()
                    {
                        TH = element.Value.TH,
                        Name = element.Value.Name,
                        Mail = element.Value.Mail,
                        PeopleNumber = element.Value.PeopleNumber,
                        WantToSay = element.Value.WantToSay,
                        CreateDateTime = element.Value.CreateDateTime
                    });

                }
            }           
            return View(signUpList);
        }

        public ActionResult Theme()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(SignUpList signUpList)
        {    
            //設定台北時間
            var info = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, info);
            signUpList.CreateDateTime = localTime.ToString("yyyy-MM-dd  HH:mm");
            
            string Id = Guid.NewGuid().ToString("N");
            SetResponse response = client.Set("contact/" + Id, signUpList);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    TempData["Message"] = "報名成功 期待您的蒞臨 <3";
            //    return RedirectToAction("Contact");
            //}
            //else
            //{
            //    TempData["Message"] = "報名失敗 請洽系統管理員 : leekuantean@gmail.com";
            return RedirectToAction("Contact");
            //}
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}