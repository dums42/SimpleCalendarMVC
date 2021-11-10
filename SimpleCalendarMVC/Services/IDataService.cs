using SimpleCalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalendarMVC.Services
{
    public interface IDataService
    {

        List<Month> GetMonthList();

        List<Appointment> GetAppointmentList();

    }
}
