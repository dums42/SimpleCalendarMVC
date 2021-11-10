using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleCalendarMVC.Services
{
    public class EFDataService : IDataService
    {
        public List<Appointment> GetAppointmentList()
        {
            throw new NotImplementedException();
        }

        public List<Month> GetMonthList()
        {
            throw new NotImplementedException();
        }
    }
}