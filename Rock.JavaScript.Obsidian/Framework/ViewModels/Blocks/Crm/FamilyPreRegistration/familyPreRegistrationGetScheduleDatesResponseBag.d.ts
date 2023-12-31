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

import { FamilyPreRegistrationDateAndTimeFieldBag } from "@Obsidian/ViewModels/Blocks/Crm/FamilyPreRegistration/familyPreRegistrationDateAndTimeFieldBag";
import { FamilyPreRegistrationScheduleDateBag } from "@Obsidian/ViewModels/Blocks/Crm/FamilyPreRegistration/familyPreRegistrationScheduleDateBag";

/** The bag that contains all the information from getting schedules in the Family Pre-Registration block. */
export type FamilyPreRegistrationGetScheduleDatesResponseBag = {
    /** Gets or sets the error text. */
    errorText?: string | null;

    /** Gets or sets the error title. */
    errorTitle?: string | null;

    /** Gets or sets the schedule dates. */
    scheduleDates?: FamilyPreRegistrationScheduleDateBag[] | null;

    /** Gets or sets the visit date field. */
    visitDateField?: FamilyPreRegistrationDateAndTimeFieldBag | null;
};
