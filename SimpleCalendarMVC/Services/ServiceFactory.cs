using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCalendarMVC.Services
{
    /// <summary>
    /// A static class that creates and returns specific instances of IDataService
    /// </summary>
    public static class ServiceFactory
    {
        public enum SERVICE_TYPE
        {
            SIMPLE,
            EF
        }

        /// <summary>
        /// Creates and returns specific instances of IDataService
        /// </summary>
        /// <param name="pServiceType"></param>
        /// <returns>An instance of IDataService by the given type</returns>
        public static IDataService GetDataServiceInstance(SERVICE_TYPE pServiceType) 
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