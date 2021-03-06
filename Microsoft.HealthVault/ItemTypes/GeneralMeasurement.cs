// Copyright (c) Microsoft Corporation.  All rights reserved.
// MIT License
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.XPath;
using Microsoft.HealthVault.Exceptions;
using Microsoft.HealthVault.Helpers;

namespace Microsoft.HealthVault.ItemTypes
{
    /// <summary>
    /// A coded measurement and a display representation.
    /// </summary>
    ///
    /// <remarks>
    /// Examples include 30 cc, 500 mg, 15 liters, 30 inches, etc.
    /// </remarks>
    ///
    public class GeneralMeasurement : ItemBase
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="GeneralMeasurement"/>
        /// class with default values.
        /// </summary>
        ///
        public GeneralMeasurement()
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="GeneralMeasurement"/>
        /// class with display parameter.
        /// </summary>
        ///
        /// <param name="display"> It is a sentence to display for the measurement
        /// by the application. </param>
        ///
        /// <exception cref="ArgumentException">
        ///
        /// If <paramref name="display"/> is <b>null</b> or empty.
        /// </exception>
        ///
        public GeneralMeasurement(string display)
        {
            Display = display;
        }

        /// <summary>
        /// Populates this <see cref="GeneralMeasurement"/> instance from the data in the XML.
        /// </summary>
        ///
        /// <param name="navigator">
        /// The XML to get the general measurement data from.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="navigator"/> is <b>null</b>.
        /// </exception>
        ///
        public override void ParseXml(XPathNavigator navigator)
        {
            Validator.ThrowIfNavigatorNull(navigator);

            // display
            _display = navigator.SelectSingleNode("display").Value;

            // structured
            XPathNodeIterator structuredIterator = navigator.Select("structured");

            _structured = new Collection<StructuredMeasurement>();
            foreach (XPathNavigator structuredNav in structuredIterator)
            {
                StructuredMeasurement structuredMeasurement = new StructuredMeasurement();
                structuredMeasurement.ParseXml(structuredNav);
                _structured.Add(structuredMeasurement);
            }
        }

        /// <summary>
        /// Writes the general measurement data to the specified XmlWriter.
        /// </summary>
        ///
        /// <param name="nodeName">
        /// The name of the node to write XML.
        /// </param>
        ///
        /// <param name="writer">
        /// The XmlWriter to write the concern data to.
        /// </param>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="nodeName"/> is <b>null</b> or empty.
        /// </exception>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="writer"/> is <b>null</b>.
        /// </exception>
        ///
        /// <exception cref="ThingSerializationException">
        /// If <see cref="Display"/> is <b>null</b>.
        /// </exception>
        ///
        public override void WriteXml(string nodeName, XmlWriter writer)
        {
            Validator.ThrowIfStringNullOrEmpty(nodeName, "nodeName");
            Validator.ThrowIfWriterNull(writer);
            Validator.ThrowSerializationIfNull(_display, Resources.GeneralMeasurementDisplayNotSet);

            // <general-measurement>
            writer.WriteStartElement(nodeName);

            // display
            writer.WriteElementString("display", _display);

            // structured
            for (int index = 0; index < _structured.Count; ++index)
            {
                _structured[index].WriteXml("structured", writer);
            }

            // </general-measurement>
            writer.WriteEndElement();
        }

        /// <summary>
        /// Gets or sets a user readable string to display for the measurement
        /// by the applications.
        /// </summary>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="value"/> parameter is <b>null</b>, empty, or contains only
        /// whitespace on set.
        /// </exception>
        ///
        public string Display
        {
            get { return _display; }

            set
            {
                Validator.ThrowIfStringNullOrEmpty(value, "Display");
                Validator.ThrowIfStringIsWhitespace(value, "Display");
                _display = value;
            }
        }

        private string _display;

        /// <summary>
        /// Gets the coded values of the measurements.
        /// </summary>
        ///
        /// <remarks>
        /// Applications typically use this for calculations, charting, or graphing.
        /// </remarks>
        ///
        public Collection<StructuredMeasurement> Structured => _structured;

        private Collection<StructuredMeasurement> _structured =
            new Collection<StructuredMeasurement>();

        /// <summary>
        /// Gets a string representation of the general measurement item.
        /// </summary>
        ///
        /// <returns>
        /// A string representation of the general measurement item.
        /// </returns>
        ///
        public override string ToString()
        {
            return _display;
        }
    }
}
