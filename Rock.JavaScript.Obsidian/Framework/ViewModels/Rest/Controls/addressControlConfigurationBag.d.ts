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

import { RequirementLevel } from "@Obsidian/Enums/Controls/requirementLevel";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";

/**
 * The configuration options returned from the GetConfiguration API action of
 * the AddressControl control.
 */
export type AddressControlConfigurationBag = {
    /** Requirement level for the address line 1 field */
    addressLine1Requirement: RequirementLevel;

    /** Requirement level for the address line 2 field */
    addressLine2Requirement: RequirementLevel;

    /** Configured label for the city field (based on country's configuration) */
    cityLabel?: string | null;

    /** Requirement level for the city field */
    cityRequirement: RequirementLevel;

    /** List of countries for the country picker */
    countries?: ListItemBag[] | null;

    /** If no other country is set, this should be the default one selected */
    defaultCountry?: string | null;

    /** If no other state is set, this should be the default one selected */
    defaultState?: string | null;

    /** Whether there are any states for the picker. If not, use a text field */
    hasStateList: boolean;

    /** Configured label for the locality/county field (based on country's configuration) */
    localityLabel?: string | null;

    /** Requirement level for the locality field */
    localityRequirement: RequirementLevel;

    /** Configured label for the postal code field (based on country's configuration) */
    postalCodeLabel?: string | null;

    /** Requirement level for the postal code field */
    postalCodeRequirement: RequirementLevel;

    /** Currently selected country */
    selectedCountry?: string | null;

    /** Whether to show the country picker */
    showCountrySelection: boolean;

    /** Configured label for the state field (based on country's configuration) */
    stateLabel?: string | null;

    /** Requirement level for the state field */
    stateRequirement: RequirementLevel;

    /** List of states for the state picker (if any) */
    states?: ListItemBag[] | null;
};
