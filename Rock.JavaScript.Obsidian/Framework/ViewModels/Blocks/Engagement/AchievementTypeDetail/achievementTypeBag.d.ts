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

import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type AchievementTypeBag = {
    /** Gets or sets the Rock.Model.EntityType of the achievement. */
    achievementEntityType?: ListItemBag | null;

    /** Gets or sets the achievement event description. */
    achievementEventDescription?: string | null;

    /** Gets or sets the Rock.Model.WorkflowType to be launched when the achievement is failed (closed and not successful). */
    achievementFailureWorkflowType?: ListItemBag | null;

    /** Gets or sets the icon CSS class. */
    achievementIconCssClass?: string | null;

    /** Gets or sets the Rock.Model.WorkflowType to be launched when the achievement starts. */
    achievementStartWorkflowType?: ListItemBag | null;

    /** Gets or sets the Rock.Model.StepStatus to be used for the Rock.Model.StepType created when the achievement is completed. */
    achievementStepStatus?: ListItemBag | null;

    /** Gets or sets the Rock.Model.StepType to be created when the achievement is completed. */
    achievementStepType?: ListItemBag | null;

    /** Gets or sets the Rock.Model.WorkflowType to be launched when the achievement is successful. */
    achievementSuccessWorkflowType?: ListItemBag | null;

    /** Gets or sets a value indicating whether [add step on success]. */
    addStepOnSuccess: boolean;

    /** Gets or sets whether over achievement is allowed. This cannot be true if Rock.Model.AchievementType.MaxAccomplishmentsAllowed is greater than 1. */
    allowOverAchievement: boolean;

    /** Gets or sets the alternate image binary file. */
    alternateImageBinaryFile?: ListItemBag | null;

    /** Gets or sets the attempts. */
    attempts?: ListItemBag[] | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the available prerequisites. */
    availablePrerequisites?: ListItemBag[] | null;

    /** Gets or sets the lava template used to render a badge. */
    badgeLavaTemplate?: string | null;

    /** Gets or sets the Rock.Model.Category. */
    category?: ListItemBag | null;

    /** Gets or sets the chart data json. */
    chartDataJSON?: string | null;

    /** Gets or sets the lava template used to render the status summary of the achievement. */
    customSummaryLavaTemplate?: string | null;

    /** Gets or sets a description of the achievement type. */
    description?: string | null;

    /** Gets or sets the color of the highlight. */
    highlightColor?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the image binary file. */
    imageBinaryFile?: ListItemBag | null;

    /** Gets a value indicating whether this instance is active. */
    isActive: boolean;

    /** Gets or sets a value indicating whether this instance is public. */
    isPublic: boolean;

    /** Gets or sets the maximum accomplishments allowed. */
    maxAccomplishmentsAllowed?: number | null;

    /** Gets or sets the name of the achievement type. This property is required. */
    name?: string | null;

    /** Gets or sets the prerequisites. */
    prerequisites?: string[] | null;

    /** Gets or sets the lava template used to render results. */
    resultsLavaTemplate?: string | null;

    /**
     * Gets or sets the source entity type. The source supplies the data framework from which achievements are computed.
     * The original achievement sources were Streaks.
     */
    sourceEntityTypeId?: number | null;

    /** Gets or sets the step program. */
    stepProgram?: ListItemBag | null;
};
