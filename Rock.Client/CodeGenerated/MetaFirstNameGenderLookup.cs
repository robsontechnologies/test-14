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
    /// Base client model for MetaFirstNameGenderLookup that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class MetaFirstNameGenderLookupEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public string Country { get; set; }

        /// <summary />
        public int? FemaleCount { get; set; }

        /// <summary />
        public decimal? FemalePercent { get; set; }

        /// <summary />
        public string FirstName { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public string Language { get; set; }

        /// <summary />
        public int? MaleCount { get; set; }

        /// <summary />
        public decimal? MalePercent { get; set; }

        /// <summary />
        public int? TotalCount { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source MetaFirstNameGenderLookup object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( MetaFirstNameGenderLookup source )
        {
            this.Id = source.Id;
            this.Country = source.Country;
            this.FemaleCount = source.FemaleCount;
            this.FemalePercent = source.FemalePercent;
            this.FirstName = source.FirstName;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.Language = source.Language;
            this.MaleCount = source.MaleCount;
            this.MalePercent = source.MalePercent;
            this.TotalCount = source.TotalCount;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for MetaFirstNameGenderLookup that includes all the fields that are available for GETs. Use this for GETs (use MetaFirstNameGenderLookupEntity for POST/PUTs)
    /// </summary>
    public partial class MetaFirstNameGenderLookup : MetaFirstNameGenderLookupEntity
    {
    }
}
