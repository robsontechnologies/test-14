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

using Rock.Attribute;
using Rock.Data;

namespace Rock.Workflow.Action.CheckIn
{
    /// <summary>
    /// Removes (or excludes) the groups for each selected family member that are not 
    /// specific to the first character of their last name. This filter looks for two 
    /// 'Text' type Group attributes with keys 'LastNameBeginLetterRange' and 
    /// 'LastNameEndLetterRange' to determine a match. (These attributes are 
    /// typically placed on the 'Check in by Age' Group Type.)
    /// </summary>
    [ActionCategory( "Check-In" )]
    [Description( "Removes (or excludes) the groups for each selected family member that are not specific to the first character of their last name. This filter looks for two 'Text' type Group attributes with keys 'LastNameBeginLetterRange' and 'LastNameEndLetterRange' to determine a match. (These attributes are typically placed on the 'Check in by Age' Group Type.)" )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "Filter Groups By LastName" )]
    [BooleanField( "Remove", "Select 'Yes' if groups should be removed.  Select 'No' if they should just be marked as excluded.", true )]
    [Rock.SystemGuid.EntityTypeGuid( "7B935062-4D3E-40CC-8923-B6C34A52C913")]
    public class FilterGroupsByLastName : CheckInActionComponent
    {
        /// <summary>
        /// Executes the specified workflow.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The workflow action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool Execute( RockContext rockContext, Model.WorkflowAction action, Object entity, out List<string> errorMessages )
        {
            var checkInState = GetCheckInState( entity, out errorMessages );
            if ( checkInState == null )
            {
                return false;
            }

            var family = checkInState.CheckIn.Families.FirstOrDefault( f => f.Selected );
            if ( family != null )
            {
                var remove = GetAttributeValue( action, "Remove" ).AsBoolean();

                foreach ( var person in family.People.Where( p => p.Person.LastName.Length > 0 ) )
                {
                    char lastInitial = char.Parse( person.Person.LastName.Substring( 0, 1 ).ToUpper() );
                    foreach ( var groupType in person.GroupTypes.ToList() )
                    {
                        foreach ( var group in groupType.Groups.ToList() )
                        {
                            string lastNameBeginLetterRange = group.Group.GetAttributeValue( "LastNameBeginLetterRange" );
                            string lastNameEndLetterRange = group.Group.GetAttributeValue( "LastNameEndLetterRange" );

                            char rangeStart = ( string.IsNullOrWhiteSpace( lastNameBeginLetterRange ) ) ? 'A' : char.Parse( lastNameBeginLetterRange.Trim().ToUpper() );
                            char rangeEnd = ( string.IsNullOrWhiteSpace( lastNameEndLetterRange ) ) ? 'Z' : char.Parse( lastNameEndLetterRange.Trim().ToUpper() );

                            // If the last name is not in range, remove the group
                            if ( !( lastInitial >= rangeStart && lastInitial <= rangeEnd ) )
                            {
                                if ( remove )
                                {
                                    groupType.Groups.Remove( group );
                                }
                                else
                                {
                                    group.ExcludedByFilter = true;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}