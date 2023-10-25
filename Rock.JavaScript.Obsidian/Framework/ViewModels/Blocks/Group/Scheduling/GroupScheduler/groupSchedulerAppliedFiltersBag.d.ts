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

import { GroupSchedulerFiltersBag } from "@Obsidian/ViewModels/Blocks/Group/Scheduling/GroupScheduler/groupSchedulerFiltersBag";
import { GroupSchedulerOccurrenceBag } from "@Obsidian/ViewModels/Blocks/Group/Scheduling/GroupScheduler/groupSchedulerOccurrenceBag";

/** The filters that were applied in response to an "ApplyFilters" request, and the resulting occurrences to be scheduled. */
export type GroupSchedulerAppliedFiltersBag = {
    /** Gets or sets the filters that were applied. */
    filters?: GroupSchedulerFiltersBag | null;

    /** Gets or sets the navigation urls. */
    navigationUrls?: Record<string, string> | null;

    /** Gets or sets the occurrences to be scheduled, limited by the applied filters. */
    scheduleOccurrences?: GroupSchedulerOccurrenceBag[] | null;
};