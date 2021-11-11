using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CalendarViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Appointment> AppointmentList { get; set; } = new List<Appointment>();
        
        /// <summary>
        /// 
        /// </summary>
        public IList<Month> MonthList { get; set; } = new List<Month>();
        
        /// <summary>
        /// 
        /// </summary>
        /// 
        public IList<Appointment> AppointmentsToList { get; set; } = new List<Appointment>();
        
        /// <summary>
        /// 
        /// </summary>
        public Appointment AppointmentToShow { get; set; } = null;

    }
}