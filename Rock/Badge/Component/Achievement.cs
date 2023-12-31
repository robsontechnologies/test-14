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
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;

using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Badge.Component
{
    /// <summary>
    /// Achievement Badge
    /// </summary>
    [Description( "Shows a badge for an achievement type." )]
    [Export( typeof( BadgeComponent ) )]
    [ExportMetadata( "ComponentName", "Achievement" )]

    [AchievementTypeField(
        "Achievement Type",
        Description = "The achievement type to display badges for",
        IsRequired = true,
        Order = 0,
        Key = AttributeKey.AchievementType )]

    [Rock.SystemGuid.EntityTypeGuid( "FB04FBDF-A934-4576-92EA-B7E085E76824")]
    public class Achievement : BadgeComponent
    {
        #region Keys

        /// <summary>
        /// Keys to use for the attributes
        /// </summary>
        private static class AttributeKey
        {
            /// <summary>
            /// The achievement type
            /// </summary>
            public const string AchievementType = "AchievementType";
        }

        #endregion Keys

        /// <inheritdoc/>
        public override void Render( BadgeCache badge, IEntity entity, TextWriter writer )
        {
            var achievementTypeGuid = GetAchievementTypeGuid( badge );

            if ( !achievementTypeGuid.HasValue )
            {
                return;
            }

            var achievementType = AchievementTypeCache.Get( achievementTypeGuid.Value );

            if ( achievementType == null )
            {
                return;
            }

            if ( achievementType.AchieverEntityTypeId == EntityTypeCache.Get<PersonAlias>().Id && entity is Person )
            {
                // Intentionally left blank to match logic pattern in GetJavaScript().
            }
            else if ( achievementType.AchieverEntityTypeId != entity.TypeId )
            {
                // This badge is not compatabile with this achievement
                return;
            }

            var domElementKey = GenerateBadgeKey( badge, entity );
            var html = GetHtmlTemplate( domElementKey );
            writer.Write( $"{html}" );
        }

        /// <inheritdoc/>
        protected override string GetJavaScript( BadgeCache badge, IEntity entity )
        {
            var achievementTypeGuid = GetAchievementTypeGuid( badge );

            if ( !achievementTypeGuid.HasValue )
            {
                return null;
            }

            var achievementType = AchievementTypeCache.Get( achievementTypeGuid.Value );

            if ( achievementType == null )
            {
                return null;
            }

            var achiever = entity;

            if ( achievementType.AchieverEntityTypeId == EntityTypeCache.Get<PersonAlias>().Id && entity is Person person )
            {
                // Translate this person badge to the person alias achievement
                achiever = person.PrimaryAlias;
            }
            else if ( achievementType.AchieverEntityTypeId != entity.TypeId )
            {
                // This badge is not compatabile with this achievement
                return null;
            }

            var domElementKey = GenerateBadgeKey( badge, entity );
            return GetScript( achievementType.Id, achiever.Id, domElementKey );
        }

        /// <summary>
        /// Get the achievement type guid described by the attribute value
        /// </summary>
        /// <param name="badgeCache"></param>
        /// <returns></returns>
        private Guid? GetAchievementTypeGuid( BadgeCache badgeCache )
        {
            return GetAttributeValue( badgeCache, AttributeKey.AchievementType ).AsGuidOrNull();
        }

        /// <summary>
        /// Gets the HTML template.
        /// </summary>
        /// <param name="domElementKey"></param>
        /// <returns></returns>
        private string GetHtmlTemplate( string domElementKey )
        {
            return $@"<div class=""badge"" data-placeholder-key=""{domElementKey}""></div>";
        }

        /// <summary>
        /// Gets the JavaScript that will load data and render the badge.
        /// </summary>
        /// <param name="achievementTypeId">The achievement type identifier.</param>
        /// <param name="personAliasId">The person alias identifier.</param>
        /// <param name="domElementKey">The DOM element key.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string GetScript( int achievementTypeId, int personAliasId, string domElementKey )
        {
            return
$@"$.ajax({{
    type: 'GET',
    url: Rock.settings.get('baseUrl') + 'api/AchievementTypes/{achievementTypeId}/BadgeData?achieverEntityId={personAliasId}',
    statusCode: {{
        200: function (data) {{
            var html = [];

            if (data && data.BadgeMarkup) {{
                html.push('<div class=""rockbadge badge-achievement"" data-tooltip-key=""{domElementKey}"" data-toggle=""tooltip"" data-original-title=""' + data.AchievementTypeName + '"">');
                html.push(data.BadgeMarkup);
                html.push('</div>\n');
            }}

            $('[data-placeholder-key=""{domElementKey}""]').replaceWith(html.join(''));
            $('[data-tooltip-key=""{domElementKey}""]').tooltip();
        }}
    }},
}});";
        }
    }
}