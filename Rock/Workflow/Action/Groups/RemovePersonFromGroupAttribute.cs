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
using System.Linq;

using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Workflow.Action
{
    /// <summary>
    /// Sets an attribute's value to the selected person 
    /// </summary>
    [ActionCategory( "Groups" )]
    [Description( "Removes a person from a group using a workflow attribute." )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "Group Member Remove from Group Using Attribute" )]

    [WorkflowAttribute( "Person", "Workflow attribute that contains the person to remove from the group.", true, "", "", 0, null,
        new string[] { "Rock.Field.Types.PersonFieldType" } )]

    [WorkflowAttribute( "Group", "Workflow Attribute that contains the group to remove the person from.", true, "", "", 0, null,
        new string[] { "Rock.Field.Types.GroupFieldType" } )]
    [Rock.SystemGuid.EntityTypeGuid( "0F32A101-63E3-4345-B307-5DCEBE31009F")]
    public class RemovePersonFromGroupAttribute : ActionComponent
    {
        /// <summary>
        /// Executes the specified workflow.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public override bool Execute( RockContext rockContext, WorkflowAction action, Object entity, out List<string> errorMessages )
        {
            errorMessages = new List<string>();

            // Determine which group to add the person to
            Group group = null;

            var guidGroupAttribute = GetAttributeValue( action, "Group" ).AsGuidOrNull();

            if ( guidGroupAttribute.HasValue )
            {
                var attributeGroup = AttributeCache.Get( guidGroupAttribute.Value, rockContext );
                if ( attributeGroup != null )
                {
                    var groupGuid = action.GetWorkflowAttributeValue( guidGroupAttribute.Value ).AsGuidOrNull();

                    if ( groupGuid.HasValue )
                    {
                        group = new GroupService( rockContext ).Get( groupGuid.Value );
                    }
                }
            }

            if ( group == null )
            {
                errorMessages.Add( "No group was provided" );
            }

            // determine the person that will be added to the group
            Person person = null;

            // get the Attribute.Guid for this workflow's Person Attribute so that we can lookup the value
            var guidPersonAttribute = GetAttributeValue( action, "Person" ).AsGuidOrNull();

            if ( guidPersonAttribute.HasValue )
            {
                var attributePerson = AttributeCache.Get( guidPersonAttribute.Value, rockContext );
                if ( attributePerson != null )
                {
                    string attributePersonValue = action.GetWorkflowAttributeValue( guidPersonAttribute.Value );
                    if ( !string.IsNullOrWhiteSpace( attributePersonValue ) )
                    {
                        if ( attributePerson.FieldType.Class == typeof( Rock.Field.Types.PersonFieldType ).FullName )
                        {
                            Guid personAliasGuid = attributePersonValue.AsGuid();
                            if ( !personAliasGuid.IsEmpty() )
                            {
                                person = new PersonAliasService( rockContext ).Queryable()
                                    .Where( a => a.Guid.Equals( personAliasGuid ) )
                                    .Select( a => a.Person )
                                    .FirstOrDefault();
                            }
                        }
                        else
                        {
                            errorMessages.Add( "The attribute used to provide the person was not of type 'Person'." );
                        }
                    }
                }
            }

            if ( person == null )
            {
                errorMessages.Add( string.Format( "Person could not be found for selected value ('{0}')!", guidPersonAttribute.ToString() ) );
            }

            // remove person from group
            if ( !errorMessages.Any() )
            {

                try
                {
                    var groupMemberService = new GroupMemberService( rockContext );
                    var groupMembers = groupMemberService.Queryable().Where( m => m.PersonId == person.Id && m.GroupId == group.Id );

                    foreach ( var groupMember in groupMembers )
                    {
                        groupMemberService.Delete( groupMember );
                    }

                    rockContext.SaveChanges();
                }
                catch ( Exception ex )
                {
                    errorMessages.Add( string.Format( "An error occurred while removing the group member: {0}", ex.Message ) );
                }
            }

            errorMessages.ForEach( m => action.AddLogEntry( m, true ) );

            return true;
        }

    }
}