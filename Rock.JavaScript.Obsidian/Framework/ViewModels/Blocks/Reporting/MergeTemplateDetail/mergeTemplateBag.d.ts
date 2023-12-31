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

import { MergeTemplateOwnership } from "@Obsidian/Enums/Controls/mergeTemplateOwnership";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type MergeTemplateBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the category. */
    category?: ListItemBag | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets the excluded category ids. */
    excludedCategoryIds?: string[] | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets a value indicating whether this instance is person required. */
    isPersonRequired: boolean;

    /** Gets or sets the merge template ownership. */
    mergeTemplateOwnership: MergeTemplateOwnership;

    /** Gets or sets the type of the merge template type entity. */
    mergeTemplateTypeEntityType?: ListItemBag | null;

    /** Gets or sets the name. */
    name?: string | null;

    /** Gets or sets the person alias. */
    personAlias?: ListItemBag | null;

    /** Gets or sets a value indicating whether [show category picker]. */
    showCategoryPicker: boolean;

    /** Gets or sets a value indicating whether [show person picker]. */
    showPersonPicker: boolean;

    /** Gets or sets the template binary file. */
    templateBinaryFile?: ListItemBag | null;
};
