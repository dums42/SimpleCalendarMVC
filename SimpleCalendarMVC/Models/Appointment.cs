using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    /// <summary>
    /// This class represents an appointment
    /// </summary>
    public class Appointment
    {

        /// <summary>
        /// The unique id of the appointment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date of the appointment
        /// </summary>
        [DisplayName("Date:")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The title of the appointment
        /// </summary>
        [DisplayName("Title:")]
        public string Title { get; set; }

        /// <summary>
        /// The description of the appointment
        /// </summary>
        [DisplayName("Description:")]
        public string Description { get; set; }

        /// <summary>
        /// The organizer of the appointment
        /// </summary>
        [DisplayName("Organizer:")]
        public string Organizer { get; set; }

        /// <summary>
        /// The month in which the appointment takes place
        /// </summary>
        public Month Month { get; set; }

        /// <summaryThe >
        /// list of all attendees
        /// </summary>
        [DisplayName("Attendees:")]
        public IList<Attendee> Attendees { get; set; } = new List<Attendee>();

    }
}