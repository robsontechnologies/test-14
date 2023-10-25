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
    /// Base client model for BinaryFileType that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class BinaryFileTypeEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.11"
        [Obsolete( "Use CacheToServerFileSystem instead.", false )]
        public bool AllowCaching { get; set; }

        /// <summary />
        public string CacheControlHeaderSettings { get; set; }

        /// <summary />
        public bool CacheToServerFileSystem { get; set; }

        /// <summary />
        public string Description { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public string IconCssClass { get; set; }

        /// <summary />
        public bool IsSystem { get; set; }

        /// <summary />
        public int? MaxFileSizeBytes { get; set; }

        /// <summary />
        public int? MaxHeight { get; set; }

        /// <summary />
        public int? MaxWidth { get; set; }

        /// <summary>
        /// If the ModifiedByPersonAliasId is being set manually and should not be overwritten with current user when saved, set this value to true
        /// </summary>
        public bool ModifiedAuditValuesAlreadyUpdated { get; set; }

        /// <summary />
        public string Name { get; set; }

        /// <summary />
        public Rock.Client.Enums.ColorDepth PreferredColorDepth { get; set; } = Rock.Client.Enums.ColorDepth.Undefined;

        /// <summary />
        public Rock.Client.Enums.Format PreferredFormat { get; set; } = Rock.Client.Enums.Format.Undefined;

        /// <summary />
        public bool PreferredRequired { get; set; }

        /// <summary />
        public Rock.Client.Enums.Resolution PreferredResolution { get; set; } = Rock.Client.Enums.Resolution.Undefined;

        /// <summary />
        public bool RequiresViewSecurity { get; set; }

        /// <summary />
        public int? StorageEntityTypeId { get; set; }

        /// <summary>
        /// Leave this as NULL to let Rock set this
        /// </summary>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// This does not need to be set or changed. Rock will always set this to the current date/time when saved to the database.
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Leave this as NULL to let Rock set this
        /// </summary>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// If you need to set this manually, set ModifiedAuditValuesAlreadyUpdated=True to prevent Rock from setting it
        /// </summary>
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source BinaryFileType object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( BinaryFileType source )
        {
            this.Id = source.Id;
            #pragma warning disable 612, 618
            this.AllowCaching = source.AllowCaching;
            #pragma warning restore 612, 618
            this.CacheControlHeaderSettings = source.CacheControlHeaderSettings;
            this.CacheToServerFileSystem = source.CacheToServerFileSystem;
            this.Description = source.Description;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.IconCssClass = source.IconCssClass;
            this.IsSystem = source.IsSystem;
            this.MaxFileSizeBytes = source.MaxFileSizeBytes;
            this.MaxHeight = source.MaxHeight;
            this.MaxWidth = source.MaxWidth;
            this.ModifiedAuditValuesAlreadyUpdated = source.ModifiedAuditValuesAlreadyUpdated;
            this.Name = source.Name;
            this.PreferredColorDepth = source.PreferredColorDepth;
            this.PreferredFormat = source.PreferredFormat;
            this.PreferredRequired = source.PreferredRequired;
            this.PreferredResolution = source.PreferredResolution;
            this.RequiresViewSecurity = source.RequiresViewSecurity;
            this.StorageEntityTypeId = source.StorageEntityTypeId;
            this.CreatedDateTime = source.CreatedDateTime;
            this.ModifiedDateTime = source.ModifiedDateTime;
            this.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            this.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for BinaryFileType that includes all the fields that are available for GETs. Use this for GETs (use BinaryFileTypeEntity for POST/PUTs)
    /// </summary>
    public partial class BinaryFileType : BinaryFileTypeEntity
    {
        /// <summary />
        public EntityType StorageEntityType { get; set; }

        /// <summary>
        /// NOTE: Attributes are only populated when ?loadAttributes is specified. Options for loadAttributes are true, false, 'simple', 'expanded' 
        /// </summary>
        public Dictionary<string, Rock.Client.Attribute> Attributes { get; set; }

        /// <summary>
        /// NOTE: AttributeValues are only populated when ?loadAttributes is specified. Options for loadAttributes are true, false, 'simple', 'expanded' 
        /// </summary>
        public Dictionary<string, Rock.Client.AttributeValue> AttributeValues { get; set; }
    }
}