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
using System.Linq;
using System.Web.UI.WebControls;

using Rock.Data;
using Rock.Model;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// Control that can be used to select a <see cref="FinancialStatementTemplate"/>
    /// </summary>
    public class FinancialStatementTemplatePicker : RockDropDownList
    {
        /// <summary>
        /// Handles the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            LoadItems();
        }

        /// <summary>
        /// Loads the items.
        /// </summary>
        /// <returns></returns>
        private void LoadItems( )
        {
            int? selectedItem = this.SelectedValueAsInt();

            this.Items.Clear();
            this.Items.Add( new ListItem() );

            using ( var rockContext = new RockContext() )
            {
                foreach ( var financialStatementTemplate in new FinancialStatementTemplateService( rockContext )
                    .Queryable().Where( s => s.IsActive == true ).OrderBy(a => a.Name).ToList() )
                {
                    this.Items.Add( new ListItem( financialStatementTemplate.Name, financialStatementTemplate.Id.ToString() ) );
                }
            }

            this.SetValue( selectedItem );
        }
    }
}