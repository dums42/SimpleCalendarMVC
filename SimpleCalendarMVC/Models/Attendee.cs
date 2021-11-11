using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    /// <summary>
    /// This class represents an attendee
    /// </summary>
    public class Attendee
    {
        /// <summary>
        /// The unique id of the attendee
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the attendee
        /// </summary>
        public string Name { get; set; }

    }

}