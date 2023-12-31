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
    /// SystemPhoneNumbers REST API
    /// </summary>
    [RestControllerGuid( "855D78E0-C802-4144-A98B-BB214716E3A4" )]
    public partial class SystemPhoneNumbersController : Rock.Rest.ApiController<Rock.Model.SystemPhoneNumber>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemPhoneNumbersController"/> class.
        /// </summary>
        public SystemPhoneNumbersController() : base( new Rock.Model.SystemPhoneNumberService( new Rock.Data.RockContext() ) ) { } 
    }
}
