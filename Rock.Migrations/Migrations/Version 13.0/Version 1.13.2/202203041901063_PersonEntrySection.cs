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
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    ///
    /// </summary>
    public partial class PersonEntrySection : Rock.Migrations.RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.WorkflowActionForm", "PersonEntrySectionTypeValueId", c => c.Int());
            AddColumn("dbo.WorkflowActionForm", "PersonEntryTitle", c => c.String(maxLength: 500));
            AddColumn("dbo.WorkflowActionForm", "PersonEntryDescription", c => c.String());
            AddColumn("dbo.WorkflowActionForm", "PersonEntryShowHeadingSeparator", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WorkflowActionFormSection", "Title", c => c.String(maxLength: 500));
            CreateIndex("dbo.WorkflowActionForm", "PersonEntrySectionTypeValueId");
            AddForeignKey("dbo.WorkflowActionForm", "PersonEntrySectionTypeValueId", "dbo.DefinedValue", "Id");
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.WorkflowActionForm", "PersonEntrySectionTypeValueId", "dbo.DefinedValue");
            DropIndex("dbo.WorkflowActionForm", new[] { "PersonEntrySectionTypeValueId" });
            AlterColumn("dbo.WorkflowActionFormSection", "Title", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.WorkflowActionForm", "PersonEntryShowHeadingSeparator");
            DropColumn("dbo.WorkflowActionForm", "PersonEntryDescription");
            DropColumn("dbo.WorkflowActionForm", "PersonEntryTitle");
            DropColumn("dbo.WorkflowActionForm", "PersonEntrySectionTypeValueId");
        }
    }
}
