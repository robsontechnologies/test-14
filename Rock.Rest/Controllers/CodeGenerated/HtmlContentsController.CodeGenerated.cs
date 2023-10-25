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
    /// HtmlContents REST API
    /// </summary>
    [RestControllerGuid( "FE7E5808-B5A0-46BA-9A42-9E2E020AC822" )]
    public partial class HtmlContentsController : Rock.Rest.ApiController<Rock.Model.HtmlContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlContentsController"/> class.
        /// </summary>
        public HtmlContentsController() : base( new Rock.Model.HtmlContentService( new Rock.Data.RockContext() ) ) { } 
    }
}