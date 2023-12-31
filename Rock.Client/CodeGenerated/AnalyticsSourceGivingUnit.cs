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
    /// Base client model for AnalyticsSourceGivingUnit that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class AnalyticsSourceGivingUnitEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public string Frequency { get; set; }

        /// <summary />
        public decimal GiftAmountIqr { get; set; }

        /// <summary />
        public decimal GiftAmountMedian { get; set; }

        /// <summary />
        public decimal GiftFrequencyMean { get; set; }

        /// <summary />
        public decimal GiftFrequencyStandardDeviation { get; set; }

        /// <summary />
        public int GivingBin { get; set; }

        /// <summary />
        public string GivingId { get; set; }

        /// <summary />
        public int GivingLeaderPersonId { get; set; }

        /// <summary />
        public int GivingPercentile { get; set; }

        /// <summary />
        public string GivingSalutation { get; set; }

        /// <summary />
        public string GivingSalutationFull { get; set; }

        /// <summary />
        public int PercentGiftsScheduled { get; set; }

        /// <summary />
        public string PreferredCurrency { get; set; }

        /// <summary />
        public int PreferredCurrencyValueId { get; set; }

        /// <summary />
        public string PreferredSource { get; set; }

        /// <summary />
        public int PreferredSourceValueId { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source AnalyticsSourceGivingUnit object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( AnalyticsSourceGivingUnit source )
        {
            this.Id = source.Id;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.Frequency = source.Frequency;
            this.GiftAmountIqr = source.GiftAmountIqr;
            this.GiftAmountMedian = source.GiftAmountMedian;
            this.GiftFrequencyMean = source.GiftFrequencyMean;
            this.GiftFrequencyStandardDeviation = source.GiftFrequencyStandardDeviation;
            this.GivingBin = source.GivingBin;
            this.GivingId = source.GivingId;
            this.GivingLeaderPersonId = source.GivingLeaderPersonId;
            this.GivingPercentile = source.GivingPercentile;
            this.GivingSalutation = source.GivingSalutation;
            this.GivingSalutationFull = source.GivingSalutationFull;
            this.PercentGiftsScheduled = source.PercentGiftsScheduled;
            this.PreferredCurrency = source.PreferredCurrency;
            this.PreferredCurrencyValueId = source.PreferredCurrencyValueId;
            this.PreferredSource = source.PreferredSource;
            this.PreferredSourceValueId = source.PreferredSourceValueId;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for AnalyticsSourceGivingUnit that includes all the fields that are available for GETs. Use this for GETs (use AnalyticsSourceGivingUnitEntity for POST/PUTs)
    /// </summary>
    public partial class AnalyticsSourceGivingUnit : AnalyticsSourceGivingUnitEntity
    {
    }
}
