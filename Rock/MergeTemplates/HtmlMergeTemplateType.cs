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
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Web;
using HtmlAgilityPack;

using Rock.Data;
using Rock.Model;

namespace Rock.MergeTemplates
{
    /// <summary>
    /// 
    /// </summary>
    [System.ComponentModel.Description( "An HTML Document merge template" )]
    [Export( typeof( MergeTemplateType ) )]
    [ExportMetadata( "ComponentName", "HTML Document" )]
    [Rock.SystemGuid.EntityTypeGuid( "5FBFF041-9EDC-41A3-8A92-D7AC4FF88221")]
    public class HtmlMergeTemplateType : MergeTemplateType
    {
        /// <summary>
        /// Gets the supported file extensions
        /// Returns NULL if the file extension doesn't matter or doesn't apply
        /// Rock will use this to warn the user if the file extension isn't supported
        /// </summary>
        /// <value>
        /// The supported file extensions.
        /// </value>
        public override IEnumerable<string> SupportedFileExtensions
        {
            get
            {
                return new string[] { "htm", "html" };
            }
        }
        
        /// <summary>
        /// Creates the document.
        /// </summary>
        /// <param name="mergeTemplate">The merge template.</param>
        /// <param name="mergeObjectList">The merge object list.</param>
        /// <param name="globalMergeFields">The global merge fields.</param>
        /// <returns></returns>
        public override BinaryFile CreateDocument( MergeTemplate mergeTemplate, List<object> mergeObjectList, Dictionary<string, object> globalMergeFields )
        {
            this.Exceptions = new List<Exception>();
            BinaryFile outputBinaryFile = null;

            var rockContext = new RockContext();
            var binaryFileService = new BinaryFileService( rockContext );

            var templateBinaryFile = binaryFileService.Get( mergeTemplate.TemplateBinaryFileId );
            if ( templateBinaryFile == null )
            {
                return null;
            }

            string templateHtml = templateBinaryFile.ContentsToString();
            var htmlMergeObjects = GetHtmlMergeObjects( mergeObjectList, globalMergeFields );
            string outputHtml = templateHtml.ResolveMergeFields( htmlMergeObjects );
            HtmlDocument outputDoc = new HtmlDocument();
            outputDoc.LoadHtml( outputHtml );
            var outputStream = new MemoryStream();
            outputDoc.Save( outputStream );

            outputBinaryFile = new BinaryFile();
            outputBinaryFile.IsTemporary = true;
            outputBinaryFile.ContentStream = outputStream;
            outputBinaryFile.FileName = "MergeTemplateOutput" + Path.GetExtension( templateBinaryFile.FileName );
            outputBinaryFile.MimeType = templateBinaryFile.MimeType;
            outputBinaryFile.BinaryFileTypeId = new BinaryFileTypeService( rockContext ).Get( Rock.SystemGuid.BinaryFiletype.DEFAULT.AsGuid() ).Id;

            binaryFileService.Add( outputBinaryFile );
            rockContext.SaveChanges();

            return outputBinaryFile;
        }

        /// <summary>
        /// Gets the HTML merge objects.
        /// </summary>
        /// <param name="mergeObjectList">The merge object list.</param>
        /// <param name="globalMergeFields">The global merge fields.</param>
        /// <returns></returns>
        private static Dictionary<string, object> GetHtmlMergeObjects( List<object> mergeObjectList, Dictionary<string, object> globalMergeFields )
        {
            var htmlMergeObjects = new Dictionary<string, object>();
            htmlMergeObjects.Add( "Rows", mergeObjectList );
            
            foreach (var mergeField in globalMergeFields)
            {
                htmlMergeObjects.Add( mergeField.Key, mergeField.Value );
            }
            
            return htmlMergeObjects;
        }

        /// <summary>
        /// Gets the lava debug information.
        /// </summary>
        /// <param name="mergeObjectList">The merge object list.</param>
        /// <param name="globalMergeFields">The global merge fields.</param>
        /// <returns></returns>
        public override string GetLavaDebugInfo( List<object> mergeObjectList, Dictionary<string, object> globalMergeFields )
        {
            return GetHtmlMergeObjects( mergeObjectList, globalMergeFields ).lavaDebugInfo();
        }

        /// <summary>
        /// Gets or sets the exceptions.
        /// </summary>
        /// <value>
        /// The exceptions.
        /// </value>
        public override List<Exception> Exceptions
        {
            get
            {
                if ( HttpContext.Current != null )
                {
                    return HttpContext.Current.Items[$"{this.GetType().FullName}:Exceptions"] as List<Exception>;
                }

                return _nonHttpContextExceptions;
            }

            set
            {
                if ( HttpContext.Current != null )
                {
                    HttpContext.Current.Items[$"{this.GetType().FullName}:Exceptions"] = value;
                }
                else
                {
                    _nonHttpContextExceptions = value;
                }
            }
        }

        /// <summary>
        /// Thread safe storage of property when HttpContext.Current is null
        /// NOTE: ThreadStatic is per thread, but ASP.NET threads are ThreadPool threads, so they will be used again.
        /// see https://www.hanselman.com/blog/ATaleOfTwoTechniquesTheThreadStaticAttributeAndSystemWebHttpContextCurrentItems.aspx
        /// So be careful and only use the [ThreadStatic] trick if absolutely necessary
        /// </summary>
        [ThreadStatic]
        private static List<Exception> _nonHttpContextExceptions = null;
    }
}
