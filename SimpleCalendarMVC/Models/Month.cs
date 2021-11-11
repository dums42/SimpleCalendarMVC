using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    /// <summary>
    /// This class represents a month
    /// </summary>
    public class Month
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pName"></param>
        /// <param name="pIsSelected"></param>
        public Month(int pId, int pIndex, string pName, bool pIsSelected = false)
        {
            Id              = pId;
            Index           = pIndex;
            Name            = pName;
            IsSelected      = false;
            Appointments    = new List<Appointment>();
        }

        /// <summary>
        /// The unique id of the month
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The index of the nonth. 
        /// E.g. 1 for January, 2 for February, 2 for March ... 12 for December
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The name of the nonth. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether the month is selected 
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// The list of all appointments this month
        /// </summary>
        public IList<Appointment> Appointments { get; set; }
    }

}