//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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


namespace Rock.Client
{
    /// <summary>
    /// Base client model for PersonPreference that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class PersonPreferenceEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public int? EntityId { get; set; }

        /// <summary />
        public int? EntityTypeId { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public bool IsEnduring { get; set; }

        /// <summary />
        public string Key { get; set; }

        /// <summary />
        public DateTime LastAccessedDateTime { get; set; }

        /// <summary />
        public int PersonAliasId { get; set; }

        /// <summary />
        public string Value { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source PersonPreference object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( PersonPreference source )
        {
            this.Id = source.Id;
            this.EntityId = source.EntityId;
            this.EntityTypeId = source.EntityTypeId;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.IsEnduring = source.IsEnduring;
            this.Key = source.Key;
            this.LastAccessedDateTime = source.LastAccessedDateTime;
            this.PersonAliasId = source.PersonAliasId;
            this.Value = source.Value;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for PersonPreference that includes all the fields that are available for GETs. Use this for GETs (use PersonPreferenceEntity for POST/PUTs)
    /// </summary>
    public partial class PersonPreference : PersonPreferenceEntity
    {
        /// <summary />
        public EntityType EntityType { get; set; }

        /// <summary />
        public PersonAlias PersonAlias { get; set; }

    }
}
