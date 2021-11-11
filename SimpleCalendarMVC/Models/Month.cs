using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Models
{
    /// <summary>
    /// 
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
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Appointment> Appointments { get; set; }
    }

}