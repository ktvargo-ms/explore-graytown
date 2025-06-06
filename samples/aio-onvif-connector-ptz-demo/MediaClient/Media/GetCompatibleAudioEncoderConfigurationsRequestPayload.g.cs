/* Code generated by Azure.Iot.Operations.ProtocolCompiler v0.9.0.0; DO NOT EDIT. */

#nullable enable

namespace MediaClient.Media
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using MediaClient;

    [System.CodeDom.Compiler.GeneratedCode("Azure.Iot.Operations.ProtocolCompiler", "0.9.0.0")]
    public partial class GetCompatibleAudioEncoderConfigurationsRequestPayload : IJsonOnDeserialized, IJsonOnSerializing
    {
        /// <summary>
        /// The Command request argument.
        /// </summary>
        [JsonPropertyName("GetCompatibleAudioEncoderConfigurations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public GetCompatibleAudioEncoderConfigurations GetCompatibleAudioEncoderConfigurations { get; set; } = default!;

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (GetCompatibleAudioEncoderConfigurations is null)
            {
                throw new ArgumentNullException("GetCompatibleAudioEncoderConfigurations field cannot be null");
            }
        }

        void IJsonOnSerializing.OnSerializing()
        {
            if (GetCompatibleAudioEncoderConfigurations is null)
            {
                throw new ArgumentNullException("GetCompatibleAudioEncoderConfigurations field cannot be null");
            }
        }
    }
}
