using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalendarMVC.Controllers;
using SimpleCalendarMVC.Services;
using System;
using System.Web.Mvc;

namespace SimpleCalendarTests
{
    [TestClass]
    public class CalendarControllerTest
    {

        #region simple ViewResult test's

        [TestMethod]
        public void TestIndexView()
        {
            var controller  = new CalendarController();
            var result      = controller.Index() as ViewResult;
            
            Assert.AreEqual("Index", result.ViewName);
        }
        
        [TestMethod]
        public void TestContactView()
        {
            var controller  = new CalendarController();
            var result      = controller.Contact() as ViewResult;
            
            Assert.AreEqual("Contact", result.ViewName);
        }

        [TestMethod]
        public void TestAboutView()
        {
            var controller  = new CalendarController();
            var result      = controller.About() as ViewResult;
            
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void TestCalendarWithMonthView()
        {
            var controller  = new CalendarController();
            var result      = controller.Calendar(null) as ViewResult;
            
            Assert.AreEqual("Calendar", result.ViewName);
        }

        public void TestCalendarWithAppointmentView()
        {
            var controller  = new CalendarController();
            var result      = controller.Appointment(null) as ViewResult;
            
            Assert.AreEqual("Calendar", result.ViewName);
        }

        #endregion

        #region extended calendar view test's

        [TestMethod]

        public void TestCalendarViewWithLegalMonthIndex()
        {
            var controller = new CalendarController();
            var result = controller.Calendar(2) as ViewResult;
            
            Assert.AreEqual("Calendar", result.ViewName);
        }

        [TestMethod]
        public void TestCalendarViewWithLegalAppointmentId()
        {
            var controller = new CalendarController();
            var result = controller.Appointment(1) as ViewResult;
            
            Assert.AreEqual("Calendar", result.ViewName);
        }

        public void TestCalendarViewWithIllegalMonthIndex()
        {
            var controller  = new CalendarController();
            var result      = controller.Calendar(99) as ViewResult;
            
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void TestCalendarViewWithIllegalAppointmentId()
        {
            var controller  = new CalendarController();
            var result      = controller.Appointment(99) as ViewResult;
            
            Assert.AreEqual("Error", result.ViewName);
        }

        #endregion

        #region dataservice (simple) test

        [TestMethod]
        public void TestGetMonthsIsNotNull()
        {
            var dataService = ServiceFactory.GetDataService(ServiceFactory.SERVICE_TYPE.SIMPLE);
            var result = dataService.GetMonths();
            
            Assert.AreEqual(true, result != null);
        }

        [TestMethod]
        public void TestGetMonthsCountGreaterZero()
        {
            var dataService = ServiceFactory.GetDataService(ServiceFactory.SERVICE_TYPE.SIMPLE);
            var result = dataService.GetMonths();
            
            Assert.AreEqual(true, result != null && result.Count > 0);
        }

        [TestMethod]
        public void TestGetAppointmentsIsNotNull()
        {
            var dataService = ServiceFactory.GetDataService(ServiceFactory.SERVICE_TYPE.SIMPLE);
            var result = dataService.GetAppointments();
            
            Assert.AreEqual(true, result != null);
        }

        [TestMethod]
        public void TestGetAppointmentsCountGreaterZero()
        {
            var dataService = ServiceFactory.GetDataService(ServiceFactory.SERVICE_TYPE.SIMPLE);
            var result = dataService.GetAppointments();
            
            Assert.AreEqual(true, result != null && result.Count > 0);
        }


        [TestMethod]
        public void TestGetMonthByIndex()
        {

            int indexToTest = 4;

            var dataService = ServiceFactory.GetDataService(ServiceFactory.SERVICE_TYPE.SIMPLE);
            var result  = dataService.GetMonthByIndex(indexToTest);

            Assert.AreEqual(true, result != null && result.Index.Equals(indexToTest));
        }


        [TestMethod]
        public void TestGetAppointmentById()
        {

            int idToTest = 1;

            var dataService = ServiceFactory.GetDataService(ServiceFactory.SERVICE_TYPE.SIMPLE);
            var result      = dataService.GetAppointmentById(idToTest);

            Assert.AreEqual(true, result != null && result.Id.Equals(idToTest));

        }



        #endregion

    }
}
