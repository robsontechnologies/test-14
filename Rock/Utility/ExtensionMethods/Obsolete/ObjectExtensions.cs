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
using System.Linq;
using System.Reflection;

namespace Rock
{
    /// <summary>
    /// Object and Stream Extensions that don't require any nuget packages
    /// </summary>
    public static partial class ExtensionMethods
    {
        #region Object Extensions

        /// <summary>
        /// Determines whether the specified value is not null.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not null; otherwise, <c>false</c>.
        /// </returns>
        /// https://github.com/aljazsim/defensive-programming-framework-for-net
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsNotNull<T>( T value )
            where T : class
        {
            return value != null;
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        /// https://github.com/aljazsim/defensive-programming-framework-for-net
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static bool IsNull<T>( T value ) where T : class
        {
            return value == null;
        }

        /// <summary>
        /// Gets the property Value of the object's property as specified by propertyPathName.
        /// </summary>
        /// <param name="rootObj">The root obj.</param>
        /// <param name="propertyPathName">Name of the property path.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static object GetPropertyValue( object rootObj, string propertyPathName )
        {
            var propPath = propertyPathName.Split( new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries ).ToList<string>();

            object obj = rootObj;
            Type objType = rootObj.GetType();

            while ( propPath.Any() && obj != null )
            {
                PropertyInfo property = objType.GetProperty( propPath.First() );
                if ( property != null )
                {
                    obj = property.GetValue( obj );
                    objType = property.PropertyType;
                    propPath = propPath.Skip( 1 ).ToList();
                }
                else
                {
                    obj = null;
                }
            }

            return obj;
        }

        /// <summary>
        /// Gets the Property Type of the type's property as specified by propertyPathName.
        /// </summary>
        /// <param name="rootType">Type of the root.</param>
        /// <param name="propertyPathName">Name of the property path.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static Type GetPropertyType( Type rootType, string propertyPathName )
        {
            var propPath = propertyPathName.Split( new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries ).ToList<string>();

            Type objType = rootType;
            string elementName = rootType.Name;

            try
            {
                while ( propPath.Any() )
                {
                    elementName = propPath.First();

                    PropertyInfo property = objType.GetProperty( elementName );
                    if ( property != null )
                    {
                        objType = property.PropertyType;
                        propPath = propPath.Skip( 1 ).ToList();
                    }
                    else
                    {
                        objType = null;
                    }
                }

            }
            catch ( Exception )
            {
                throw new Exception( string.Format( "GetPropertyType failed. Could not resolve element \"{0}\" in path \"{1}.{2}\".", elementName, rootType.Name, propertyPathName ) );
            }

            return objType;
        }

        /// <summary>
        /// Safely ToString() this item, even if it's null.
        /// </summary>
        /// <param name="obj">an object</param>
        /// <returns>The ToString or the empty string if the item is null.</returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ToStringSafe( object obj )
        {
            if ( obj != null )
            {
                return obj.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns a string representation of the object or a default value.
        /// </summary>
        /// <param name="obj">an object</param>
        /// <param name="defaultValue"></param>
        /// <returns>A string representation of the object, or the default value if the representation is null or whitespace.</returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static string ToStringOrDefault( object obj, string defaultValue )
        {
            if ( obj != null )
            {
                var stringValue = obj.ToString();

                if ( !string.IsNullOrWhiteSpace( stringValue ) )
                {
                    return stringValue;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the data annotation attribute from. http://stackoverflow.com/questions/7027613/how-to-retrieve-data-annotations-from-code-programmatically
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static T GetAttributeFrom<T>( object instance, string propertyName ) where T : System.Attribute
        {
            var attrType = typeof( T );
            var property = instance.GetType().GetProperty( propertyName );
            return ( T ) property.GetCustomAttributes( attrType, false ).First();
        }

        #endregion

        #region Stream extension methods

        /// <summary>
        /// Reads entire stream and converts to byte array.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        [RockObsolete( "1.13" )]
        [Obsolete( "Use the extension methods in the Rock.Common assembly instead." )]
        public static byte[] ReadBytesToEnd( System.IO.Stream stream )
        {
            long originalPosition = 0;

            if ( stream.CanSeek )
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ( ( bytesRead = stream.Read( readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead ) ) > 0 )
                {
                    totalBytesRead += bytesRead;

                    if ( totalBytesRead == readBuffer.Length )
                    {
                        int nextByte = stream.ReadByte();
                        if ( nextByte != -1 )
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy( readBuffer, 0, temp, 0, readBuffer.Length );
                            Buffer.SetByte( temp, totalBytesRead, ( byte ) nextByte );
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if ( readBuffer.Length != totalBytesRead )
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy( readBuffer, 0, buffer, 0, totalBytesRead );
                }
                return buffer;
            }
            finally
            {
                if ( stream.CanSeek )
                {
                    stream.Position = originalPosition;
                }
            }
        }

        #endregion Stream extension methods
    }
}
