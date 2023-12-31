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
    /// Base client model for NotificationMessage that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class NotificationMessageEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public string ComponentDataJson { get; set; }

        /// <summary />
        public int Count { get; set; } = 1;

        /// <summary />
        public string Description { get; set; }

        /// <summary />
        public DateTime ExpireDateTime { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public bool IsRead { get; set; }

        /// <summary />
        public string Key { get; set; }

        /// <summary />
        public DateTime MessageDateTime { get; set; }

        /// <summary />
        public int NotificationMessageTypeId { get; set; }

        /// <summary />
        public int PersonAliasId { get; set; }

        /// <summary />
        public string Title { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source NotificationMessage object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( NotificationMessage source )
        {
            this.Id = source.Id;
            this.ComponentDataJson = source.ComponentDataJson;
            this.Count = source.Count;
            this.Description = source.Description;
            this.ExpireDateTime = source.ExpireDateTime;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.IsRead = source.IsRead;
            this.Key = source.Key;
            this.MessageDateTime = source.MessageDateTime;
            this.NotificationMessageTypeId = source.NotificationMessageTypeId;
            this.PersonAliasId = source.PersonAliasId;
            this.Title = source.Title;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for NotificationMessage that includes all the fields that are available for GETs. Use this for GETs (use NotificationMessageEntity for POST/PUTs)
    /// </summary>
    public partial class NotificationMessage : NotificationMessageEntity
    {
        /// <summary />
        public NotificationMessageType NotificationMessageType { get; set; }

        /// <summary />
        public PersonAlias PersonAlias { get; set; }

    }
}
