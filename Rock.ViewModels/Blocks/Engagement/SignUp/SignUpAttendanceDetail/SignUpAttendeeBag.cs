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

namespace Rock.ViewModels.Blocks.Engagement.SignUp.SignUpAttendanceDetail
{
    /// <summary>
    /// Information about an attendee, including whether they attended a given sign-up project occurrence.
    /// </summary>
    public class SignUpAttendeeBag
    {
        /// <summary>
        /// Gets or sets the person alias identifier.
        /// </summary>
        /// <value>
        /// The person alias identifier.
        /// </value>
        public int PersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [did attend].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [did attend]; otherwise, <c>false</c>.
        /// </value>
        public bool DidAttend { get; set; }
    }
}
