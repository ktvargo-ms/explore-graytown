/* Code generated by Azure.Iot.Operations.ProtocolCompiler v0.9.0.0; DO NOT EDIT. */

#nullable enable

namespace MediaClient.Media
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using MediaClient;

    [System.CodeDom.Compiler.GeneratedCode("Azure.Iot.Operations.ProtocolCompiler", "0.9.0.0")]
    public partial class GetVideoEncoderConfigurationOptionsResponsePayload : IJsonOnDeserialized, IJsonOnSerializing
    {
        /// <summary>
        /// The Command response argument.
        /// </summary>
        [JsonPropertyName("GetVideoEncoderConfigurationOptionsCommandResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public GetVideoEncoderConfigurationOptionsCommandResponse GetVideoEncoderConfigurationOptionsCommandResponse { get; set; } = default!;

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (GetVideoEncoderConfigurationOptionsCommandResponse is null)
            {
                throw new ArgumentNullException("GetVideoEncoderConfigurationOptionsCommandResponse field cannot be null");
            }
        }

        void IJsonOnSerializing.OnSerializing()
        {
            if (GetVideoEncoderConfigurationOptionsCommandResponse is null)
            {
                throw new ArgumentNullException("GetVideoEncoderConfigurationOptionsCommandResponse field cannot be null");
            }
        }
    }
}
