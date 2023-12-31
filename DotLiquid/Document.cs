﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DotLiquid.Exceptions;

namespace DotLiquid
{
	public class Document : Block
	{
		/// <summary>
		/// We don't need markup to open this block
		/// </summary>
		/// <param name="tagName"></param>
		/// <param name="markup"></param>
		/// <param name="tokens"></param>
		public override void Initialize(string tagName, string markup, List<string> tokens)
		{
            var initialTokens = tokens.ToArray();
            try
            {
                Parse( tokens );
            }
            catch (SyntaxException se)
            {
                var remainingTokens = tokens.ToArray();
                var processedTokens = initialTokens.Take( initialTokens.Length - remainingTokens.Length ).ToList();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var token in processedTokens)
                {
                    stringBuilder.Append( StandardFilters.Escape( token ) );
                }

                se.LavaStackTrace = stringBuilder.ToString() + " ^...";
                throw;
            }
		}

		/// <summary>
		/// There isn't a real delimiter
		/// </summary>
		protected override string BlockDelimiter
		{
			get { return string.Empty; }
		}

		/// <summary>
		/// Document blocks don't need to be terminated since they are not actually opened
		/// </summary>
		protected override void AssertMissingDelimitation()
		{
		}

		/// <summary>
		/// This is used to handle the new known/valid control exceptions in Liquid.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="result"></param>
		public override void Render(Context context, TextWriter result)
		{
			try
			{
				base.Render(context, result);
			}
            catch (InterruptException)
            {
                // Ignore all interrupts.
            }
		}
	}
}