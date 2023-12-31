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
using System.Collections.Generic;

namespace Rock.ViewModels.Rest.Controls
{
    /// <summary>
    /// The options that can be passed to the GetChildren API action of
    /// the RegistrationTemplatePicker control.
    /// </summary>
    public class WorkflowActionTypePickerGetChildrenOptionsBag
    {
        /// <summary>
        /// The identifier of the parent folder/category.
        /// If null then the folders are being requested.
        /// </summary>
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// Gets or sets the security grant token to use when performing
        /// authorization checks.
        /// </summary>
        public string SecurityGrantToken { get; set; }
    }
}

