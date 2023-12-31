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
using System.Linq;

namespace Rock.Model
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DocumentTypeService
    {
        /// <summary>
        /// Gets the specified entity type identifier.
        /// </summary>
        /// <param name="entityTypeId">The entity type identifier.</param>
        /// <param name="entityQualifierColumn">The entity qualifier column.</param>
        /// <param name="entityQualifierValue">The entity qualifier value.</param>
        /// <returns></returns>
        public IQueryable<DocumentType> Get( int entityTypeId, string entityQualifierColumn, string entityQualifierValue )
        {
            var qry = Queryable().Where( d => d.EntityTypeId == entityTypeId );

            if ( entityQualifierColumn.IsNotNullOrWhiteSpace() )
            {
                qry = qry.Where( t => t.EntityTypeQualifierColumn == entityQualifierColumn );
            }

            if ( entityQualifierValue.IsNotNullOrWhiteSpace() )
            {
                qry = qry.Where( t => t.EntityTypeQualifierValue == entityQualifierValue );
            }

            return qry.OrderBy( t => t.Name );
        }
    }
}
