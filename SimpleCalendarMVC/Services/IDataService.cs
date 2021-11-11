using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalendarMVC.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Month> GetMonthList();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Appointment> GetAppointmentList();

    }
}
