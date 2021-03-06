﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// MIT License
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Microsoft.HealthVault.Helpers;

namespace Microsoft.HealthVault.ItemTypes
{
    /// <summary>
    /// Encapsulates the details of PAP session measurements.
    /// </summary>
    /// <typeparam name="T">The type of the measurement.</typeparam>
    ///
    public class PapSessionMeasurements<T> : ItemBase
        where T : ItemBase, new()
    {
        /// <summary>
        /// Populates this <see cref="PapSessionMeasurements{T}"/> instance from the data in the specified XML.
        /// </summary>
        ///
        /// <param name="navigator">
        /// The XML to get the PAP session measurements data from.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="navigator"/> parameter is <b>null</b>.
        /// </exception>
        ///
        public override void ParseXml(XPathNavigator navigator)
        {
            Validator.ThrowIfNavigatorNull(navigator);

            _mean = XPathHelper.GetOptNavValue<T>(navigator, "mean");
            _median = XPathHelper.GetOptNavValue<T>(navigator, "median");
            _maximum = XPathHelper.GetOptNavValue<T>(navigator, "maximum");
            _percentile95th = XPathHelper.GetOptNavValue<T>(navigator, "percentile-95th");
            _percentile90th = XPathHelper.GetOptNavValue<T>(navigator, "percentile-90th");
        }

        /// <summary>
        /// Writes the XML representation of the PAP session measurements into
        /// the specified XML writer.
        /// </summary>
        ///
        /// <param name="nodeName">
        /// The name of the outer node for the PAP session measurements.
        /// </param>
        ///
        /// <param name="writer">
        /// The XML writer into which the PAP session measurements should be
        /// written.
        /// </param>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="nodeName"/> parameter is <b>null</b> or empty.
        /// </exception>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="writer"/> parameter is <b>null</b>.
        /// </exception>
        ///
        public override void WriteXml(string nodeName, XmlWriter writer)
        {
            Validator.ThrowIfStringNullOrEmpty(nodeName, "nodeName");
            Validator.ThrowIfWriterNull(writer);

            writer.WriteStartElement(nodeName);

            XmlWriterHelper.WriteOpt(writer, "mean", _mean);
            XmlWriterHelper.WriteOpt(writer, "median", _median);
            XmlWriterHelper.WriteOpt(writer, "maximum", _maximum);
            XmlWriterHelper.WriteOpt(writer, "percentile-95th", _percentile95th);
            XmlWriterHelper.WriteOpt(writer, "percentile-90th", _percentile90th);

            writer.WriteEndElement();
        }

        /// <summary>
        /// Gets or sets the mean value that occurred during the session.
        /// </summary>
        ///
        /// <remarks>
        /// If there is no information about the mean the value should be set to <b>null</b>.
        /// </remarks>
        ///
        public T Mean
        {
            get { return _mean; }
            set { _mean = value; }
        }

        private T _mean;

        /// <summary>
        /// Gets or sets the median value that occurred during the session.
        /// </summary>
        ///
        /// <remarks>
        /// If there is no information about the median the value should be set to <b>null</b>.
        /// </remarks>
        ///
        public T Median
        {
            get { return _median; }
            set { _median = value; }
        }

        private T _median;

        /// <summary>
        /// Gets or sets the greatest value that occured during the session.
        /// </summary>
        ///
        /// <remarks>
        /// If there is no information about the maximum the value should be set to <b>null</b>.
        /// </remarks>
        ///
        public T Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }

        private T _maximum;

        /// <summary>
        /// Gets or sets the value that was at or below this value 95% of the time.
        /// </summary>
        ///
        /// <remarks>
        /// If there is no information about the percentile95th the value should be set to <b>null</b>.
        /// </remarks>
        ///
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "A valid element name in PAP session.")]
        public T Percentile95th
        {
            get { return _percentile95th; }
            set { _percentile95th = value; }
        }

        private T _percentile95th;

        /// <summary>
        /// Gets or sets the value that was at or below this value 90% of the time.
        /// </summary>
        ///
        /// <remarks>
        /// If there is no information about the percentile90th the value should be set to <b>null</b>.
        /// </remarks>
        ///
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "A valid element name in PAP session.")]
        public T Percentile90th
        {
            get { return _percentile90th; }
            set { _percentile90th = value; }
        }

        private T _percentile90th;

        /// <summary>
        /// Gets a string representation of the PAP session measurements.
        /// </summary>
        ///
        /// <returns>
        /// A string representation of the PAP session measurements.
        /// </returns>
        ///
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(200);

            AddStringRepresentationOfMeasurement(result, Mean, Resources.MeanToStringFormat);
            AddStringRepresentationOfMeasurement(result, Median, Resources.MedianToStringFormat);
            AddStringRepresentationOfMeasurement(result, Maximum, Resources.MaximumToStringFormat);
            AddStringRepresentationOfMeasurement(result, Percentile95th, Resources.Percentile95thToStringFormat);
            AddStringRepresentationOfMeasurement(result, Percentile90th, Resources.Percentile90thToStringFormat);

            return result.ToString();
        }

        private static void AddStringRepresentationOfMeasurement(StringBuilder sb, T measurement, string format)
        {
            if (measurement != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append(Resources.ListSeparator);
                }

                sb.AppendFormat(format, measurement.ToString());
            }
        }
    }
}
