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

import { ContentCollectionFilterControl } from "@Obsidian/Enums/Cms/contentCollectionFilterControl";
import { Guid } from "@Obsidian/Types";

/** Represents a single attribute filter for a content collection. */
export type AttributeFilterBag = {
    /** Gets or sets the internal identification key of the attribute. */
    attributeKey?: string | null;

    /** Gets or sets the friendly name of the attribute. */
    attributeName?: string | null;

    /** Gets or sets the field type unique identifier used by this filter. */
    fieldTypeGuid?: Guid | null;

    /** Gets or sets the friendly field type name used by this filter. */
    fieldTypeName?: string | null;

    /** Gets or sets the type of control to use when displaying this filter. */
    filterControl: ContentCollectionFilterControl;

    /** Gets or sets the friendly label to use when displaying this filter. */
    filterLabel?: string | null;

    /** Gets or sets the enabled state of this attribute filter. */
    isEnabled: boolean;

    /**
     * Gets or sets a value that indicates if this filter is in an
     * inconsistent state. If true then editing should not be
     * allowed.
     */
    isInconsistent: boolean;

    /** Gets or sets if multiple selections are allowed. */
    isMultipleSelection: boolean;

    /** Gets or sets the names of the sources that make up this filter. */
    sourceNames?: string[] | null;
};