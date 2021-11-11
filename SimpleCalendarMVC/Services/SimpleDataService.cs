using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleCalendarMVC.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleDataService : IDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Appointment> GetAppointmentList()
        {
            return new List<Appointment>()
            {

                new Appointment(){ Id = 1, Date = new DateTime(2021,1,20,14,15,0), Title = "Customer A", Description = "Video-Conference with customer A", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 2, Date = new DateTime(2021,1,15,9,30,0), Title = "Scrum Meeting", Description = "Scrum Meeting with the Scrum-Team ;)", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 3, Date = new DateTime(2021,2,16,12,0,0), Title = "Lunch with Joe", Description = "Lunch with Joe at Burger King ;)", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "Joe Mayer" } } },
                new Appointment(){ Id = 5, Date = new DateTime(2021,2,8,16,00,0), Title = "Team Meeting", Description = "Scrum-Team Meeting", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 6, Date = new DateTime(2021,2,19,17,00,0), Title = "Project Meeting", Description = "Project Meeting", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 7, Date = new DateTime(2021,3,15,9,30,0), Title = "Appointment 03", Description = " My Appointment 03", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 8, Date = new DateTime(2021,5,15,9,30,0), Title = "Appointment 04", Description = " My Appointment 04", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 9, Date = new DateTime(2021,10,15,9,30,0), Title = "Appointment 05", Description = " My Appointment 05", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 10, Date = new DateTime(2021,12,15,9,30,0), Title = "Appointment 06", Description = " My Appointment 06", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } },
                new Appointment(){ Id = 11, Date = new DateTime(2021,12,19,14,30,0), Title = "Appointment 07", Description = " My Appointment 07", Organizer = "Max Mustermann", Attendees = new List<Attendee>() { new Attendee() { Name = "John Smith" }, new Attendee() { Name = "Robert Turner" }, new Attendee() { Name = "Erika Gabler" } } }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Month> GetMonthList()
        {

            var months = Enumerable.Range(1, 12).Select(i => new { I = i, M = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) });

            return new List<Month>() {
                new Month(1, 1, "Jan"),
                new Month(2, 2, "Feb"),
                new Month(3, 3, "Mar"),
                new Month(4, 4, "Apr"),
                new Month(5, 5, "May"),
                new Month(6, 6, "Jun"),
                new Month(7, 7, "Jul"),
                new Month(8, 8, "Aug"),
                new Month(9, 9, "Sep"),
                new Month(10, 10, "Oct"),
                new Month(11, 11, "Nov"),
                new Month(12, 12, "Dec")
            };
        }
    }
}