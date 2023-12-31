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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/*
 * 2020-11-16 ETD
 * IMPORTANT!
 * This class is used by the CheckScanner which does not have the Rock dll. This file cannot contain any dependencies on that assembly or NuGet packages.
 */

namespace Rock
{
    /// <summary>
    /// Handy string extensions that don't require any NuGet packages or Rock references
    /// </summary>
    public static partial class ExtensionMethods
    {
        #region String Extensions

        /// <summary>
        /// Converts string to MD5 hash
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Md5Hash( string str )
        {
            using ( var crypt = MD5.Create() )
            {
                var hash = crypt.ComputeHash( Encoding.UTF8.GetBytes( str ) );

                StringBuilder sb = new StringBuilder();
                foreach ( byte b in hash )
                {
                    // Can be "x2" if you want lowercase
                    sb.Append( b.ToString( "x2" ) );
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Converts string to Sha1 hash
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Sha1Hash( string str )
        {
            using ( var crypt = new SHA1Managed() )
            {
                var hash = crypt.ComputeHash( Encoding.UTF8.GetBytes( str ) );
                var sb = new StringBuilder( hash.Length * 2 );

                foreach ( byte b in hash )
                {
                    // Can be "x2" if you want lowercase
                    sb.Append( b.ToString( "x2" ) );
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Converts string to Sha256 hash
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Sha256Hash( string str )
        {
            using ( var crypt = new System.Security.Cryptography.SHA256Managed() )
            {
                var hash = crypt.ComputeHash( Encoding.UTF8.GetBytes( str ) );
                var sb = new StringBuilder();

                foreach ( byte b in hash )
                {
                    // Can be "x2" if you want lowercase
                    sb.Append( b.ToString( "x2" ) );
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Converts string to HMAC_SHA1 string using key
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="keyString">The key.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string HmacSha1Hash( string str, string keyString )
        {
            var key = Encoding.ASCII.GetBytes( keyString );

            using ( var crypt = new HMACSHA1( key ) )
            {
                var hash = crypt.ComputeHash( Encoding.ASCII.GetBytes( str ) );

                // Can be "x2" if you want lowercase
                return hash.Aggregate( "", ( s, e ) => s + String.Format( "{0:x2}", e ), s => s );
            }
        }

        /// <summary>
        /// Converts string to HMAC_SHA256 string using key
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="keyString">The key string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string HmacSha256Hash( string str, string keyString )
        {
            var key = Encoding.ASCII.GetBytes( keyString );

            using ( var crypt = new HMACSHA256( key ) )
            {
                var hash = crypt.ComputeHash( Encoding.ASCII.GetBytes( str ) );

                // Can be "x2" if you want lowercase
                return hash.Aggregate( "", ( s, e ) => s + String.Format( "{0:x2}", e ), s => s );
            }
        }

        /// <summary>
        /// Reads the parameter to check for DOM objects and possible URLs
        /// Accepts an encoded string and returns an encoded string
        /// </summary>
        /// <param name="encodedString"></param>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ScrubEncodedStringForXSSObjects( string encodedString )
        {
            // Characters used by DOM Objects; javascript, document, window and URLs
            char[] badCharacters = new char[] { '<', '>', ':', '*' };

            var decodedString = encodedString.GetFullyUrlDecodedValue();

            if ( decodedString.IndexOfAny( badCharacters ) >= 0 )
            {
                return "%2f";
            }
            else
            {
                return encodedString;
            }
        }

        /// <summary>
        /// Joins and array of strings using the provided separator.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>Concatencated string.</returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string JoinStrings( IEnumerable<string> source, string separator )
        {
            return string.Join( separator, source.ToArray() );
        }

        /// <summary>
        /// Joins an array of English strings together with commas plus "and" for last element.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Concatenated string.</returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string JoinStringsWithCommaAnd( IEnumerable<String> source )
        {
            if ( source == null || source.Count() == 0 )
            {
                return string.Empty;
            }

            var output = string.Empty;

            var list = source.ToList();

            if ( list.Count > 1 )
            {
                var delimited = string.Join( ", ", list.Take( list.Count - 1 ) );

                output = string.Concat( delimited, " and ", list.LastOrDefault() );
            }
            else
            {
                // only one element, just use it
                output = list[0];
            }

            return output;
        }

        /// <summary>
        /// Removes special characters from the string so that only Alpha, Numeric, '.' and '_' remain;
        /// </summary>
        /// <param name="str">The identifier.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveSpecialCharacters( string str )
        {
            StringBuilder sb = new StringBuilder();
            foreach ( char c in str )
            {
                if ( ( c >= '0' && c <= '9' ) || ( c >= 'A' && c <= 'Z' ) || ( c >= 'a' && c <= 'z' ) || c == '.' || c == '_' )
                {
                    sb.Append( c );
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Replaces the special characters from the string with the supplied string so that only alpha-numeric, '.', and '_' remain.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="replacementCharacters">The characters to replace special character(s) with. No restrictions or validation.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ReplaceSpecialCharacters( string str, string replacementCharacters )
        {
            StringBuilder sb = new StringBuilder();
            foreach ( char c in str )
            {
                if ( ( c >= '0' && c <= '9' ) || ( c >= 'A' && c <= 'Z' ) || ( c >= 'a' && c <= 'z' ) || c == '.' || c == '_' )
                {
                    sb.Append( c );
                }
                else
                {
                    sb.Append( replacementCharacters );
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Removes all non alpha numeric characters from a string
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveAllNonAlphaNumericCharacters( string str )
        {
            return string.Concat( str.Where( c => char.IsLetterOrDigit( c ) ) );
        }

        /// <summary>
        /// Removes all non numeric characters.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveAllNonNumericCharacters( string str )
        {
            Regex digitsOnly = new Regex( @"[^\d]" );

            if ( !string.IsNullOrEmpty( str ) )
            {
                return digitsOnly.Replace( str, string.Empty );
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether the string is not null or whitespace.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsNotNullOrWhiteSpace( string str )
        {
            return !string.IsNullOrWhiteSpace( str );
        }

        /// <summary>
        /// Determines whether [is null or white space].
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsNullOrWhiteSpace( string str )
        {
            return string.IsNullOrWhiteSpace( str );
        }

        /// <summary>
        /// Returns the right most part of a string of the given length.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Right( string str, int length )
        {
            if ( str == null )
            {
                return string.Empty;
            }

            return str.Substring( str.Length - length );
        }

        /// <summary>
        /// Strips HTML from the string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string StripHtml( string str )
        {
            return str.IsNullOrWhiteSpace()
                ? str
                : Regex.Replace( str, @"<.*?>|<!--(.|\r|\n)*?-->", string.Empty );
        }

        /// <summary>
        /// Determines whether the string is made up of only digits
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsDigitsOnly( string str )
        {
            foreach ( char c in str )
            {
                if ( c < '0' || c > '9' )
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the number of words in the string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static int WordCount( string str )
        {
            // Attribution (aka future blame): https://stackoverflow.com/questions/8784517/counting-number-of-words-in-c-sharp
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            return str.Split( delimiters, StringSplitOptions.RemoveEmptyEntries ).Length;
        }

        /// <summary>
        /// Determines whether the string is valid mac address.
        /// Works with colons, dashes, or no seperators
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///   <c>true</c> if valid mac address otherwise, <c>false</c>.
        /// </returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsValidMacAddress( string str )
        {
            Regex regex = new Regex( "^([0-9a-fA-F]{2}(?:[:-]?[0-9a-fA-F]{2}){5})$" );
            return regex.IsMatch( str );
        }

        /// <summary>
        /// Determines whether the string is a valid http(s) URL
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///   <c>true</c> if [is valid URL] [the specified string]; otherwise, <c>false</c>.
        /// </returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsValidUrl( string str )
        {
            Uri uriResult;
            return Uri.TryCreate( str, UriKind.Absolute, out uriResult )
                && ( uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps );
        }

        /// <summary>
        /// Removes invalid, reserved, and unreccommended characters from strings that will be used in URLs.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveInvalidReservedUrlChars( string str )
        {
            return str.Replace( " ", string.Empty )
                .Replace( ";", string.Empty )
                .Replace( "/", string.Empty )
                .Replace( "?", string.Empty )
                .Replace( ":", string.Empty )
                .Replace( "@", string.Empty )
                .Replace( "=", string.Empty )
                .Replace( "&", string.Empty )
                .Replace( "<", string.Empty )
                .Replace( ">", string.Empty )
                .Replace( "#", string.Empty )
                .Replace( "%", string.Empty )
                .Replace( "\"", string.Empty )
                .Replace( "{", string.Empty )
                .Replace( "}", string.Empty )
                .Replace( "|", string.Empty )
                .Replace( "\\", string.Empty )
                .Replace( "^", string.Empty )
                .Replace( "[", string.Empty )
                .Replace( "]", string.Empty )
                .Replace( "`", string.Empty )
                .Replace( "'", string.Empty );
        }

        /// <summary>
        /// Converts a comma delimited string into a List&lt;int&gt;
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static IEnumerable<int> StringToIntList( string str )
        {
            // https://stackoverflow.com/questions/1763613/convert-comma-separated-string-of-ints-to-int-array

            if ( String.IsNullOrEmpty( str ) )
            {
                yield break;
            }

            foreach ( var s in str.Split( ',' ) )
            {
                int num;
                if ( int.TryParse( s, out num ) )
                {
                    yield return num;
                }
            }
        }

        /// <summary>
        /// Makes the Int64 hash code from the provided string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static long MakeInt64HashCode( string str )
        {
            // http://www.codeproject.com/Articles/34309/Convert-String-to-64bit-Integer
            long hashCode = 0;
            if ( !string.IsNullOrEmpty( str ) )
            {
                // Unicode Encode Covering all characterset
                byte[] byteContents = Encoding.Unicode.GetBytes( str );
                System.Security.Cryptography.SHA256 hash =
                new System.Security.Cryptography.SHA256CryptoServiceProvider();
                byte[] hashText = hash.ComputeHash( byteContents );

                long hashCodeStart = BitConverter.ToInt64( hashText, 0 );
                long hashCodeMedium = BitConverter.ToInt64( hashText, 8 );
                long hashCodeEnd = BitConverter.ToInt64( hashText, 24 );
                hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
            }

            return hashCode;
        }

        /// <summary>
        /// removes any invalid FileName chars in a filename
        /// from http://stackoverflow.com/a/14836763/1755417
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string MakeValidFileName( string name )
        {
            string invalidChars = Regex.Escape( new string( System.IO.Path.GetInvalidFileNameChars() ) );
            string invalidReStr = string.Format( @"[{0}]+", invalidChars );
            string replace = Regex.Replace( name, invalidReStr, "_" ).Replace( ";", string.Empty ).Replace( ",", string.Empty );
            return replace;
        }

        /// <summary>
        /// Splits a Camel or Pascal cased identifier into separate words.
        /// </summary>
        /// <param name="str">The identifier.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string SplitCase( string str )
        {
            if ( str == null )
            {
                return null;
            }

            return Regex.Replace( Regex.Replace( str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2" ), @"(\p{Ll})(\P{Ll})", "$1 $2" );
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by any combination of whitespace, comma, semi-colon, or pipe characters.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="whitespace">if set to <c>true</c> whitespace will be treated as a delimiter</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string[] SplitDelimitedValues( string str, bool whitespace = true )
        {
            if ( str == null )
            {
                return new string[0];
            }

            string regex = whitespace ? @"[\s\|,;]+" : @"[\|,;]+";

            char[] delimiter = new char[] { ',' };
            return Regex.Replace( str, regex, "," ).Split( delimiter, StringSplitOptions.RemoveEmptyEntries );
        }

        /// <summary>
        /// Returns an array that contains substrings of the target string that are separated by the specified delimiter.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="delimiter">The delimiter string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string[] SplitDelimitedValues( string str, string delimiter )
        {
            return SplitDelimitedValues( str, delimiter, StringSplitOptions.None );
        }

        /// <summary>
        /// Returns an array that contains substrings of the target string that are separated by the specified delimiter.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="delimiter">The delimiter string.</param>
        /// <param name="options">The split options.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string[] SplitDelimitedValues( string str, string delimiter, StringSplitOptions options )
        {
            if ( str == null )
            {
                return new string[0];
            }

            // Replace the custom delimiter string with a single unprintable character that will not appear in the target string, then use the default string split function.
            var newDelimiter = new char[] { '\x0001' };

            var replaceString = str.Replace( delimiter, new string( newDelimiter ) )
                                   .Split( newDelimiter, options );

            return replaceString;
        }

        /// <summary>
        /// Replaces every instance of oldValue (regardless of case) with the newValue.
        /// (from http://www.codeproject.com/Articles/10890/Fastest-C-Case-Insenstive-String-Replace)
        /// </summary>
        /// <param name="str">The source string.</param>
        /// <param name="oldValue">The value to replace.</param>
        /// <param name="newValue">The value to insert.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ReplaceCaseInsensitive( string str, string oldValue, string newValue )
        {
            if ( str == null )
            {
                return null;
            }

            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = str.ToUpper();
            string upperPattern = oldValue.ToUpper();
            int inc = ( str.Length / oldValue.Length ) *
                      ( newValue.Length - oldValue.Length );
            char[] chars = new char[str.Length + Math.Max( 0, inc )];
            while ( ( position1 = upperString.IndexOf( upperPattern, position0 ) ) != -1 )
            {
                for ( int i = position0; i < position1; ++i )
                {
                    chars[count++] = str[i];
                }

                for ( int i = 0; i < newValue.Length; ++i )
                {
                    chars[count++] = newValue[i];
                }

                position0 = position1 + oldValue.Length;
            }

            if ( position0 == 0 )
            {
                return str;
            }

            for ( int i = position0; i < str.Length; ++i )
            {
                chars[count++] = str[i];
            }

            return new string( chars, 0, count );
        }

        /// <summary>
        /// Replaces every instance of oldValue with newValue.  Will continue to replace
        /// values after each replace until the oldValue does not exist.
        /// </summary>
        /// <param name="str">The source string.</param>
        /// <param name="oldValue">The value to replace.</param>
        /// <param name="newValue">The value to insert.</param>
        /// <returns>System.String.</returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ReplaceWhileExists( string str, string oldValue, string newValue )
        {
            string newstr = str;

            if ( oldValue != newValue )
            {
                while ( newstr.Contains( oldValue ) )
                {
                    newstr = newstr.Replace( oldValue, newValue );
                }
            }

            return newstr;
        }

        /// <summary>
        /// Adds escape character for quotes in a string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string EscapeQuotes( string str )
        {
            if ( str == null )
            {
                return null;
            }

            return str.Replace( "'", "\\'" ).Replace( "\"", "\\\"" );
        }

        /// <summary>
        /// Standardize quotes in a string. It replaces curly single quotes into the standard single quote character (ASCII 39).
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string StandardizeQuotes( string str )
        {
            if ( str == null )
            {
                return null;
            }

            return str.Replace( "’", "'" );
        }

        /// <summary>
        /// Adds Quotes around the specified string and escapes any quotes that are already in the string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="quoteChar">The quote character.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Quoted( string str, string quoteChar = "'" )
        {
            var result = quoteChar + str.EscapeQuotes() + quoteChar;
            return result;
        }

        /// <summary>
        /// Returns the specified number of characters, starting at the left side of the string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The desired length.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Left( string str, int length )
        {
            if ( str == null )
            {
                return null;
            }
            else if ( str.Length <= length )
            {
                return str;
            }
            else
            {
                return str.Substring( 0, length );
            }
        }

        /// <summary>
        /// Truncates from char 0 to the length and then add an ellipsis character char 8230.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string LeftWithEllipsis( string str, int length )
        {
            if ( str.Length <= length )
            {
                return str;
            }

            return Left( str, length ) + ( char ) 8230;
        }

        /// <summary>
        /// Returns a substring of a string. Uses an empty string for any part that doesn't exist and will return a partial substring if the string isn't long enough for the requested length (the built-in method would throw an exception in these cases).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="startIndex">The 0-based starting position.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns></returns>
        [Obsolete( "Use SubstringSafe() instead. Obsolete as of 1.12.0" )]
        [RockObsolete("1.12")]
        public static string SafeSubstring( string str, int startIndex, int maxLength )
        {
            return str.SubstringSafe( startIndex, maxLength );
        }

        /// <summary>
        /// Returns a substring of a string. Uses an empty string for any part that doesn't exist and will return a partial substring if the string isn't long enough for the requested length (the built-in method would throw an exception in these cases).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="startIndex">The 0-based starting position.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string SubstringSafe( string str, int startIndex, int maxLength )
        {
            if ( str == null || maxLength < 0 || startIndex < 0 || startIndex > str.Length )
            {
                return string.Empty;
            }

            return str.Substring( startIndex, Math.Min( maxLength, str.Length - startIndex ) );
        }

        /// <summary>
        /// Returns a substring of a string. Uses an empty string for any part that doesn't exist and will return a partial substring if the string isn't long enough for the requested length (the built-in method would throw an exception in these cases).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="startIndex">The 0-based starting position.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string SubstringSafe( string str, int startIndex )
        {
            if ( str == null )
            {
                return string.Empty;
            }

            return str.SubstringSafe( startIndex, Math.Max( str.Length - startIndex, 0 ) );
        }

        /// <summary>
        /// Truncates a string after a max length and adds ellipsis.  Truncation will occur at first space prior to maxLength.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Truncate( string str, int maxLength )
        {
            return Truncate( str, maxLength, true );
        }

        /// <summary>
        /// Truncates a string after a max length with an option to add an ellipsis at the end.  Truncation will occur at first space prior to maxLength.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="maxLength">The maximum length of the return value, including the ellipsis if added.</param>
        /// <param name="addEllipsis">if set to <c>true</c> add an ellipsis to the end of the truncated string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Truncate( string str, int maxLength, bool addEllipsis )
        {
            if ( str == null )
            {
                return null;
            }

            if ( str.Length <= maxLength )
            {
                return str;
            }

            // If adding an ellipsis then reduce the maxlength by three to allow for the additional characters
            maxLength = addEllipsis ? maxLength - 3 : maxLength;

            var truncatedString = str.Substring( 0, maxLength );
            var lastSpace = truncatedString.LastIndexOf( ' ' );
            if ( lastSpace > 0 )
            {
                truncatedString = truncatedString.Substring( 0, lastSpace );
            }

            return addEllipsis ? truncatedString + "..." : truncatedString;
        }

        /// <summary>
        /// Removes any non-numeric characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string AsNumeric( string str )
        {
            return Regex.Replace( str, @"[^0-9]", string.Empty );
        }

        /// <summary>
        /// Replaces the last occurrence of a given string with a new value
        /// </summary>
        /// <param name="source">The string.</param>
        /// <param name="find">The search parameter.</param>
        /// <param name="replace">The replacement parameter.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ReplaceLastOccurrence( string source, string find, string replace )
        {
            int place = source.LastIndexOf( find );
            return place > 0 ? source.Remove( place, find.Length ).Insert( place, replace ) : source;
        }

        /// <summary>
        /// Replaces string found at the very end of the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="replacement">The replacement.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ReplaceIfEndsWith( string content, string suffix, string replacement )
        {
            if ( content.EndsWith( suffix ) )
            {
                return content.Substring( 0, content.Length - suffix.Length ) + replacement;
            }
            else
            {
                return content;
            }
        }

        /// <summary>
        /// The true strings for AsBoolean and AsBooleanOrNull.
        /// </summary>
        private static string[] trueStrings = new string[] { "true", "yes", "t", "y", "1" };

        /// <summary>
        /// Returns True for 'True', 'Yes', 'T', 'Y', '1' (case-insensitive).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="resultIfNullOrEmpty">if set to <c>true</c> [result if null or empty].</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool AsBoolean( string str, bool resultIfNullOrEmpty = false )
        {
            if ( string.IsNullOrWhiteSpace( str ) )
            {
                return resultIfNullOrEmpty;
            }

            return trueStrings.Contains( str.ToLower() );
        }

        /// <summary>
        /// Returns True for 'True', 'Yes', 'T', 'Y', '1' (case-insensitive), null for emptystring/null.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool? AsBooleanOrNull( string str )
        {
            string[] trueStrings = new string[] { "true", "yes", "t", "y", "1" };

            if ( string.IsNullOrWhiteSpace( str ) )
            {
                return null;
            }

            return trueStrings.Contains( str.ToLower() );
        }

        /// <summary>
        /// Attempts to convert string to integer.  Returns 0 if unsuccessful.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static int AsInteger( string str )
        {
            return str.AsIntegerOrNull() ?? 0;
        }

        /// <summary>
        /// Attempts to convert string to an integer.  Returns null if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static int? AsIntegerOrNull( string str )
        {
            int value;
            if ( int.TryParse( str, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to convert string to Guid.  Returns Guid.Empty if unsuccessful.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static Guid AsGuid( string str )
        {
            return str.AsGuidOrNull() ?? Guid.Empty;
        }

        /// <summary>
        /// Attempts to convert string to Guid.  Returns null if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static Guid? AsGuidOrNull( string str )
        {
            Guid value;
            if ( Guid.TryParse( str, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether the specified unique identifier is Guid.Empty.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsEmpty( Guid guid )
        {
            return guid.Equals( Guid.Empty );
        }

        /// <summary>
        /// Attempts to convert string to decimal.  Returns 0 if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static decimal AsDecimal( string str )
        {
            return str.AsDecimalOrNull() ?? 0;
        }

        /// <summary>
        /// Attempts to convert string to decimal. Returns null if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static decimal? AsDecimalOrNull( string str )
        {
            if ( !string.IsNullOrWhiteSpace( str ) )
            {
                // strip off non numeric and characters at the beginning of the line (currency symbols)
                str = Regex.Replace( str, @"^[^0-9\.-]", string.Empty );
            }

            decimal value;
            if ( decimal.TryParse( str, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to convert string to decimal with invariant culture. Returns null if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static decimal? AsDecimalInvariantCultureOrNull( string str )
        {
            if ( !string.IsNullOrWhiteSpace( str ) )
            {
                // strip off non numeric and characters at the beginning of the line (currency symbols)
                str = Regex.Replace( str, @"^[^0-9\.-]", string.Empty );
            }

            decimal value;
            if ( decimal.TryParse( str, NumberStyles.Number, CultureInfo.InvariantCulture, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to convert string to double.  Returns 0 if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static double AsDouble( string str )
        {
            return str.AsDoubleOrNull() ?? 0;
        }

        /// <summary>
        /// Attempts to convert string to double.  Returns null if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static double? AsDoubleOrNull( string str )
        {
            if ( !string.IsNullOrWhiteSpace( str ) )
            {
                // strip off non numeric and characters at the beginning of the line (currency symbols)
                str = Regex.Replace( str, @"^[^0-9\.-]", string.Empty );
            }

            double value;
            if ( double.TryParse( str, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to convert string to TimeSpan.  Returns null if unsuccessful.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static TimeSpan? AsTimeSpan( string str )
        {
            TimeSpan value;
            if ( TimeSpan.TryParse( str, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Converts the value to Type, or if unsuccessful, returns the default value of Type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static T AsType<T>( string value )
        {
            var converter = TypeDescriptor.GetConverter( typeof( T ) );
            return converter.IsValid( value )
                ? ( T ) converter.ConvertFrom( value )
                : default( T );
        }

        /// <summary>
        /// Masks the specified value if greater than 4 characters (such as a credit card number) showing only the last 4 chars prefixed with 12*s
        /// For example, the return string becomes "************6789".
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Masked( string value )
        {
            return value.Masked( false );
        }

        /// <summary>
        /// Masks the specified value if greater than 4 characters (such as a credit card number) showing only the last 4 chars and replacing the preceeding chars with *
        /// For example, the return string becomes "************6789".
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="preserveLength">if set to <c>true</c> [preserve length]. If false, always put 12 *'s as the prefix</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string Masked( string value, bool preserveLength )
        {
            if ( value != null && value.Length > 4 )
            {
                int maskedLength = preserveLength ? value.Length - 4 : 12;
                return string.Concat( new string( '*', maskedLength ), value.Substring( value.Length - 4 ) );
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Ensures the trailing backslash. Handy when combining folder paths.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string EnsureTrailingBackslash( string value )
        {
            return value.TrimEnd( new char[] { '\\', '/' } ) + "\\";
        }

        /// <summary>
        /// Ensures the trailing forward slash. Handy when combining url paths.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string EnsureTrailingForwardslash( string value )
        {
            return value.TrimEnd( new char[] { '\\', '/' } ) + "/";
        }

        /// <summary>
        /// Ensures the leading forward slash. Handy when combining url paths.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveLeadingForwardslash( string value )
        {
            return value.TrimStart( new char[] { '/' } );
        }

        /// <summary>
        /// Evaluates string, and if null or empty, returns nullValue instead.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="nullValue">The null value.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string IfEmpty( string value, string nullValue )
        {
            return !string.IsNullOrWhiteSpace( value ) ? value : nullValue;
        }

        /// <summary>
        /// Replaces special Microsoft Word chars with standard chars
        /// For example, smart quotes will be replaced with apostrophes
        /// from http://www.andornot.com/blog/post/Replace-MS-Word-special-characters-in-javascript-and-C.aspx
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ReplaceWordChars( string text )
        {
            var s = text;

            // smart single quotes and apostrophe
            s = Regex.Replace( s, "[\u2018\u2019\u201A]", "'" );

            // smart double quotes
            s = Regex.Replace( s, "[\u201C\u201D\u201E]", "\"" );

            // ellipsis
            s = Regex.Replace( s, "\u2026", "..." );

            // dashes
            s = Regex.Replace( s, "[\u2013\u2014]", "-" );

            // circumflex
            s = Regex.Replace( s, "\u02C6", "^" );

            // open angle bracket
            s = Regex.Replace( s, "\u2039", "<" );

            // close angle bracket
            s = Regex.Replace( s, "\u203A", ">" );

            // spaces
            s = Regex.Replace( s, "[\u02DC\u00A0]", " " );

            return s;
        }

        /// <summary>
        /// Returns a list of KeyValuePairs from a serialized list of Rock KeyValuePairs (e.g. 'Item1^Value1|Item2^Value2')
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static List<KeyValuePair<string, object>> ToKeyValuePairList( string input )
        {
            List<KeyValuePair<string, object>> keyPairs = new List<KeyValuePair<string, object>>();

            if ( !string.IsNullOrWhiteSpace( input ) )
            {
                var items = input.Split( '|' );

                foreach ( var item in items )
                {
                    var parts = item.Split( '^' );
                    if ( parts.Length == 2 )
                    {
                        keyPairs.Add( new KeyValuePair<string, object>( parts[0], parts[1] ) );
                    }
                }
            }

            return keyPairs;
        }

        /// <summary>
        /// Removes the spaces.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveSpaces( string input )
        {
            return input.Replace( " ", string.Empty );
        }

        /// <summary>
        /// Removes all whitespace in a string, including carriage return and line feed characters.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveWhiteSpace( string input )
        {
            return string.Concat( input.Where( c => !char.IsWhiteSpace( c ) ) );
        }

        /// <summary>
        /// Breaks a string into chunks. Handy for splitting a large string into smaller chunks
        /// from https://stackoverflow.com/a/1450889/1755417
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="maxChunkSize">Maximum size of the chunk.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static IEnumerable<string> SplitIntoChunks( string str, int maxChunkSize )
        {
            for ( int i = 0; i < str.Length; i += maxChunkSize )
            {
                yield return str.Substring( i, Math.Min( maxChunkSize, str.Length - i ) );
            }
        }

        /// <summary>
        /// Removes any carriage return and/or line feed characters.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string RemoveCrLf( string str )
        {
            return str.Replace( Environment.NewLine, " " ).Replace( "\x0A", " " );
        }

        /// <summary>
        /// Writes a string to a new memorystream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static System.IO.MemoryStream ToMemoryStream( string str )
        {
            var stream = new System.IO.MemoryStream();
            var writer = new System.IO.StreamWriter( stream );
            writer.Write( str );
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Creates a StreamReader with the string data
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static System.IO.StreamReader ToStreamReader( string str )
        {
            var stream = new System.IO.MemoryStream();
            var writer = new System.IO.StreamWriter( stream );
            writer.Write( str );
            writer.Flush();
            stream.Position = 0;
            return new System.IO.StreamReader( stream );
        }

        /// <summary>
        /// A string extension method that escape XML.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>A string.</returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string EscapeXml( string str )
        {
            return str.Replace( "&", "&amp;" ).Replace( "<", "&lt;" ).Replace( ">", "&gt;" ).Replace( "\"", "&quot;" ).Replace( "'", "&apos;" );
        }

        #endregion String Extensions
    }
}
