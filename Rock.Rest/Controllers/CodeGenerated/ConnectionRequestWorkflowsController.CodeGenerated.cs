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
    /// ConnectionRequestWorkflows REST API
    /// </summary>
    [RestControllerGuid( "18D027D4-C45A-46D5-ACEB-49F0A91488D3" )]
    public partial class ConnectionRequestWorkflowsController : Rock.Rest.ApiController<Rock.Model.ConnectionRequestWorkflow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionRequestWorkflowsController"/> class.
        /// </summary>
        public ConnectionRequestWorkflowsController() : base( new Rock.Model.ConnectionRequestWorkflowService( new Rock.Data.RockContext() ) ) { } 
    }
}
