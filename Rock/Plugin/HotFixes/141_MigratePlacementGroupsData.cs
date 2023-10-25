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

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// Plug-in migration
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 141, "1.12.5" )]
    public class MigratePlacementGroupsData : Migration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            //----------------------------------------------------------------------------------
            // <auto-generated>
            //     This Up() migration method was generated by the Rock.CodeGeneration project.
            //     The purpose is to prevent hotfix migrations from running when they are not
            //     needed. The migrations in this file are run by an EF migration instead.
            // </auto-generated>
            //----------------------------------------------------------------------------------
        }

        private void OldUp()
        {
            /*

            Set RelatedEntity.Qualifier to the first matching RegistrationTemplatePlacement                                                                    
            for 'PLACEMENT' RelatedEntities that have a null Qualifier (due to being 
            created prior to v12.5).
            We can make a reasonable guess on which RegistrationTemplatePlacement it is, 
            based on the RegistrationTemplatePlacement that has 
            the same GroupTypeId as the Placement Group
            This will un-disappear pre-12.5 (non-shared) placement groups 
            into the first matching Placement Type

            */

            Sql( @" 
UPDATE RelatedEntity
SET QualifierValue = (
        SELECT TOP 1 x.[registrationTemplatePlacement.Id]
        FROM (
            SELECT relatedEntity.Id [RelatedEntityId]
                , registrationTemplatePlacement.Id [registrationTemplatePlacement.Id]
            FROM RelatedEntity relatedEntity
            JOIN RegistrationInstance registrationInstance
                ON registrationInstance.Id = relatedEntity.SourceEntityId
                    AND relatedEntity.PurposeKey = 'PLACEMENT'
            JOIN RegistrationTemplatePlacement registrationTemplatePlacement
                ON registrationTemplatePlacement.RegistrationTemplateId = registrationInstance.RegistrationTemplateId
            JOIN [GroupType] placementGroupType 
                ON placementGroupType.Id = registrationTemplatePlacement.GroupTypeId
            JOIN [Group] placementGroup -- Placement Group
                ON relatedEntity.TargetEntityId = placementGroup.Id
                    AND placementGroup.GroupTypeId = placementGroupType.Id
            ) x
        WHERE x.RelatedEntityId = RelatedEntity.Id
        )
WHERE PurposeKey = 'PLACEMENT'
    AND QualifierValue IS NULL" );
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }
    }
}