/* Code generated by Azure.Iot.Operations.ProtocolCompiler v0.9.0.0; DO NOT EDIT. */

#nullable enable

namespace MediaClient.Media
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using MediaClient;

    [System.CodeDom.Compiler.GeneratedCode("Azure.Iot.Operations.ProtocolCompiler", "0.9.0.0")]
    public partial class MetadataConfigurationOptions : IJsonOnDeserialized, IJsonOnSerializing
    {
        /// <summary>
        /// List of supported metadata compression type. Its options shall be chosen from tt:MetadataCompressionType.
        /// </summary>
        [JsonPropertyName("Extension")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MetadataConfigurationOptionsExtension? Extension { get; set; } = default;

        /// <summary>
        /// Optional parameter to configure if the metadata stream shall contain the Geo Location coordinates of each target.
        /// </summary>
        [JsonPropertyName("GeoLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GeoLocation { get; set; } = default;

        /// <summary>
        /// A device signalling support for content filtering shall support expressions with the provided expression size.
        /// </summary>
        [JsonPropertyName("MaxContentFilterSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? MaxContentFilterSize { get; set; } = default;

        /// <summary>
        /// Options for PTZ status filter.
        /// </summary>
        [JsonPropertyName("PTZStatusFilterOptions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public PtzstatusFilterOptions PtzstatusFilterOptions { get; set; } = default!;

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (PtzstatusFilterOptions is null)
            {
                throw new ArgumentNullException("PTZStatusFilterOptions field cannot be null");
            }
        }

        void IJsonOnSerializing.OnSerializing()
        {
            if (PtzstatusFilterOptions is null)
            {
                throw new ArgumentNullException("PTZStatusFilterOptions field cannot be null");
            }
        }
    }
}
