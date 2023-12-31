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

using Rock.Field.Types;

namespace Rock.Attribute
{
    /// <summary>
    /// Stored as NoteType.Guid
    /// </summary>
    public class NoteTypeFieldAttribute : FieldAttribute
    {
        private const string ENTITY_TYPE_NAME_KEY = "entityTypeName";
        private const string QUALIFIER_COLUMN_KEY = "qualifierColumn";
        private const string QUALIFIER_VALUE_KEY = "qualifierValue";

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryFieldAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="allowMultiple">if set to <c>true</c> [allow multiple].</param>
        /// <param name="entityTypeName">Name of the entity type.</param>
        /// <param name="entityTypeQualifierColumn">The entity type qualifier column.</param>
        /// <param name="entityTypeQualifierValue">The entity type qualifier value.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="category">The category.</param>
        /// <param name="order">The order.</param>
        /// <param name="key">The key.</param>
        public NoteTypeFieldAttribute( string name, string description = "", bool allowMultiple = false,
             string entityTypeName = "", string entityTypeQualifierColumn = "", string entityTypeQualifierValue = "",
             bool required = true, string defaultValue = "", string category = "", int order = 0, string key = null ) :
            base( name, description, required, defaultValue, category, order, key,
                ( allowMultiple ? typeof( NoteTypesFieldType ).FullName : typeof( NoteTypeFieldType ).FullName ) )
        {
            FieldConfigurationValues.Add( ENTITY_TYPE_NAME_KEY, new Field.ConfigurationValue( entityTypeName ) );
            FieldConfigurationValues.Add( QUALIFIER_COLUMN_KEY, new Field.ConfigurationValue( entityTypeQualifierColumn ) );
            FieldConfigurationValues.Add( QUALIFIER_VALUE_KEY, new Field.ConfigurationValue( entityTypeQualifierValue ) );
        }

        /// <summary>
        /// Gets or sets a value indicating whether allow multiple is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow multiple]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowMultiple
        {
            get => this.FieldTypeClass == typeof( NoteTypesFieldType ).FullName;
            set => this.FieldTypeClass = value ? typeof( NoteTypesFieldType ).FullName : typeof( NoteTypeFieldType ).FullName;
        }

        /// <summary>
        /// Gets or sets the EntityType to limit NoteTypes to
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public Type EntityType
        {
            get
            {
                string entityTypeName = this.EntityTypeName;
                return entityTypeName.IsNotNullOrWhiteSpace() ? Type.GetType( entityTypeName ) : null;
            }

            set
            {
                this.EntityTypeName = value.FullName;
            }
        }

        /// <summary>
        /// Gets or sets the name of the entity type.
        /// </summary>
        /// <value>
        /// The name of the entity type.
        /// </value>
        public string EntityTypeName
        {
            get
            {
                if(FieldConfigurationValues.ContainsKey( ENTITY_TYPE_NAME_KEY ) )
                {
                    return FieldConfigurationValues[ENTITY_TYPE_NAME_KEY].Value;
                }
                return string.Empty;
            }
            set => FieldConfigurationValues[ENTITY_TYPE_NAME_KEY] = new Field.ConfigurationValue( value );
        }

        /// <summary>
        /// Gets or sets the entity type qualifier column.
        /// </summary>
        /// <value>
        /// The entity type qualifier column.
        /// </value>
        public string EntityTypeQualifierColumn
        {
            get
            {
                if ( FieldConfigurationValues.ContainsKey( QUALIFIER_COLUMN_KEY ) )
                {
                    return FieldConfigurationValues[QUALIFIER_COLUMN_KEY].Value;
                }
                return string.Empty;
            }
            set => FieldConfigurationValues[QUALIFIER_COLUMN_KEY] = new Field.ConfigurationValue( value );
        }

        /// <summary>
        /// Gets or sets the entity type qualifier value.
        /// </summary>
        /// <value>
        /// The entity type qualifier value.
        /// </value>
        public string EntityTypeQualifierValue
        {
            get
            {
                if ( FieldConfigurationValues.ContainsKey( QUALIFIER_VALUE_KEY ) )
                {
                    return FieldConfigurationValues[QUALIFIER_VALUE_KEY].Value;
                }
                return string.Empty;
            }
            set => FieldConfigurationValues[QUALIFIER_VALUE_KEY] = new Field.ConfigurationValue( value );
        }
    }
}
