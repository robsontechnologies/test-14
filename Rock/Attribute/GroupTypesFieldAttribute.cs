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

namespace Rock.Attribute
{
    /// <summary>
    /// Field Attribute to select 0 or more GroupTypes
    /// Stored as a list of Guids
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = true )]
    public class GroupTypesFieldAttribute : SelectFieldAttribute
    {
        /// <summary>
        /// The key value for the enhanced selection value to use in the FieldConfigurationValues dictionary.
        /// </summary>
        private const string ENHANCED_SELECTION_KEY = "enhancedselection";

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTypesFieldAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="defaultGroupTypeGuids">The default group type guids.</param>
        /// <param name="category">The category.</param>
        /// <param name="order">The order.</param>
        /// <param name="key">The key.</param>
        public GroupTypesFieldAttribute( string name, string description = "", bool required = true, string defaultGroupTypeGuids = "", string category = "", int order = 0, string key = null )
            : base( name, description, required, defaultGroupTypeGuids, category, order, key, typeof( Rock.Field.Types.GroupTypesFieldType ).FullName )
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether enhanced selection should be used.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enhanced selection should be used; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// The default value for this is <c>false</c>, but in the future it may be changed to <c>true</c>.
        /// </remarks>
        public bool EnhancedSelection
        {
            get => FieldConfigurationValues.GetValueOrNull( ENHANCED_SELECTION_KEY )?.AsBoolean() ?? false;
            set => FieldConfigurationValues.AddOrReplace( ENHANCED_SELECTION_KEY, new Field.ConfigurationValue( value.ToString() ) );
        }
    }
}
