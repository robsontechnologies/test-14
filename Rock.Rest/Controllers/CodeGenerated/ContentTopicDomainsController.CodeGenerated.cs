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
    /// ContentTopicDomains REST API
    /// </summary>
    [RestControllerGuid( "B97B3AF6-2111-4674-A680-59DBBBB19807" )]
    public partial class ContentTopicDomainsController : Rock.Rest.ApiController<Rock.Model.ContentTopicDomain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentTopicDomainsController"/> class.
        /// </summary>
        public ContentTopicDomainsController() : base( new Rock.Model.ContentTopicDomainService( new Rock.Data.RockContext() ) ) { } 
    }
}
