using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Services
{
    public static class ServiceProvider
    {

        public enum SERVICE_TYPE
        {
            SIMPLE,
            EF
        }

        public static IDataService GetDataService(SERVICE_TYPE pServiceType) 
        {
            switch (pServiceType)
            {
                case SERVICE_TYPE.SIMPLE:
                    return new SimpleDataService();
                case SERVICE_TYPE.EF:
                    return new EFDataService();
                default:
                    return new SimpleDataService();
            }
            
        }

    }
}