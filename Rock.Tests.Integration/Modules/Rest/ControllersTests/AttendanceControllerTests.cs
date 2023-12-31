﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rock.Rest.Controllers;
using Rock.Tests.Shared;

namespace Rock.Tests.Integration.Crm.Attendance
{
    [TestClass]
    [Ignore()]
    public class AttendanceControllerTests
    {
        /// <summary>
        /// Runs before any tests in this class are executed.
        /// </summary>
        [ClassInitialize]
        public static void ClassInitialize( TestContext testContext )
        {
        }

        [TestMethod]
        public void AddAttendance()
        {
            int groupId = 111;
            int locationId = 14;
            int scheduleId = 19;
            DateTime occurrenceDate = new DateTime( 2019, 8, 12 );
            int? personId = 4;
            int? personAliasId = null;

            var attendancesController = new AttendancesController();

            var attendance = attendancesController.AddAttendance( groupId, locationId, scheduleId, occurrenceDate, personId, personAliasId );
            Assert.That.IsNotNull( attendance );
        }

        [TestMethod]
        public void AddAttendanceNoPerson()
        {
            int groupId = 111;
            int locationId = 14;
            int scheduleId = 19;
            DateTime occurrenceDate = new DateTime( 2019, 8, 5 );
            int? personId = null;
            int? personAliasId = null;

            var attendancesController = new AttendancesController();
            Rock.Model.Attendance attendance = new Rock.Model.Attendance();
            System.Web.Http.HttpResponseException exception = null;

            try
            {
                attendance = attendancesController.AddAttendance( groupId, locationId, scheduleId, occurrenceDate, personId, personAliasId );
            }
            catch ( System.Web.Http.HttpResponseException ex )
            {
                exception = ex;
            }
            finally
            {
                Assert.That.IsTrue( exception.Response.StatusCode == System.Net.HttpStatusCode.BadRequest );
            }
        }

    }
}
