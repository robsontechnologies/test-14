﻿// <copyright>
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
using System;

using Humanizer;

namespace Rock
{
    /// <summary>
    /// Handy string extensions that require Humanizer
    /// </summary>
    public static partial class ExtensionMethods
    {
        #region String/Humanizer Extensions

        /// <summary>
        /// If string is all lower or all upper case, will change to title case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string FixCase( string text )
        {
            if ( !string.IsNullOrWhiteSpace( text ) )
            {
                string trimmed = text.Trim();
                if ( trimmed == trimmed.ToLower() || trimmed == trimmed.ToUpper() )
                {
                    if ( trimmed == trimmed.ToUpper() )
                    {
                        // if all uppercase, do a ToLower first so that Humanizer doesn't assume it is an acronym 
                        // see https://github.com/Humanizr/Humanizer/issues/452
                        return trimmed.ToLower().Transform( To.TitleCase );
                    }
                    else
                    {
                        return trimmed.Transform( To.TitleCase );
                    }
                }
            }

            return text;
        }

        #endregion String/Humanizer Extensions
    }
}
