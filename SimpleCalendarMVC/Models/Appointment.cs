using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    public class Appointment
    {

        public int Id { get; set; }

        [DisplayName("Date:")]
        public DateTime Date { get; set; }

        [DisplayName("Title:")]
        public string Title { get; set; }

        [DisplayName("Description:")]
        public string Description { get; set; }

        public Month Month { get; set; }

    }
}