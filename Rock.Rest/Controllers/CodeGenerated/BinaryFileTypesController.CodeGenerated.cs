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
    /// BinaryFileTypes REST API
    /// </summary>
    [RestControllerGuid( "AEAB9C6F-96AA-43FF-BC91-5555303EC629" )]
    public partial class BinaryFileTypesController : Rock.Rest.ApiController<Rock.Model.BinaryFileType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFileTypesController"/> class.
        /// </summary>
        public BinaryFileTypesController() : base( new Rock.Model.BinaryFileTypeService( new Rock.Data.RockContext() ) ) { } 
    }
}