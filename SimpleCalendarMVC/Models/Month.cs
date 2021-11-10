using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    public class Month
    {

        public Month(int pId, string pName, bool pIsSelected = false)
        {
            Id              = pId;
            Name            = pName;
            IsSelected      = false;
            Appointments    = new List<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public IList<Appointment> Appointments { get; set; }
    }

}