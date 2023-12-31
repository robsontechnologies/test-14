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
    /// PageShortLinks REST API
    /// </summary>
    [RestControllerGuid( "BBA6A664-3BBC-4190-92D9-2753A4F40844" )]
    public partial class PageShortLinksController : Rock.Rest.ApiController<Rock.Model.PageShortLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageShortLinksController"/> class.
        /// </summary>
        public PageShortLinksController() : base( new Rock.Model.PageShortLinkService( new Rock.Data.RockContext() ) ) { } 
    }
}
