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

import { GroupRegistrationBag } from "@Obsidian/ViewModels/Blocks/Group/GroupRegistration/groupRegistrationBag";

export type GroupRegistrationBlockBox = {
    /** Gets or sets a value indicating whether /[automatic fill]. */
    autoFill: boolean;

    /** Gets or sets the entity. */
    entity?: GroupRegistrationBag | null;

    /**
     * Gets or sets the error message. A non-empty value indicates that
     * an error is preventing the block from being displayed.
     */
    errorMessage?: string | null;

    /** Gets or sets a value indicating whether this instance is email required. */
    isEmailRequired: boolean;

    /** Gets or sets a value indicating whether this instance is mobile phone required. */
    isMobilePhoneRequired: boolean;

    /** Gets or sets the lava over view. */
    lavaOverview?: string | null;

    /** Gets or sets the mode. */
    mode?: string | null;

    /** Gets or sets the navigation urls. */
    navigationUrls?: Record<string, string> | null;

    /** Gets or sets the open spots. */
    openSpots: number;

    /** Gets or sets the phone label. */
    phoneLabel?: string | null;

    /** Gets or sets the register button alt text */
    registerButtonAltText?: string | null;

    /** Gets or sets the security grant token. */
    securityGrantToken?: string | null;

    /** Gets or sets a value indicating whether the field is hidden. */
    smsIsHidden: boolean;

    /** Gets or sets a value indicating whether the field is required. */
    smsIsShowAllAdults: boolean;

    /** Gets or sets a value indicating whether the field is shown. */
    smsIsShowFirstAdult: boolean;

    /** Gets or sets the text to display for the SMS Opt In checkbox */
    smsOptInDisplayText?: string | null;
};
