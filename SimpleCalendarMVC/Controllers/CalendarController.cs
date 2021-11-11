using SimpleCalendarMVC.Models;
using SimpleCalendarMVC.Services;
using SimpleCalendarMVC.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;
using static SimpleCalendarMVC.Services.ServiceProvider;

namespace SimpleCalendarMVC.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CalendarController : Controller
    {

        private const string VIEW_NAME_HOME     = "Index";
        private const string VIEW_NAME_CALENDAR = "Calendar";
        private const string VIEW_NAME_CONTACT  = "Contact";
        private const string VIEW_NAME_ABOUT    = "About";
        private const string VIEW_NAME_ERROR    = "Error";

        private CalendarViewModel calendarViewModel = null;

        #region ctor & initializatrions

        /// <summary>
        /// 
        /// </summary>
        public CalendarController()
        {
            calendarViewModel = new CalendarViewModel();

            InitializeData();

        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeData() {

            IDataService service = GetDataService(SERVICE_TYPE.SIMPLE);

            if (service != null) {
                calendarViewModel.MonthList = service.GetMonthList();
                calendarViewModel.AppointmentList = service.GetAppointmentList();

                foreach (var appointment in calendarViewModel.AppointmentList)
                {

                    foreach (var month in calendarViewModel.MonthList)
                    {
                        if (month.Id.Equals(appointment.Date.Month))
                        {

                            //setting relation between month and appointment
                            month.Appointments.Add(appointment);
                            appointment.Month = month;

                            break;
                        }
                    }
                }
            }
            
        }

        #endregion

        #region ActionResults

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.AppName = Properties.Resources.AppName;
            ViewBag.Title   = Properties.Resources.HomePageTitle;
            ViewBag.Message = Properties.Resources.HomePageParagraph;

            return View(VIEW_NAME_HOME);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.AppName = Properties.Resources.AppName;
            ViewBag.Title   = Properties.Resources.AboutPageTitle;
            ViewBag.Message = Properties.Resources.AboutPageParagraph;

            return View(VIEW_NAME_ABOUT);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.AppName = Properties.Resources.AppName;
            ViewBag.Title   = Properties.Resources.ContactPageTitle;
            ViewBag.Message = Properties.Resources.ContactPageParagraph;

            return View(VIEW_NAME_CONTACT);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Calendar(int? id)
        {
            try
            {
                CalculateCalendarPageContet(id, null);
                return View(VIEW_NAME_CALENDAR, calendarViewModel);
            }
            catch (Exception ex)
            {

                ViewBag.Error           = Properties.Resources.Error;
                ViewBag.ErrorSubline    = Properties.Resources.ErrorSubline;
                ViewBag.ErrorMessage    = ex.Message;
                return View(VIEW_NAME_ERROR);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Appointment(int? id)
        {
            try
            {
                CalculateCalendarPageContet(null, id);
                return View(VIEW_NAME_CALENDAR, calendarViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error           = Properties.Resources.Error;
                ViewBag.ErrorSubline    = Properties.Resources.ErrorSubline;
                ViewBag.ErrorMessage    = ex.Message;

                return View(VIEW_NAME_ERROR);
            }
            
        }

        #endregion

        #region calculations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMonthIndex"></param>
        /// <param name="pAppointmentId"></param>
        private void CalculateCalendarPageContet(int? pMonthIndex, int? pAppointmentId){

            ViewBag.AppName     = Properties.Resources.AppName;
            ViewBag.Title       = Properties.Resources.CalendarPageTitle;
            ViewBag.CardHeader  = Properties.Resources.CardHeader;
            ViewBag.Message     = Properties.Resources.CalendarPageParagraph;

            if (pAppointmentId != null) 
            {
                calendarViewModel.MonthList.ToList().ForEach(m => m.IsSelected = false);

                var appointment = calendarViewModel.AppointmentList.Where(a => a.Id.Equals(pAppointmentId)).FirstOrDefault();

                if (appointment != null)
                {
                    appointment.Month.IsSelected = true;
                    calendarViewModel.AppointmentToShow = appointment;
                    calendarViewModel.AppointmentsToList = appointment.Month.Appointments.OrderBy(a => a.Date).ToList();
                }
                else 
                {
                    throw new Exception($"Illegal appointment id => {pAppointmentId}!");
                }

            }
            else if (pMonthIndex != null)
            {
                calendarViewModel.MonthList.ToList().ForEach(m => m.IsSelected = false);

                var month = calendarViewModel.MonthList.Where(m => m.Index.Equals(pMonthIndex)).FirstOrDefault();

                if (month != null) { 
                    month.IsSelected = true;
                    calendarViewModel.AppointmentsToList = month.Appointments.OrderBy(a => a.Date).ToList();
                }
                else
                {
                    throw new Exception($"Illegal month index => {pMonthIndex}!");
                }
            }
        }

        #endregion

    }
}