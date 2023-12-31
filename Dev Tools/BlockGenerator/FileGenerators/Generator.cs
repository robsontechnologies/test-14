﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

using BlockGenerator.Utility;

using Rock;

namespace BlockGenerator.FileGenerators
{
    public abstract class Generator
    {
        private const string _codeGenComment = @"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
";

        private const string _copyrightComment = @"// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the ""License"");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an ""AS IS"" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//

";

        protected string GetCodeGenComment()
        {
            return _codeGenComment;
        }

        protected string GetCopyrightComment()
        {
            return _copyrightComment;
        }

        protected string GenerateCSharpFile( IList<string> usings, string namespaceName, string body, bool isAutoGen = true )
        {
            var sb = new StringBuilder();

            if ( isAutoGen )
            {
                sb.Append( GetCodeGenComment() );
            }

            sb.Append( GetCopyrightComment() );

            sb.Append( GenerateCSharpUsings( usings ) );

            sb.AppendLine( $"namespace {namespaceName}" );
            sb.AppendLine( "{" );
            sb.AppendLine( body.Trim( '\r', '\n' ) );
            sb.AppendLine( "}" );

            return sb.ToString();
        }

        protected string GenerateCSharpUsings( IList<string> usings )
        {
            var sb = new StringBuilder();

            var domainUsings = usings
                .Distinct()
                .Select( u => new
                {
                    Domain = u.Split( '.' )[0],
                    FullName = u
                } )
                .ToList();

            var usingGroups = domainUsings.GroupBy( u => u.Domain )
                .OrderByDescending( g => g.Key == "System" )
                .ThenBy( g => g.Key )
                .ToList();

            foreach ( var usingGroup in usingGroups )
            {
                foreach ( var u in usingGroup )
                {
                    sb.AppendLine( $"using {u.FullName};" );
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        protected string GenerateTypeScriptFile( IList<TypeScriptImport> imports, string body, bool isAutoGen = true )
        {
            var sb = new StringBuilder();

            if ( isAutoGen )
            {
                sb.Append( GetCodeGenComment() );
            }

            sb.Append( GetCopyrightComment() );

            sb.Append( GenerateTypeScriptImports( imports ) );

            sb.AppendLine( body.Trim( '\r', '\n' ) );

            return sb.ToString();
        }

        protected string GenerateTypeScriptImports( IList<TypeScriptImport> imports )
        {
            var sb = new StringBuilder();

            var importGroups = imports.GroupBy( i => i.SourcePath )
                .OrderBy( g => g.Key.StartsWith( ".." ) )
                .ThenBy( g => g.Key )
                .ToList();

            foreach ( var importGroup in importGroups )
            {
                sb.Append( "import " );

                var defaultImport = importGroup.FirstOrDefault( i => !string.IsNullOrWhiteSpace( i.DefaultImport ) );

                if ( defaultImport != null )
                {
                    sb.Append( $"{defaultImport}" );
                }

                var namedImports = importGroup
                    .Where( i => !string.IsNullOrWhiteSpace( i.NamedImport ) )
                    .Select( i => i.NamedImport )
                    .Distinct()
                    .OrderBy( i => i )
                    .ToList();

                if ( namedImports.Any() )
                {
                    if ( defaultImport != null )
                    {
                        sb.Append( ", " );
                    }

                    sb.Append( "{ " );
                    sb.Append( string.Join( ", ", namedImports ) );
                    sb.Append( " }" );
                }

                sb.AppendLine( $" from \"{importGroup.Key}\";" );
            }

            if ( sb.Length > 0 )
            {
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
