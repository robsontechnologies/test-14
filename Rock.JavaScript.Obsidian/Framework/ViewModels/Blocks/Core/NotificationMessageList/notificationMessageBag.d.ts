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

/** A notification message that should be displayed in the list block. */
export type NotificationMessageBag = {
    /** Gets or sets the color of the message. */
    color?: string | null;

    /** Gets or sets the component identifier key. */
    componentIdKey?: string | null;

    /** Gets or sets the count related to the message. */
    count: number;

    /** Gets or sets the date time of the message. */
    dateTime?: string | null;

    /** Gets or sets the description. */
    description?: string | null;

    /** Gets or sets the icon CSS class that represents the message. */
    iconCssClass?: string | null;

    /** Gets or sets the identifier of the notification message. */
    idKey?: string | null;

    /** Gets or sets a value indicating whether this message has been read. */
    isRead: boolean;

    /** Gets or sets the photo URL to display with the message. */
    photoUrl?: string | null;

    /** Gets or sets the title. */
    title?: string | null;
};
