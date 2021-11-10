using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.ViewModel
{
    public class CalendarViewModel
    {

        public IList<Appointment> AppointmentList { get; set; } = new List<Appointment>();
        public IList<Month> MonthList { get; set; } = new List<Month>();
        public IList<Appointment> AppointmentsToList { get; set; } = new List<Appointment>();
        public Appointment AppointmentToShow { get; set; } = null;

    }
}