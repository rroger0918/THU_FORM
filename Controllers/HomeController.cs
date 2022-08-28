using Firebase.Auth;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THU_FORM.Models;

namespace THU_FORM.Controllers
{
    public class HomeController : Controller
    {
        readonly IFirebaseClient client;
        private static string ApiKey = "AIzaSyCWc1Pu-s4rQRetcfnyLzxpltXX7B5NCc4";
        //private static string Bucket = "https://thu-form-default-rtdb.asia-southeast1.firebasedatabase.app/";
        FirebaseAuthProvider auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(ApiKey));

        public HomeController()
        {
            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
            {
                AuthSecret = "TszB5Hmop1Jb64FoePa2ITKEbYmL39ZzNavOVQvA",
                BasePath = "https://thu-form-default-rtdb.asia-southeast1.firebasedatabase.app/"
            };

            client = new FirebaseClient(config);

        }

        //首頁DB資料
        private dynamic _response()
        {
            FirebaseResponse response = client.Get("contact");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            return data;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var responseDara = _response();
            List<SignUpModel> signUpList = new List<SignUpModel>();
            if (responseDara != null)
            {
                Dictionary<string, dynamic> result = responseDara.ToObject<Dictionary<string, dynamic>>();
                foreach (KeyValuePair<string, dynamic> element in result)
                {
                    signUpList.Add(new SignUpModel()
                    {
                        ID = element.Key,
                        Name = element.Value.Name,
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

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(SignUpModel signUpList)
        {
            //設定台北時間
            var info = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);
            signUpList.CreateDateTime = localTime.ToString("yyyy-MM-dd  HH:mm");

            string Id = Guid.NewGuid().ToString("N");
            SetResponse response = client.Set("contact/" + Id, signUpList);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Message"] = " 🤜 報名成功 期待您的蒞臨 🤛";
                return RedirectToAction("Contact");
            }
            else
            {
                TempData["Message"] = "報名失敗 請洽系統管理員 : leekuantean@gmail.com";
                return RedirectToAction("Contact");
            }
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string ID)
        {
            if (ID != null)
            {
                FirebaseResponse response = client.Delete("contact/" + ID);
                if (response.StatusCode.ToString() == "OK")
                {
                    TempData["DeleteMessage"] = "刪除成功";
                    return RedirectToAction("ManagePage");
                }
            }
            return RedirectToAction("ManagePage");
        }


        //還沒寫編輯View
        [Authorize]
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            FirebaseResponse response = client.Get("contact/" + ID);
            SignUpModel data = JsonConvert.DeserializeObject<SignUpModel>(response.Body);
            return View(data);
        }
       
        [HttpPost]
        public ActionResult Edit(SignUpModel data)
        {
            //設定台北時間
            var info = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);
            data.CreateDateTime = localTime.ToString("yyyy-MM-dd  HH:mm");

            SetResponse response = client.Set("contact/" + data.ID, data);
            TempData["EditSuccess"] = "EditSuccess";
            return View();
        }

        //還沒寫檢視詳細頁View
        [HttpGet]
        public ActionResult Detail(string id)
        {
            FirebaseResponse response = client.Get("contact/" + id);
            SignUpModel data = JsonConvert.DeserializeObject<SignUpModel>(response.Body);
            return View(data);
        }

        [Authorize]
        public ActionResult ManagePage()
        {
            // Dictionary<string, SignUpList> list = new Dictionary<string, SignUpList>();
            FirebaseResponse response = client.Get("contact/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            List<SignUpModel> signUpList = new List<SignUpModel>();
            if (data != null)
            {
                Dictionary<string, dynamic> result = data.ToObject<Dictionary<string, dynamic>>();
                foreach (KeyValuePair<string, dynamic> element in result)
                {
                    signUpList.Add(new SignUpModel()
                    {
                        ID = element.Key,
                        TH = element.Value.TH,
                        Name = element.Value.Name,
                        Mail = element.Value.Mail,
                        PeopleNumber = element.Value.PeopleNumber,
                        WantToSay = element.Value.WantToSay,
                        CreateDateTime = element.Value.CreateDateTime
                    });
                }
                if (Session["UserEmail"] != null && Session["UserEmail"].ToString() != "leekuantean@gmail.com")
                {
                    signUpList = signUpList.Where(x => x.Mail == Session["UserEmail"].ToString()).ToList();
                }
            }
            
            return View(signUpList);
        }
    }
}