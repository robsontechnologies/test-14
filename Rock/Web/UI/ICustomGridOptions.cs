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

namespace Rock.Web.UI
{
    /// <summary>
    /// Interface for Blocks that have a grid that support custom grid options, like sticky headers
    /// from Block Configuration.
    /// NOTE: If the grid also supports Custom Columns, use <see cref="ICustomGridColumns"/> instead
    /// </summary>
    public interface ICustomGridOptions
    {
    }

    /// <summary>
    /// Config Class for blocks that support custom grid options, like sticky headers
    /// </summary>
    public class CustomGridOptionsConfig
    {
        /// <summary>
        /// The enable sticky headers attribute key
        /// </summary>
        public const string EnableStickyHeadersAttributeKey = "core.CustomGridEnableStickyHeaders";

        /// <summary>
        /// The custom actions configs attribute key
        /// </summary>
        public const string CustomActionsConfigsAttributeKey = "core.CustomActionsConfigs";

        /// <summary>
        /// The enable default workflow launcher attribute key
        /// </summary>
        public const string EnableDefaultWorkflowLauncherAttributeKey = "core.EnableDefaultWorkflowLauncher";
    }
}
