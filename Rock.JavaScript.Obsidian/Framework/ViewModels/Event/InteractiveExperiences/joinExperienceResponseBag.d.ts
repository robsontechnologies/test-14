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

import { ActionRenderConfigurationBag } from "@Obsidian/ViewModels/Event/InteractiveExperiences/actionRenderConfigurationBag";
import { VisualizerRenderConfigurationBag } from "@Obsidian/ViewModels/Event/InteractiveExperiences/visualizerRenderConfigurationBag";

/** The response object returned by the Join Experience real-time command. */
export type JoinExperienceResponseBag = {
    /** Gets or sets the current action identifier key. */
    currentActionConfiguration?: ActionRenderConfigurationBag | null;

    /** Gets or sets the currently displayed action identifier. */
    currentActionIdKey?: string | null;

    /** Gets or sets the action identifier for the currently displayed visualizer. */
    currentVisualizerActionIdKey?: string | null;

    /** Gets or sets the current visualizer identifier key. */
    currentVisualizerConfiguration?: VisualizerRenderConfigurationBag | null;

    /**
     * Gets or sets the identifier of the experience occurrence that has
     * been joined. This should be treated as a string of unknown data
     * as the format might change in the future.
     */
    occurrenceIdKey?: string | null;
};
