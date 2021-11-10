using SimpleCalendarMVC.Models;
using SimpleCalendarMVC.Services;
using SimpleCalendarMVC.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;
using static SimpleCalendarMVC.Services.ServiceProvider;

namespace SimpleCalendarMVC.Controllers
{
    public class HomeController : Controller
    {
        private CalendarViewModel calendarViewModel = null;

        public HomeController()
        {
            calendarViewModel = new CalendarViewModel();

            InitializeData();

        }

        private void InitializeData() {

            IDataService service = GetDataService(SERVICE_TYPE.SIMPLE);

            calendarViewModel.MonthList       = service.GetMonthList();
            calendarViewModel.AppointmentList = service.GetAppointmentList();

            foreach (var appointment in calendarViewModel.AppointmentList) {

                foreach (var month in calendarViewModel.MonthList)
                {
                    if (month.Id.Equals(appointment.Date.Month)) {

                        //setting relation between month and appointment
                        month.Appointments.Add(appointment);
                        appointment.Month = month;

                        break;
                    }
                }
            }

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application is used to display and create appointments.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calendar(int? id)
        {
            ViewBag.Title       = "Calendar";
            ViewBag.CardHeader  = "Calendar";
            ViewBag.Message     = "Hey, let's see what's up :)!";


            if (id != null) 
            {

                calendarViewModel.MonthList.ToList().ForEach(m => m.IsSelected = false);

                var month           = calendarViewModel.MonthList.Where(m => m.Id.Equals(id)).FirstOrDefault();
                month.IsSelected    = true;

                calendarViewModel.AppointmentsToList = month.Appointments.OrderBy(app => app.Date).ToList();
            }

            return View(calendarViewModel);
        }

        public ActionResult Appointment(int? id)
        {
            ViewBag.Title       = "Calendar";
            ViewBag.CardHeader  = "Calendar";
            ViewBag.Message     = "Hey, let's see what's up :)!";


            if (id != null)
            {
                calendarViewModel.MonthList.ToList().ForEach(m => m.IsSelected = false);

                var appointment = calendarViewModel.AppointmentList.Where(app => app.Id == id).FirstOrDefault();

                appointment.Month.IsSelected            = true;
                calendarViewModel.AppointmentToShow     = appointment;
                calendarViewModel.AppointmentsToList    = appointment.Month.Appointments.OrderBy(app => app.Date).ToList();

            }

            return View("Calendar", calendarViewModel);
        }

        
    }
}