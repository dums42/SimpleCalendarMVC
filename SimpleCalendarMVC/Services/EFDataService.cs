using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleCalendarMVC.Services
{
    /// <summary>
    /// A implementation for the IDataService interface
    /// which manages the data with EntityFramework
    /// </summary>
    public class EFDataService : IDataService
    {
        public Appointment GetAppointmentById(int pId)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentListByMonthIndex(int pMonthIndex)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointments()
        {
            throw new NotImplementedException();
        }

        public Month GetMonthByIndex(int pIndex)
        {
            throw new NotImplementedException();
        }

        public List<Month> GetMonths()
        {
            throw new NotImplementedException();
        }
    }
}