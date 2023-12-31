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
    [MigrationNumber( 147, "1.13.0" )]
    public class MigrationRolupsFor13_1 : Migration
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
            UpdateEntityTypeLinkUrlLavaTemplate_Up();
            FixSystemCommunicationLavaSyntax_Up();
            FixSchedulingConfirmationLavaSyntax_Up();
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }

        /// <summary>
        /// MP: EntityTypeLinkUrlLavaTemplate
        /// </summary>
        private void UpdateEntityTypeLinkUrlLavaTemplate_Up()
        {
            // Update EntityType so that Workflow and Registration have LinkUrlLavaTemplate's
            Sql( @"
                UPDATE [EntityType]
                SET [LinkUrlLavaTemplate] = '~/Workflow/{{ Entity.Id }}'
                WHERE [Guid] = '" + Rock.SystemGuid.EntityType.WORKFLOW + "'" );

            Sql( @"
                UPDATE [EntityType]
                SET [LinkUrlLavaTemplate] = '~/web/event-registrations/{{ Entity.RegistrationInstanceId }}/registration/{{ Entity.Id }}'
                WHERE [Guid] = '" + Rock.SystemGuid.EntityType.REGISTRATION + "'" );
        }

        /// <summary>
        /// DL: Fix Lava Syntax for System Communications
        /// </summary>
        private void FixSystemCommunicationLavaSyntax_Up()
        {
            string searchText;
            string replaceText;

            // Workflow Form Notification Template.
            // Replace '&&' operator with the Liquid operator 'and'.
            searchText = "attribute.IsRequired && attribute.Value";
            replaceText = "attribute.IsRequired and attribute.Value";

            Sql( $@"
                UPDATE [SystemCommunication]
                SET [Body] = REPLACE([Body],'{searchText}','{replaceText}')
                WHERE [Guid] = '{SystemGuid.SystemCommunication.WORKFLOW_FORM_NOTIFICATION}'
                " );

            // Group Attendance Reminder Template.
            // Replace the use of the '\' escape character in a string with the "EscapeDataString" filter.
            searchText = @"Date:'yyyy-MM-ddTHH\%3amm\%3ass'".Replace( "'", "''" );
            replaceText = @"Date:'yyyy-MM-ddTHH:mm:ss' | EscapeDataString".Replace( "'", "''" );

            Sql( $@"
                UPDATE [SystemCommunication]
                SET [Body] = REPLACE([Body],'{searchText}','{replaceText}')
                WHERE [Guid] = '{SystemGuid.SystemCommunication.GROUP_ATTENDANCE_REMINDER}'
                " );

            // Attendance Summary Notification Template.
            // Replace invalid '- %}' sequence with the corrected ' -%}'.
            searchText = "- %}";
            replaceText = " -%}";

            Sql( $@"
                UPDATE [SystemCommunication]
                SET [Body] = REPLACE([Body],'{searchText}','{replaceText}')
                WHERE [Guid] = '{SystemGuid.SystemCommunication.ATTENDANCE_NOTIFICATION}'
                " );
        }

        /// <summary>
        /// DL: Fix Lava for Scheduling Confirmation
        /// </summary>
        private void FixSchedulingConfirmationLavaSyntax_Up()
        {
            string searchText;
            string replaceText;

            // Scheduling Confirmation Template.
            // Update Obsolete Model References.
            searchText = "attendance.Location.Name";
            replaceText = "attendance.Occurrence.Location.Name";

            Sql( $@"
                UPDATE [SystemCommunication]
                SET [Body] = REPLACE([Body],'{searchText}','{replaceText}')
                WHERE [Guid] IN ('{SystemGuid.SystemCommunication.SCHEDULING_REMINDER}','{SystemGuid.SystemCommunication.SCHEDULING_CONFIRMATION}')
                " );

            searchText = "attendance.Schedule.Name";
            replaceText = "attendance.Occurrence.Schedule.Name";

            Sql( $@"
                UPDATE [SystemCommunication]
                SET [Body] = REPLACE([Body],'{searchText}','{replaceText}')
                WHERE [Guid] IN ('{SystemGuid.SystemCommunication.SCHEDULING_REMINDER}','{SystemGuid.SystemCommunication.SCHEDULING_CONFIRMATION}')
                " );
        }
    }
}
