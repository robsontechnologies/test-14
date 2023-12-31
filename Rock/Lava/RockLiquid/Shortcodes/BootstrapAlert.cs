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
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using DotLiquid;
using Rock.Lava.DotLiquid;

namespace Rock.Lava.Shortcodes
{
    /// <summary>
    ///
    /// </summary>
    public class BootstrapAlert : RockLavaShortcodeBlockBase
    {
        private static readonly Regex Syntax = new Regex( @"(\w+)" );

        string _markup = string.Empty;

        /// <summary>
        /// Method that will be run at Rock startup
        /// </summary>
        public override void OnStartup()
        {
            Template.RegisterShortcode<BootstrapAlert>( "bootstrapalert" );
        }

        /// <summary>
        /// Initializes the specified tag name.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="markup">The markup.</param>
        /// <param name="tokens">The tokens.</param>
        /// <exception cref="System.Exception">Could not find the variable to place results in.</exception>
        public override void Initialize( string tagName, string markup, List<string> tokens )
        {
            _markup = markup;

            base.Initialize( tagName, markup, tokens );
        }

        /// <summary>
        /// Renders the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="result">The result.</param>
        public override void Render( Context context, TextWriter result )
        {
            using ( TextWriter writer = new StringWriter() )
            {
                base.Render( context, writer );

                var settings = LavaElementAttributes.NewFromMarkup( _markup, new RockLiquidRenderContext( context ) );

                var className = "alert alert-info";
                if ( settings.HasValue( "type" ) )
                {
                    className = $"alert alert-{ settings.GetString("type") }";
                }

                result.Write( $"<div class='{className}'>{(writer.ToString())}</div>" );
            }
        }
    }
}