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
using System.ComponentModel;
using System.ComponentModel.Composition;

using Rock.Data;
using Rock.Model;

namespace Rock.Workflow.Action
{
    /// <summary>
    /// Marks an activity as complete
    /// </summary>
    [ActionCategory( "Workflow Control" )]
    [Description( "Marks the activity as complete" )]
    [Export(typeof(ActionComponent))]
    [ExportMetadata( "ComponentName", "Activity Complete" )]
    [Rock.SystemGuid.EntityTypeGuid( "0D5E33A5-8700-4168-A42E-74D78B62D717")]
    public class CompleteActivity : ActionComponent
    {
        /// <summary>
        /// Executes the specified workflow action.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public override bool Execute( RockContext rockContext, WorkflowAction action, Object entity, out List<string> errorMessages )
        {
            errorMessages = new List<string>();

            action.Activity.MarkComplete();
            action.AddLogEntry( "Marked activity complete" );

            return true;
        }
    }
}