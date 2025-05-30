/* Code generated by Azure.Iot.Operations.ProtocolCompiler v0.9.0.0; DO NOT EDIT. */

#nullable enable

namespace MediaClient.Media
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using MediaClient;

    [System.CodeDom.Compiler.GeneratedCode("Azure.Iot.Operations.ProtocolCompiler", "0.9.0.0")]
    public partial class GetMetadataConfigurationsCommandResponse : IJsonOnDeserialized, IJsonOnSerializing
    {
        /// <summary>
        /// The requested metadata configurations.
        /// </summary>
        [JsonPropertyName("Configurations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public List<MetadataConfiguration> Configurations { get; set; } = default!;

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (Configurations is null)
            {
                throw new ArgumentNullException("Configurations field cannot be null");
            }
        }

        void IJsonOnSerializing.OnSerializing()
        {
            if (Configurations is null)
            {
                throw new ArgumentNullException("Configurations field cannot be null");
            }
        }
    }
}
