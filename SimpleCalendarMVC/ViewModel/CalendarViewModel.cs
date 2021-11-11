using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.ViewModel
{
    /// <summary>
    /// This class represents the data of the calemdar view
    /// </summary>
    public class CalendarViewModel
    {
        /// <summary>
        /// A list of all months that shoud be displayed
        /// </summary>
        public IList<Month> MonthList { get; set; } = new List<Month>();

        /// <summary>
        /// A list of appointments that shoud be displayed
        /// </summary>
        public IList<Appointment> AppointmentsToList { get; set; } = new List<Appointment>();
        
        /// <summary>
        /// The appointment that shoud be displayed in detail
        /// </summary>
        public Appointment AppointmentToShow { get; set; } = null;

    }
}