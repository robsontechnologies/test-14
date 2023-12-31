//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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

using Rock.Model;
using Rock.SystemGuid;

namespace Rock.Rest.Controllers
{
    /// <summary>
    /// Attendances REST API
    /// </summary>
    [RestControllerGuid( "4FB7E1C9-B57E-4FA4-BDD6-61FD81746AC4" )]
    public partial class AttendancesController : Rock.Rest.ApiController<Rock.Model.Attendance>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttendancesController"/> class.
        /// </summary>
        public AttendancesController() : base( new Rock.Model.AttendanceService( new Rock.Data.RockContext() ) ) { } 
    }
}
