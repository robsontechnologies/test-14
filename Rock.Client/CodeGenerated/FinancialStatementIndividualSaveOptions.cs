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
using System;
using System.Collections.Generic;


namespace Rock.Client
{
    /// <summary>
    /// Individual Save Options for the FinancialStatementGeneratorOptions
    /// </summary>
    public partial class FinancialStatementIndividualSaveOptionsEntity
    {
        /// <summary />
        public string DocumentDescription { get; set; }

        /// <summary />
        public string DocumentName { get; set; }

        /// <summary />
        public string DocumentPurposeKey { get; set; }

        /// <summary />
        public Rock.Client.Enums.FinancialStatementIndividualSaveOptionsSaveFor DocumentSaveFor { get; set; }

        /// <summary />
        public int? DocumentTypeId { get; set; }

        /// <summary />
        // Made Obsolete in Rock "1.13"
        [Obsolete( "Use OverwriteDocumentsOfThisTypeWithSamePurposeKey instead.", false )]
        public bool OverwriteDocumentsOfThisTypeCreatedOnSameDate { get; set; }

        /// <summary />
        public bool OverwriteDocumentsOfThisTypeWithSamePurposeKey { get; set; } = true;

        /// <summary />
        public bool SaveStatementsForIndividuals { get; set; }

        /// <summary>
        /// Copies the base properties from a source FinancialStatementIndividualSaveOptions object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( FinancialStatementIndividualSaveOptions source )
        {
            this.DocumentDescription = source.DocumentDescription;
            this.DocumentName = source.DocumentName;
            this.DocumentPurposeKey = source.DocumentPurposeKey;
            this.DocumentSaveFor = source.DocumentSaveFor;
            this.DocumentTypeId = source.DocumentTypeId;
            #pragma warning disable 612, 618
            this.OverwriteDocumentsOfThisTypeCreatedOnSameDate = source.OverwriteDocumentsOfThisTypeCreatedOnSameDate;
            #pragma warning restore 612, 618
            this.OverwriteDocumentsOfThisTypeWithSamePurposeKey = source.OverwriteDocumentsOfThisTypeWithSamePurposeKey;
            this.SaveStatementsForIndividuals = source.SaveStatementsForIndividuals;

        }
    }

    /// <summary>
    /// Individual Save Options for the FinancialStatementGeneratorOptions
    /// </summary>
    public partial class FinancialStatementIndividualSaveOptions : FinancialStatementIndividualSaveOptionsEntity
    {
    }
}
