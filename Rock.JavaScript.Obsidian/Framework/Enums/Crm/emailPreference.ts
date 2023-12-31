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

/** The person's email preference */
export const EmailPreference = {
    /** Emails can be sent to person */
    EmailAllowed: 0,

    /** No Mass emails should be sent to person */
    NoMassEmails: 1,

    /** No emails should be sent to person */
    DoNotEmail: 2
} as const;

/** The person's email preference */
export const EmailPreferenceDescription: Record<number, string> = {
    0: "Email Allowed",

    1: "No Mass Emails",

    2: "Do Not Email"
};

/** The person's email preference */
export type EmailPreference = typeof EmailPreference[keyof typeof EmailPreference];
