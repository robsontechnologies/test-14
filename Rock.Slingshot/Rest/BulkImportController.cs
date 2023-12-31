// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rock.Rest.Filters;
using Rock.Model;

namespace Rock.Slingshot.Rest.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Rock.Rest.ApiControllerBase" />
    [RockObsolete( "1.11" )]
    [Obsolete( "Use the Slingshot BulkImport block instead" )]
    [Rock.SystemGuid.RestControllerGuid( "4E1EB99D-9C0E-418F-8710-7953B7068280")]
    public class BulkImportController : Rock.Rest.ApiControllerBase
    {

        #region Static Methods

        /// <summary>
        /// Gets the log file path.
        /// </summary>
        /// <returns>A file path equivalent to ~/App_Data/rest-bulkimport-errors.log.</returns>
        private static string GetLogFilePath()
        {
            return System.IO.Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "App_Data", "rest-bulkimport-errors.log" );
        }

        /// <summary>
        /// Initiates the bulk importer.
        /// </summary>
        /// <returns>A <see cref="Slingshot.BulkImporter"/>.</returns>
        private static BulkImporter InitiateBulkImporter()
        {
            return new BulkImporter() { SlingshotLogFile = GetLogFilePath() };
        }

        #endregion Static Methods

        /// <summary>
        /// Bulk Import of Attendance
        /// </summary>
        /// <param name="attendanceImports">The attendance imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/AttendanceImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage AttendanceImport( [FromBody]List<Rock.Slingshot.Model.AttendanceImport> attendanceImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkAttendanceImport( attendanceImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Groups
        /// </summary>
        /// <param name="groupImports">The group imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/GroupImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage GroupImport( [FromBody]List<Rock.Slingshot.Model.GroupImport> groupImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkGroupImport( groupImports, foreignSystemKey );
            AttributeValueService.UpdateAllValueAsDateTimeFromTextValue();
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Financials the account import.
        /// </summary>
        /// <param name="financialAccountImports">The financial account imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/FinancialAccountImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage FinancialAccountImport( [FromBody]List<Rock.Slingshot.Model.FinancialAccountImport> financialAccountImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkFinancialAccountImport( financialAccountImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Financials the batch import.
        /// </summary>
        /// <param name="financialBatchImports">The financial batch imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/FinancialBatchImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage FinancialBatchImport( [FromBody]List<Rock.Slingshot.Model.FinancialBatchImport> financialBatchImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkFinancialBatchImport( financialBatchImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Financials the transaction import.
        /// </summary>
        /// <param name="financialTransactionImports">The financial transaction imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/FinancialTransactionImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage FinancialTransactionImport( [FromBody]List<Rock.Slingshot.Model.FinancialTransactionImport> financialTransactionImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkFinancialTransactionImport( financialTransactionImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Locations
        /// </summary>
        /// <param name="locationImports">The location imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/LocationImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage LocationImport( [FromBody]List<Rock.Slingshot.Model.LocationImport> locationImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkLocationImport( locationImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Business records
        /// </summary>
        /// <param name="businessImports">The business imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/BusinessImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage BusinessImport( [FromBody]List<Rock.Slingshot.Model.PersonImport> businessImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkBusinessImport( businessImports, foreignSystemKey );
            AttributeValueService.UpdateAllValueAsDateTimeFromTextValue();
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Person records
        /// </summary>
        /// <param name="personImports">The person imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/PersonImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage PersonImport( [FromBody]List<Rock.Slingshot.Model.PersonImport> personImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkPersonImport( personImports, foreignSystemKey );
            AttributeValueService.UpdateAllValueAsDateTimeFromTextValue();
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Family or Person Photo records
        /// </summary>
        /// <param name="photoImports">The photo imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/PhotoImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage PhotoImport( [FromBody]List<Rock.Slingshot.Model.PhotoImport> photoImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkPhotoImport( photoImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Schedules
        /// </summary>
        /// <param name="scheduleImports">The schedule imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/ScheduleImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage ScheduleImport( [FromBody]List<Rock.Slingshot.Model.ScheduleImport> scheduleImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkScheduleImport( scheduleImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Financial Pledges
        /// </summary>
        /// <param name="financialPledgeImports">The financial pledge imports.</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/FinancialPledgeImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage FinancialPledgeImport( [FromBody]List<Rock.Slingshot.Model.FinancialPledgeImport> financialPledgeImports, string foreignSystemKey )
        {
            var responseText = InitiateBulkImporter().BulkFinancialPledgeImport( financialPledgeImports, foreignSystemKey );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }

        /// <summary>
        /// Bulk Import of Notes
        /// </summary>
        /// <param name="noteImports">The note imports.</param>
        /// <param name="entityTypeId">The entity type identifier. NOTE: If this is for <see cref="Group"/>, make sure to set groupEntityIsFamily if it is a Family GroupType</param>
        /// <param name="foreignSystemKey">The foreign system key.</param>
        /// <param name="groupEntityIsFamily">if set to <c>true</c> [group entity is family]. Only applies if EntityTypeId refers to Rock.Model.Group</param>
        /// <returns></returns>
        [System.Web.Http.Route( "api/BulkImport/NoteImport" )]
        [HttpPost]
        [Authenticate, Secured]
        [RockObsolete( "1.11" )]
        [Obsolete( "Use the Slingshot BulkImport block instead" )]
        public System.Net.Http.HttpResponseMessage NoteImport( [FromBody]List<Rock.Slingshot.Model.NoteImport> noteImports, int entityTypeId, string foreignSystemKey, bool groupEntityIsFamily )
        {
            var responseText = InitiateBulkImporter().BulkNoteImport( noteImports, entityTypeId, foreignSystemKey, groupEntityIsFamily );
            return ControllerContext.Request.CreateResponse<string>( HttpStatusCode.Created, responseText );
        }
    }
}
