// Copyright(c) Microsoft Corporation.
// This content is subject to the Microsoft Reference Source License,
// see http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

using System;
using System.IO;
using System.Net;
using System.Xml;
using Microsoft.HealthVault.Exceptions;

namespace Microsoft.HealthVault
{
    internal class TransformResponseHandler : IEasyWebResponseHandler
    {
        private HealthServiceRequest _healthServiceRequest;

        public TransformResponseHandler(HealthServiceRequest healthServiceRequest)
        {
            _healthServiceRequest = healthServiceRequest;
        }

        /// <summary>
        /// Handles the response stream and headers from transform request.
        /// </summary>
        /// 
        /// <param name="stream">The response stream.</param>
        /// <param name="responseHeaders">The response header collection.</param>
        /// 
        public void HandleResponse(Stream stream, WebHeaderCollection responseHeaders)
        {
            bool newStreamCreated = false;
            MemoryStream responseStream = stream as MemoryStream;

            try
            {
                // Platform returns a platform request id with the responses. This allows 
                // developers to have additional information if necessary for debugging/logging purposes.
                Guid responseId;
                if (responseHeaders != null && Guid.TryParse(responseHeaders["WC_ResponseId"], out responseId))
                {
                    _healthServiceRequest.ResponseId = responseId;
                }

                if (responseStream == null)
                {
                    newStreamCreated = true;
                    responseStream = HealthServiceRequest.CreateMemoryStream(stream);
                }

                ProcessResponseForErrors(responseHeaders, responseStream);
            }
            finally
            {
                if (newStreamCreated)
                {
                    responseStream?.Dispose();
                }
            }
        }

        private static void ProcessResponseForErrors(WebHeaderCollection responseHeaders, MemoryStream responseStream)
        {
            // Now look at the errors in the response before returning. If we see HV XML returned 
            // containing a failure status code, throw an exception
            XmlReaderSettings settings = SDKHelper.XmlReaderSettings;
            settings.CloseInput = false;
            settings.IgnoreWhitespace = false;

            try
            {
                using (XmlReader reader = XmlReader.Create(responseStream, settings))
                {
                    reader.NameTable.Add("wc");

                    if (SDKHelper.ReadUntil(reader, "response") && 
                        SDKHelper.ReadUntil(reader, "status") && 
                        SDKHelper.ReadUntil(reader, "code"))
                    {
                        HealthServiceResponseData responseData = new HealthServiceResponseData
                        {
                            CodeId = reader.ReadElementContentAsInt(),
                            ResponseHeaders = responseHeaders
                        };

                        if (responseData.Code != HealthServiceStatusCode.Ok)
                        {
                            responseData.Error = HealthServiceRequest.HandleErrorResponse(reader);

                            HealthServiceException e = HealthServiceExceptionHelper.GetHealthServiceException(responseData);

                            throw e;
                        }
                    }
                }
            }
            catch (FormatException)
            {
            }
            catch (MissingFieldException)
            {
            }
            catch (XmlException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}