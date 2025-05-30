/* Code generated by Azure.Iot.Operations.ProtocolCompiler v0.9.0.0; DO NOT EDIT. */

#nullable enable

namespace MediaClient.Media
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using MediaClient;

    [System.CodeDom.Compiler.GeneratedCode("Azure.Iot.Operations.ProtocolCompiler", "0.9.0.0")]
    public partial class AudioOutputConfiguration : IJsonOnDeserialized, IJsonOnSerializing
    {
        /// <summary>
        /// User readable name. Length up to 64 characters.
        /// </summary>
        [JsonPropertyName("Name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Volume setting of the output. The applicable range is defined via the option AudioOutputOptions.OutputLevelRange.
        /// </summary>
        [JsonPropertyName("OutputLevel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public int OutputLevel { get; set; } = default!;

        /// <summary>
        /// Token of the physical Audio output.
        /// </summary>
        [JsonPropertyName("OutputToken")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public string OutputToken { get; set; } = default!;

        /// <summary>
        /// Optional SendPrimacy parameter to indicate which direction is currently active.
        /// </summary>
        [JsonPropertyName("SendPrimacy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? SendPrimacy { get; set; } = default;

        /// <summary>
        /// Token that uniquely references this configuration. Length up to 64 characters.
        /// </summary>
        [JsonPropertyName("token")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public string Token { get; set; } = default!;

        /// <summary>
        /// Number of internal references currently using this configuration. This informational parameter is read-only. Deprecated for Media2 Service.
        /// </summary>
        [JsonPropertyName("UseCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public int UseCount { get; set; } = default!;

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name field cannot be null");
            }
            if (OutputToken is null)
            {
                throw new ArgumentNullException("OutputToken field cannot be null");
            }
            if (Token is null)
            {
                throw new ArgumentNullException("token field cannot be null");
            }
        }

        void IJsonOnSerializing.OnSerializing()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name field cannot be null");
            }
            if (OutputToken is null)
            {
                throw new ArgumentNullException("OutputToken field cannot be null");
            }
            if (Token is null)
            {
                throw new ArgumentNullException("token field cannot be null");
            }
        }
    }
}
