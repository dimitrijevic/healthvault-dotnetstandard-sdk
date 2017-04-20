// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

using Newtonsoft.Json;

namespace Microsoft.HealthVault.RestApi.Generated.Models
{
    public partial class MicrosoftWin32SafeHandlesSafeWaitHandle
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftWin32SafeHandlesSafeWaitHandle class.
        /// </summary>
        public MicrosoftWin32SafeHandlesSafeWaitHandle()
        {
          this.CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftWin32SafeHandlesSafeWaitHandle class.
        /// </summary>
        public MicrosoftWin32SafeHandlesSafeWaitHandle(bool? isInvalid = default(bool?), bool? isClosed = default(bool?))
        {
            this.IsInvalid = isInvalid;
            this.IsClosed = isClosed;
            this.CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isInvalid")]
        public bool? IsInvalid { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isClosed")]
        public bool? IsClosed { get; private set; }

    }
}