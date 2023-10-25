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

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// ConnectionRequest Service class
    /// </summary>
    public partial class ConnectionRequestService : Service<ConnectionRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionRequestService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public ConnectionRequestService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( ConnectionRequest item, out string errorMessage )
        {
            errorMessage = string.Empty;

            // ignoring ConnectionRequestActivity,ConnectionRequestId
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class ConnectionRequestExtensionMethods
    {
        /// <summary>
        /// Clones this ConnectionRequest object to a new ConnectionRequest object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static ConnectionRequest Clone( this ConnectionRequest source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as ConnectionRequest;
            }
            else
            {
                var target = new ConnectionRequest();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this ConnectionRequest object to a new ConnectionRequest object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static ConnectionRequest CloneWithoutIdentity( this ConnectionRequest source )
        {
            var target = new ConnectionRequest();
            target.CopyPropertiesFrom( source );

            target.Id = 0;
            target.Guid = Guid.NewGuid();
            target.ForeignKey = null;
            target.ForeignId = null;
            target.ForeignGuid = null;
            target.CreatedByPersonAliasId = null;
            target.CreatedDateTime = RockDateTime.Now;
            target.ModifiedByPersonAliasId = null;
            target.ModifiedDateTime = RockDateTime.Now;

            return target;
        }

        /// <summary>
        /// Copies the properties from another ConnectionRequest object to this ConnectionRequest object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this ConnectionRequest target, ConnectionRequest source )
        {
            target.Id = source.Id;
            target.AssignedGroupId = source.AssignedGroupId;
            target.AssignedGroupMemberAttributeValues = source.AssignedGroupMemberAttributeValues;
            target.AssignedGroupMemberRoleId = source.AssignedGroupMemberRoleId;
            target.AssignedGroupMemberStatus = source.AssignedGroupMemberStatus;
            target.CampusId = source.CampusId;
            target.Comments = source.Comments;
            target.ConnectionOpportunityId = source.ConnectionOpportunityId;
            target.ConnectionState = source.ConnectionState;
            target.ConnectionStatusId = source.ConnectionStatusId;
            target.ConnectionTypeId = source.ConnectionTypeId;
            target.ConnectorPersonAliasId = source.ConnectorPersonAliasId;
            target.FollowupDate = source.FollowupDate;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.Order = source.Order;
            target.PersonAliasId = source.PersonAliasId;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
