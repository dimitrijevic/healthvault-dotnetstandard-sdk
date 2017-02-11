// Copyright(c) Microsoft Corporation.
// This content is subject to the Microsoft Reference Source License,
// see http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

using System;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Health
{
    /// <summary>
    /// The exception representing an error while trying to log a user on to an application that
    /// has an authorized record which no longer meets the minimum requirements for that application
    /// or the application has changed its minimum authorization requirements.
    /// </summary>
    /// 
    [Serializable]
    public sealed class HealthRecordReauthorizationRequired : HealthServiceException
    {
        /// <summary>
        /// Creates an instance of the <see cref="HealthRecordReauthorizationRequired"/>.
        /// </summary>
        /// 
        /// <remarks>
        /// This constructor is internal to the SDK. Application developers 
        /// using the SDK should catch instances of this exception instead of 
        /// throwing new exceptions of this type.
        /// </remarks>
        /// 
        internal HealthRecordReauthorizationRequired()
            : base(ResourceRetriever.GetResourceString("RecordReauthorizationRequired"))
        {
        }
        #region FxCop required ctors

        /// <summary>
        /// Creates an instance of the <see cref="HealthRecordReauthorizationRequired"/> 
        /// class with the specified message.
        /// </summary>
        /// 
        /// <param name="message">
        /// The error message.
        /// </param>
        /// 
        public HealthRecordReauthorizationRequired(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="HealthRecordReauthorizationRequired"/> 
        /// class with the specified message and inner exception.
        /// </summary>
        /// 
        /// <param name="message">
        /// The error message.
        /// </param>
        /// 
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        /// 
        public HealthRecordReauthorizationRequired(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #region Serialization

        /// <summary>
        /// Creates an instance of the <see cref="HealthRecordReauthorizationRequired"/> 
        /// class with the specified serialization information and context.
        /// </summary>
        /// 
        /// <param name="info">
        /// Serialized information about this exception.
        /// </param>
        /// 
        /// <param name="context">
        /// The source and destination of the serialized information.
        /// </param>
        /// 
        private HealthRecordReauthorizationRequired(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Serializes the exception.
        /// </summary>
        /// 
        /// <param name="info">
        /// The serialization information.
        /// </param>
        /// 
        /// <param name="context">
        /// The source and destination of the serialized information.
        /// </param>
        [SecurityCritical]
        [SecurityPermission(
            SecurityAction.LinkDemand,
            SerializationFormatter = true)]
        public override void GetObjectData(
            SerializationInfo info,
            StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion Serialization

        #endregion FxCop required ctors
    }

}
