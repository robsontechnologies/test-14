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
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using DotLiquid;

using Rock.UniversalSearch;
using Rock.Web.Cache;
using Rock.Lava.Blocks;
using Rock.Lava.DotLiquid;

namespace Rock.Lava.RockLiquid.Blocks
{

    /// <summary>
    /// Universal Search Lava Command
    /// </summary>
    public class Search : RockLavaBlockBase
    {
        private static readonly Regex Syntax = new Regex( @"(\w+)" );

        string _markup = string.Empty;

        /// <summary>
        /// Method that will be run at Rock startup
        /// </summary>
        public override void OnStartup()
        {
            Template.RegisterTag<Search>( "search" );
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
            // first ensure that search commands are allowed in the context
            if ( !this.IsAuthorized( context ) )
            {
                result.Write( string.Format( RockLavaBlockBase.NotAuthorizedMessage, this.Name ) );
                base.Render( context, result );
                return;
            }

            var settings = SearchBlock.GetAttributesFromMarkup( _markup, new RockLiquidRenderContext( context ) );
            var parms = settings.Attributes;

            SearchFieldCriteria fieldCriteria = new SearchFieldCriteria();

            SearchType searchType = SearchType.Wildcard;

            List<int> entityIds = new List<int>();
            string query = string.Empty;

            int limit = 50;
            int offset = 0;

            if (parms.Any( p => p.Key == "query" ) )
            {
                query = parms["query"];
            }

            if ( parms.Any( p => p.Key == "limit" ) )
            {
                Int32.TryParse( parms["limit"], out limit );
            }

            if ( parms.Any( p => p.Key == "offset" ) )
            {
                Int32.TryParse( parms["offset"], out offset );
            }

            if ( parms.Any( p => p.Key == "fieldcriteria" ) )
            {
                foreach ( var queryString in parms["fieldcriteria"].ToKeyValuePairList() )
                {
                    // check that multiple values were not passed
                    var values = queryString.Value.ToString().Split( ',' );

                    foreach ( var value in values )
                    {
                        // the first letter of the field name should be lowercase
                        string fieldName = Char.ToLowerInvariant( queryString.Key[0] ) + queryString.Key.Substring( 1 );
                        fieldCriteria.FieldValues.Add( new FieldValue { Field = fieldName, Value = value } );
                    }
                }
            }

            if ( parms.Any( p => p.Key == "searchtype" ) )
            {
                switch( parms["searchtype"] )
                {
                    case "exactmatch":
                        {
                            searchType = SearchType.ExactMatch;
                            break;
                        }
                    case "fuzzy":
                        {
                            searchType = SearchType.Fuzzy;
                            break;
                        }
                    case "wildcard":
                        {
                            searchType = SearchType.Wildcard;
                            break;
                        }
                }
            }

            if ( parms.Any( p => p.Key == "criteriasearchtype" ) )
            {
                if (parms["criteriasearchtype"].ToLower() == "and" )
                {
                    fieldCriteria.SearchType = CriteriaSearchType.And;
                }
            }

            if ( parms.Any( p => p.Key == "entities" ) )
            {
                var entities = parms["entities"].Split( ',' );

                foreach(var entity in entities )
                {
                    foreach(var entityType in EntityTypeCache.All() )
                    {
                        if (entityType.FriendlyName?.ToLower() == entity )
                        {
                            entityIds.Add( entityType.Id );
                        }
                    }
                }
            }

            var client = IndexContainer.GetActiveComponent();
            var results = client.Search( query, searchType, entityIds, fieldCriteria, limit, offset );

            context.Scopes.Last()[parms["iterator"]] = results;

            base.Render( context, result );
        }

        /// <summary>
        ///
        /// </summary>
        private class DataRowDrop : Drop
        {
            private readonly DataRow _dataRow;

            public DataRowDrop( DataRow dataRow )
            {
                _dataRow = dataRow;
            }

            public override object BeforeMethod( string method )
            {
                if ( _dataRow.Table.Columns.Contains( method ) )
                {
                    return _dataRow[method];
                }

                return null;
            }
        }
    }
}