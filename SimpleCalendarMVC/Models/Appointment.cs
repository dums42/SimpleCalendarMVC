using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Appointment
    {

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Date:")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Title:")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Description:")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Organizer:")]
        public string Organizer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Month Month { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Attendees:")]
        public IList<Attendee> Attendees { get; set; } = new List<Attendee>();

    }
}