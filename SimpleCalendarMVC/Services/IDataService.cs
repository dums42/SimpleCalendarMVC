using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalendarMVC.Services
{
    /// <summary>
    /// Interface that provides methods for fetching the data
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Returns the entire list of months
        /// </summary>
        /// <returns>A list of months</returns>
        List<Month> GetMonths();

        /// <summary>
        /// Returns the month by the specified index
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>A month</returns>
        Month GetMonthByIndex(int pIndex);

        /// <summary>
        /// Returns the entire list of appointments
        /// </summary>
        /// <returns>A list of appointments</returns>
        List<Appointment> GetAppointments();

        /// <summary>
        /// Returns all appointments for the specified month index
        /// </summary>
        /// <param name="pMonthIndex"></param>
        /// <returns>A list of appointments</returns>
        List<Appointment> GetAppointmentListByMonthIndex(int pMonthIndex);

        /// <summary>
        /// Returns the appointment by the specified id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>An appointment</returns>
        Appointment GetAppointmentById(int pId);

    }
}
