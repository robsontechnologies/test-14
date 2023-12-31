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

/** Type of workflow trigger */
export const WorkflowTriggerType = {
    /** Pre Save */
    PreSave: 0,

    /** Post Save */
    PostSave: 1,

    /** Pre Delete */
    PreDelete: 2,

    /** Post Delete */
    PostDelete: 3,

    /** Immediate Post Save */
    ImmediatePostSave: 4,

    /** Post Add */
    PostAdd: 5
} as const;

/** Type of workflow trigger */
export const WorkflowTriggerTypeDescription: Record<number, string> = {
    0: "Pre Save",

    1: "Post Save",

    2: "Pre Delete",

    3: "Post Delete",

    4: "Immediate Post Save",

    5: "Post Add"
};

/** Type of workflow trigger */
export type WorkflowTriggerType = typeof WorkflowTriggerType[keyof typeof WorkflowTriggerType];
