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
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

using Rock.Data;
using Rock.Model;

namespace Rock.Jobs
{

    /// <summary>
    /// Job to re-calculate the top signal for all individuals in the database.
    /// </summary>
    [DisplayName( "Calculate Person Signals" )]
    [Description( "Re-calculates all person signals to ensure that the top-most signal is still the current one." )]

    public class CalculatePersonSignals : RockJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatePersonSignals"/> class.
        /// </summary>
        public CalculatePersonSignals()
        {
        }


        /// <inheritdoc cref="RockJob.Execute()"/>
        public override void Execute()
        {
            List<int> people;
            int count = 0;

            //
            // Create a list of every Person Id that has a signal.
            //
            using ( var rockContext = new RockContext() )
            {
                people = new PersonSignalService( rockContext ).Queryable()
                    .Select( s => s.PersonId )
                    .Distinct()
                    .ToList();
            }

            //
            // Operate in batches of 250 so we don't lag the context too much.
            //
            while ( people.Any() )
            {
                var batch = people.Take( 250 ).ToList();
                people.RemoveRange( 0, batch.Count );

                using ( var rockContext = new RockContext() )
                {
                    new PersonService( rockContext ).Queryable()
                        .Where( p => batch.Contains( p.Id ) )
                        .ToList()
                        .ForEach( p => p.CalculateSignals() );

                    rockContext.SaveChanges();

                    count += batch.Count;
                }
            }

            this.Result = string.Format( "{0} people processed", count );
        }
    }
}