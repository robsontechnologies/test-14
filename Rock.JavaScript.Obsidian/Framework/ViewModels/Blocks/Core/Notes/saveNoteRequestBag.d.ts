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

import { NoteEditBag } from "@Obsidian/ViewModels/Blocks/Core/Notes/noteEditBag";

/** Describes a request to save changes to an existing note. */
export type SaveNoteRequestBag = {
    /** Gets or sets the bag that contains the changes that should be made to the note. */
    bag?: NoteEditBag | null;

    /** Gets the valid properties of the Rock.ViewModels.Blocks.Core.Notes.SaveNoteRequestBag.Bag. */
    validProperties?: string[] | null;
};
