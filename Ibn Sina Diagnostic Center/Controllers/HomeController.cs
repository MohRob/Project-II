using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ibn_Sina_Diagnostic_Center.Models;

namespace Ibn_Sina_Diagnostic_Center.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Registration(User u)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities())
                {
                    db.Users.Add(u);
                    db.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "Registration Successfull";
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                Session["UserId"] = null;
                using (Database1Entities dc = new Database1Entities())
                {

                    var usr = dc.Users.Single(u => u.Email == user.Email && u.Password == user.Password);


                    if (usr != null)
                    {
                        Session["UserId"] = usr.Id.ToString();
                        //Session["Email"] = usr.Email.ToString();
                        Session["UserName"] = usr.Name.ToString();
                        //if (Session["UserName"].Equals("Admin"))
                        //{
                        //    Session["Admin"] = usr.UserName.ToString();

                        //}

                       
                        Session["Phone"] = usr.Phone.ToString();

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Email or Password is wrong";

            }






            return View();
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult DoctorInfo()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DoctorInfo(DrTable u)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities())
                {
                    db.DrTables.Add(u);
                    db.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "Doctor Information Updated";
                }
            }
            return View();
        }

        public ActionResult FindDr()
        {
            using (Database1Entities db=new Database1Entities())
            {
                return View(db.DrTables.ToList());
            }
           

            
        }

        public ActionResult Appointment()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Appointment(Apointment ap)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    db.Apointments.Add(ap);
                    db.SaveChanges();
                    ModelState.Clear();
                    ap = null;
                    ViewBag.Message = "Doctor Information Updated";
                }
            }
            return View();
        }
        public ActionResult Add(int id, string name,string apointmentDetails)
        {
            Session["Id"] = id;
            Session["DoctorName"] = name;
            Session[""] =apointmentDetails;

            return RedirectToAction("Appointment");


        }

        public ActionResult AppointmentList()
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                return View(db.Apointments.ToList());
            }



        }

    }
}