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
    /// Report configuration for the StatementGeneratorOptions ReportConfigurationList.
    /// </summary>
    public partial class FinancialStatementReportConfigurationEntity
    {
        /// <summary />
        public string DestinationFolder { get; set; }

        /// <summary />
        public bool ExcludeOptedOutIndividuals { get; set; } = true;

        /// <summary />
        public bool ExcludeRecipientsThatHaveAnIncompleteAddress { get; set; } = true;

        /// <summary />
        public string FilenamePrefix { get; set; }

        /// <summary />
        public bool IncludeInternationalAddresses { get; set; }

        /// <summary />
        public int? MaxStatementsPerChapter { get; set; }

        /// <summary />
        public decimal? MinimumContributionAmount { get; set; }

        /// <summary />
        public bool PreventSplittingPrimarySortValuesAcrossChapters { get; set; }

        /// <summary />
        public Rock.Client.Enums.FinancialStatementOrderBy PrimarySortOrder { get; set; }

        /// <summary />
        public Rock.Client.Enums.FinancialStatementOrderBy SecondarySortOrder { get; set; } = Rock.Client.Enums.FinancialStatementOrderBy.LastName;

        /// <summary />
        public bool SplitFilesOnPrimarySortValue { get; set; }

        /// <summary />
        public DateTime? CreatedDateTime { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary>
        /// Copies the base properties from a source FinancialStatementReportConfiguration object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( FinancialStatementReportConfiguration source )
        {
            this.DestinationFolder = source.DestinationFolder;
            this.ExcludeOptedOutIndividuals = source.ExcludeOptedOutIndividuals;
            this.ExcludeRecipientsThatHaveAnIncompleteAddress = source.ExcludeRecipientsThatHaveAnIncompleteAddress;
            this.FilenamePrefix = source.FilenamePrefix;
            this.IncludeInternationalAddresses = source.IncludeInternationalAddresses;
            this.MaxStatementsPerChapter = source.MaxStatementsPerChapter;
            this.MinimumContributionAmount = source.MinimumContributionAmount;
            this.PreventSplittingPrimarySortValuesAcrossChapters = source.PreventSplittingPrimarySortValuesAcrossChapters;
            this.PrimarySortOrder = source.PrimarySortOrder;
            this.SecondarySortOrder = source.SecondarySortOrder;
            this.SplitFilesOnPrimarySortValue = source.SplitFilesOnPrimarySortValue;
            this.CreatedDateTime = source.CreatedDateTime;
            this.Guid = source.Guid;

        }
    }

    /// <summary>
    /// Report configuration for the StatementGeneratorOptions ReportConfigurationList.
    /// </summary>
    public partial class FinancialStatementReportConfiguration : FinancialStatementReportConfigurationEntity
    {
    }
}
