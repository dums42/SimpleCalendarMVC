using SimpleCalendarMVC.Models;
using SimpleCalendarMVC.Services;
using SimpleCalendarMVC.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;
using static SimpleCalendarMVC.Services.ServiceFactory;

namespace SimpleCalendarMVC.Controllers
{
    /// <summary>
    /// The controller that contains the logic and functions of the calendar page
    /// </summary>
    public class CalendarController : Controller
    {

        private const string VIEW_NAME_HOME     = "Index";
        private const string VIEW_NAME_CALENDAR = "Calendar";
        private const string VIEW_NAME_CONTACT  = "Contact";
        private const string VIEW_NAME_ABOUT    = "About";
        private const string VIEW_NAME_ERROR    = "Error";

        private CalendarViewModel calendarViewModel = null;

        #region ctor

        /// <summary>
        /// The constructor of the controller
        /// </summary>
        public CalendarController()
        {
            calendarViewModel = new CalendarViewModel();
        }

        #endregion

        #region Actions

        /// <summary>
        /// The action that the "index view" returns
        /// </summary>
        /// <returns>The Index-View</returns>
        public ActionResult Index()
        {
            ViewBag.AppName = Properties.Resources.AppName;
            ViewBag.Title   = Properties.Resources.HomePageTitle;
            ViewBag.Message = Properties.Resources.HomePageParagraph;

            return View(VIEW_NAME_HOME);
        }

        /// <summary>
        /// The action that the "about view" returns
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
        /// The action that the "contact view" returns
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
        /// The action that the "calendar view" returns
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Calendar(int? id)
        {
            try
            {
                ViewBag.AppName     = Properties.Resources.AppName;
                ViewBag.Title       = Properties.Resources.CalendarPageTitle;
                ViewBag.CardHeader  = Properties.Resources.CardHeader;
                ViewBag.Message     = Properties.Resources.CalendarPageParagraph;


                //I decided to fetch the complete data here. Should these become too large, a strategy for partial fetching on user actions should be chosen
                FetchCalendarData();

                if (id.HasValue)
                {
                    CalculateCalendarPageContetByMonthIndex(id.Value);
                }

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
        /// The action that the "calendar view" returns
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Appointment(int? id)
        {
            try
            {
                ViewBag.AppName     = Properties.Resources.AppName;
                ViewBag.Title       = Properties.Resources.CalendarPageTitle;
                ViewBag.CardHeader  = Properties.Resources.CardHeader;
                ViewBag.Message     = Properties.Resources.CalendarPageParagraph;

                //I decided to fetch the complete data here. Should these become too large, a strategy for partial fetching on user actions should be chosen
                FetchCalendarData();

                if (id.HasValue) 
                { 
                    CalculateCalendarPageContetByAppointmentId(id.Value);
                }

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

        #region business functions

        /// <summary>
        /// 
        /// </summary>
        private void FetchCalendarData()
        {

            IDataService service = GetDataServiceInstance(SERVICE_TYPE.SIMPLE);

            if (service != null)
            {
                calendarViewModel.MonthList = service.GetMonths();
            }
            else
            {
                throw new Exception($"Couldn't get calendar data!");
            }

        }

        /// <summary>
        /// This method determines the data that should be displayed in the view based on the month index
        /// </summary>
        /// <param name="pMonthIndex">The index of the month to be displayed</param>
        private void CalculateCalendarPageContetByMonthIndex(int pMonthIndex){

            ViewBag.AppName     = Properties.Resources.AppName;
            ViewBag.Title       = Properties.Resources.CalendarPageTitle;
            ViewBag.CardHeader  = Properties.Resources.CardHeader;
            ViewBag.Message     = Properties.Resources.CalendarPageParagraph;

            calendarViewModel.MonthList.ToList().ForEach(m => m.IsSelected = false);

            var month = calendarViewModel.MonthList.Where(m => m.Index.Equals(pMonthIndex)).FirstOrDefault();

            if (month != null) { 
                month.IsSelected = true;
                calendarViewModel.AppointmentsToList = month.Appointments.OrderBy(a => a.Date).ToList();
            }
            else
            {
                //if no month were found, something went wrong
                throw new Exception($"Illegal month index => {pMonthIndex}!");
            }
        }

        /// <summary>
        /// This method determines the data that should be displayed in the view based on the appontment id
        /// </summary>
        /// <param name="pAppointmentId">The id of the appointment to be displayed</param>
        private void CalculateCalendarPageContetByAppointmentId(int pAppointmentId)
        {

            ViewBag.AppName     = Properties.Resources.AppName;
            ViewBag.Title       = Properties.Resources.CalendarPageTitle;
            ViewBag.CardHeader  = Properties.Resources.CardHeader;
            ViewBag.Message     = Properties.Resources.CalendarPageParagraph;

            calendarViewModel.MonthList.ToList().ForEach(m => m.IsSelected = false);

            //selecting the appointment by id from the month list
            var appointment = calendarViewModel.MonthList.SelectMany(m => m.Appointments).Where(a => a.Id.Equals(pAppointmentId)).FirstOrDefault();


            //If the whole calendar data is larger, so that there are performance problems, you should consider fetching the data partially / as required
            //var appointment2 = ServiceProvider.GetDataServiceInstance(SERVICE_TYPE.SIMPLE).GetAppointmentById(pAppointmentId);

            if (appointment != null)
            {
                appointment.Month.IsSelected = true;
                calendarViewModel.AppointmentToShow = appointment;
                calendarViewModel.AppointmentsToList = appointment.Month.Appointments.OrderBy(a => a.Date).ToList();
            }
            else
            {
                //if no appointment were found, something went wrong
                throw new Exception($"Illegal appointment id => {pAppointmentId}!");
            }

        }

        #endregion

    }
}