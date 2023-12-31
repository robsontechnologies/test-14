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
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using Rock.Data;
using Rock.Model;
using Rock.Security;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// Control that can be used to select multiple data views
    /// </summary>
    public class DataViewsPicker : RockListBox
    {
        #region Properties
        /// <summary>
        /// Gets or sets the data view entity type identifier.
        /// </summary>
        /// <value>
        /// The data view entity type identifier.
        /// </value>
        public int? EntityTypeId
        {
            get
            {
                return _entityTypeId;
            }

            set
            {
                _entityTypeId = value;
                LoadListBoxItems();
            }
        }

        /// <summary>
        /// The data view entity type identifier
        /// </summary>
        private int? _entityTypeId;

        /// <summary>
        /// Gets or sets a value indicating whether [display persisted only].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display pesisted only]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayPersistedOnly
        {
            get
            {
                return ViewState["DisplayPersistedOnly"] as bool? ?? false;
            }

            set
            {
                ViewState["DisplayPersistedOnly"] = value;
                LoadListBoxItems();
            }
        }

        #endregion Properties

        /// <summary>
        /// Loads the list box items.
        /// </summary>
        private void LoadListBoxItems()
        {
            this.Items.Clear();

            if ( !_entityTypeId.HasValue )
            {
                return;
            }

            // add Empty option first
            this.Items.Add( new ListItem() );

            var currentPerson = System.Web.HttpContext.Current?.Items["CurrentPerson"] as Person;

            using ( var rockContext = new RockContext() )
            {
                var allEntityFilters = new DataViewFilterService( rockContext )
                    .Queryable().AsNoTracking()
                    .Where( f => f.EntityTypeId == _entityTypeId )
                    .ToList();

                foreach ( var dataView in new DataViewService( rockContext )
                    .GetByEntityTypeId( _entityTypeId.Value )
                    .Include( "EntityType" )
                    .Include( "Category" )
                    .Include( "DataViewFilter" )
                    .Where( d => DisplayPersistedOnly == false || (d.PersistedScheduleIntervalMinutes.HasValue || d.PersistedScheduleId.HasValue) ) // if display persisted only is set to true, fetch only persisted data views
                    .AsNoTracking() )
                {
                    if ( dataView.IsAuthorized( Authorization.VIEW, currentPerson )
                        && dataView.DataViewFilter != null
                        && dataView.DataViewFilter.IsAuthorized( Authorization.VIEW, currentPerson, allEntityFilters ) )
                    {
                        this.Items.Add( new ListItem( dataView.Name, dataView.Id.ToString() ) );
                    }
                }
            }
        }
    }
}
