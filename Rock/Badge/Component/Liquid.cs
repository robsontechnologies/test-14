﻿// <copyright>
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;

using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace Rock.Badge.Component
{
    /// <summary>
    /// Lava Badge
    /// </summary>
    [Description( "Lava Badge" )]
    [Export( typeof( BadgeComponent ) )]
    [ExportMetadata( "ComponentName", "Lava Badge" )]

    [CodeEditorField( "Display Text", "The text (or HTML) to display as a badge", CodeEditorMode.Lava, CodeEditorTheme.Rock, 200 )]
    [BooleanField( "Enable Debug", "Outputs the object graph to help create your Lava syntax.", false )]
    [Rock.SystemGuid.EntityTypeGuid( "95912004-62B5-4460-951F-D752427D44FE")]
    public class Liquid : BadgeComponent
    {
        /// <inheritdoc/>
        public override void Render( BadgeCache badge, IEntity entity, TextWriter writer )
        {
            var displayText = GetAttributeValue( badge, "DisplayText" );

            if ( entity != null )
            {
                var mergeValues = new Dictionary<string, object>();

                // Always add Entity as a merge field so that lava badges that aren't tied to a particular model can have consistency
                mergeValues.Add( "Entity", entity );

                // Add a merge field by the model's name (Group, Person, FinancialAccount, etc)
                var modelTypeName = entity.GetType()?.BaseType?.Name;
                if ( !modelTypeName.IsNullOrWhiteSpace() )
                {
                    mergeValues.Add( modelTypeName, entity );
                }

                // Continue to provide the person merge field since this was originally a person badge and the lava would need to be updated to not break
                if ( modelTypeName != "Person" )
                {
                    mergeValues.Add( "Person", entity as Person );
                }

                // Resolve the merge fields and add debug info if requested
                displayText = displayText.ResolveMergeFields( mergeValues );

                if ( GetAttributeValue( badge, "EnableDebug" ).AsBoolean() )
                {
                    displayText +=
$@"<small><a data-toggle='collapse' data-parent='#accordion' href='#badge-debug'><i class='fa fa-eye'></i></a></small>
    <div id='badge-debug' class='collapse well badge-debug'>
        {mergeValues.lavaDebugInfo()}
    </div>";
                }
            }

            if ( !displayText.IsNullOrWhiteSpace() )
            {
                writer.Write( displayText );
            }
        }
    }
}
