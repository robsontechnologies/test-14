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
using System.Linq.Expressions;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI.Controls;

namespace Rock.Reporting.DataSelect.Person
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "Select the names of the Person's Parents" )]
    [Export( typeof( DataSelectComponent ) )]
    [ExportMetadata( "ComponentName", "Select Person's Parents' Names" )]
    [Rock.SystemGuid.EntityTypeGuid( "0A97FB21-EC9E-4199-9872-AE526C7D0CBC")]
    public class ParentsNamesSelect : DataSelectComponent, IRecipientDataSelect
    {
        #region Properties

        /// <summary>
        /// Gets the name of the entity type. Filter should be an empty string
        /// if it applies to all entities
        /// </summary>
        /// <value>
        /// The name of the entity type.
        /// </value>
        public override string AppliesToEntityType
        {
            get
            {
                return typeof( Rock.Model.Person ).FullName;
            }
        }

        /// <summary>
        /// Gets the section that this will appear in in the Field Selector
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public override string Section
        {
            get
            {
                return base.Section;
            }
        }

        /// <summary>
        /// The PropertyName of the property in the anonymous class returned by the SelectExpression
        /// </summary>
        /// <value>
        /// The name of the column property.
        /// </value>
        public override string ColumnPropertyName
        {
            get
            {
                return "ParentsNames";
            }
        }

        /// <summary>
        /// Gets the type of the column field.
        /// </summary>
        /// <value>
        /// The type of the column field.
        /// </value>
        public override Type ColumnFieldType
        {
            get { return typeof( IEnumerable<string> ); }
        }

        /// <summary>
        /// Gets the grid field.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="selection">The selection.</param>
        /// <returns></returns>
        public override System.Web.UI.WebControls.DataControlField GetGridField( Type entityType, string selection )
        {
            return new ListDelimitedField();
        }

        /// <summary>
        /// Gets the default column header text.
        /// </summary>
        /// <value>
        /// The default column header text.
        /// </value>
        public override string ColumnHeaderText
        {
            get
            {
                return "Parent's Names";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        /// <value>
        /// The title.
        /// </value>
        public override string GetTitle( Type entityType )
        {
            return "Parent's Names";
        }

        /// <summary>
        /// Comma-delimited list of the Entity properties that should be used for Sorting. Normally, you should leave this as null which will make it sort on the returned field
        /// To disable sorting for this field, return string.Empty;
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        /// <value>
        /// The sort expression.
        /// </value>
        public override string SortProperties( string selection )
        {
            // disable sorting on this column since it is an IEnumerable
            return string.Empty;
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="entityIdProperty">The entity identifier property.</param>
        /// <param name="selection">The selection.</param>
        /// <returns></returns>
        public override Expression GetExpression( RockContext context, MemberExpression entityIdProperty, string selection )
        {
            Guid adultGuid = Rock.SystemGuid.GroupRole.GROUPROLE_FAMILY_MEMBER_ADULT.AsGuid();
            Guid childGuid = Rock.SystemGuid.GroupRole.GROUPROLE_FAMILY_MEMBER_CHILD.AsGuid();
            Guid familyGuid = Rock.SystemGuid.GroupType.GROUPTYPE_FAMILY.AsGuid();

            var familyGroupMembers = new GroupMemberService( context ).Queryable()
                .Where( m => m.Group.GroupType.Guid == familyGuid );

            // this returns Enumerable of string for Parents per row. The Grid then uses ListDelimiterField to convert the list into Parents Names
            var personParentsQuery = new PersonService( context ).Queryable()
                .Select( p => familyGroupMembers.Where( s => s.PersonId == p.Id && s.GroupRole.Guid == childGuid )
                    .SelectMany( m => m.Group.Members )
                    .Where( m => m.GroupRole.Guid == adultGuid )
                    .OrderBy( m => m.Group.Members.FirstOrDefault( x => x.PersonId == p.Id ).GroupOrder ?? int.MaxValue )
                    .ThenBy( m => m.Person.Gender )
                    .Select( m => m.Person.NickName + " " + m.Person.LastName ).AsEnumerable() );

            var selectParentsExpression = SelectExpressionExtractor.Extract( personParentsQuery, entityIdProperty, "p" );

            return selectParentsExpression;
        }

        /// <summary>
        /// Creates the child controls.
        /// </summary>
        /// <param name="parentControl"></param>
        /// <returns></returns>
        public override System.Web.UI.Control[] CreateChildControls( System.Web.UI.Control parentControl )
        {
            return new System.Web.UI.Control[] { };
        }

        /// <summary>
        /// Renders the controls.
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="writer">The writer.</param>
        /// <param name="controls">The controls.</param>
        public override void RenderControls( System.Web.UI.Control parentControl, System.Web.UI.HtmlTextWriter writer, System.Web.UI.Control[] controls )
        {
            base.RenderControls( parentControl, writer, controls );
        }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public override string GetSelection( System.Web.UI.Control[] controls )
        {
            return null;
        }

        /// <summary>
        /// Sets the selection.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <param name="selection">The selection.</param>
        public override void SetSelection( System.Web.UI.Control[] controls, string selection )
        {
            // nothing to do
        }

        #endregion

        #region IRecipientDataSelect implementation

        /// <summary>
        /// Gets the type of the recipient column field.
        /// </summary>
        /// <value>
        /// The type of the recipient column field.
        /// </value>
        public Type RecipientColumnFieldType
        {
            get { return typeof( IEnumerable<int> ); }
        }

        /// <summary>
        /// Gets the recipient person identifier expression.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="entityIdProperty">The entity identifier property.</param>
        /// <param name="selection">The selection.</param>
        /// <returns></returns>
        public Expression GetRecipientPersonIdExpression( System.Data.Entity.DbContext dbContext, MemberExpression entityIdProperty, string selection )
        {
            var rockContext = dbContext as RockContext;
            if ( rockContext != null )
            {
                Guid adultGuid = Rock.SystemGuid.GroupRole.GROUPROLE_FAMILY_MEMBER_ADULT.AsGuid();
                Guid childGuid = Rock.SystemGuid.GroupRole.GROUPROLE_FAMILY_MEMBER_CHILD.AsGuid();
                Guid familyGuid = Rock.SystemGuid.GroupType.GROUPTYPE_FAMILY.AsGuid();

                var familyGroupMembers = new GroupMemberService( rockContext ).Queryable()
                    .Where( m => m.Group.GroupType.Guid == familyGuid );

                // this returns Enumerable of ids for Parents per row. The Grid then uses ListDelimiterField to convert the list into Parents Names
                var personParentsQuery = new PersonService( rockContext ).Queryable()
                    .Select( p => familyGroupMembers.Where( s => s.PersonId == p.Id && s.GroupRole.Guid == childGuid )
                        .SelectMany( m => m.Group.Members )
                        .Where( m => m.GroupRole.Guid == adultGuid )
                        .OrderBy( m => m.Group.Members.FirstOrDefault( x => x.PersonId == p.Id ).GroupOrder ?? int.MaxValue )
                        .ThenBy( m => m.Person.Gender )
                        .Select( m => m.Person.Id ).AsEnumerable() );

                var selectParentsExpression = SelectExpressionExtractor.Extract( personParentsQuery, entityIdProperty, "p" );

                return selectParentsExpression;
            }

            return null;
        }

        #endregion
    }
}
