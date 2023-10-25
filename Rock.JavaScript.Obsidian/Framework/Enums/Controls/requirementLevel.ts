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

/**
 * Requirement level of an input field. Based off Rock.Field.Types.DataEntryRequirementLevelSpecifier
 * for transfer to/from Obsidian controls.
 */
export const RequirementLevel = {
    /** No requirement level has been specified for this field. */
    Unspecified: 0,

    /** The field is available but not required. */
    Optional: 1,

    /** The field is available and required. */
    Required: 2,

    /** The field is not available. */
    Unavailable: 3
} as const;

/**
 * Requirement level of an input field. Based off Rock.Field.Types.DataEntryRequirementLevelSpecifier
 * for transfer to/from Obsidian controls.
 */
export const RequirementLevelDescription: Record<number, string> = {
    0: "Unspecified",

    1: "Optional",

    2: "Required",

    3: "Unavailable"
};

/**
 * Requirement level of an input field. Based off Rock.Field.Types.DataEntryRequirementLevelSpecifier
 * for transfer to/from Obsidian controls.
 */
export type RequirementLevel = typeof RequirementLevel[keyof typeof RequirementLevel];
