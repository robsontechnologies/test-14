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

import { Guid } from "@Obsidian/Types";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

export type FinancialPledgeEntryOptionsBag = {
    /** Gets or sets the groups. */
    groups?: ListItemBag[] | null;

    /** Gets or sets the groups label. */
    groupsLabel?: string | null;

    /** Gets or sets the note message. */
    noteMessage?: string | null;

    /** Gets or sets the pledge frequencies. */
    pledgeFrequencies?: ListItemBag[] | null;

    /** Gets or sets the pledge term. */
    pledgeTerm?: string | null;

    /** Gets or sets a value indicating whether require that a user select a specific pledge frequency (when pledge frequency is shown) */
    requirePledgeFrequency: boolean;

    /** Gets or sets the save button text. */
    saveButtonText?: string | null;

    /** Gets or sets the select group type unique identifier. */
    selectGroupTypeGuid?: Guid | null;

    /** Gets or sets a value indicating whether [show date range]. */
    showDateRange: boolean;

    /** Gets or sets a value indicating whether to show the pledge frequency option to the user.. */
    showPledgeFrequency: boolean;
};
