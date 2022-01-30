using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SuchByte.WindowsUtils.Models
{
    internal class StartApplicationActionConfigModel : ISerializableConfiguration
    {
        [JsonPropertyName("path")] // To ensure backward compatibility with older versions of this plugin
        public string Path { get; set; } = "";

        [JsonPropertyName("arguments")] // To ensure backward compatibility with older versions of this plugin
        public string Arguments { get; set; } = "";
        public bool RunAsAdmin { get; set; } = false;
        public bool SyncButtonState { get; set; } = false;
        public StartMethod StartMethod { get; set; } = StartMethod.Start;



        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static StartApplicationActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<StartApplicationActionConfigModel>(config);
        }
    }

    public enum StartMethod
    {
        Start,
        StartStop,
        StartFocus,
    }
}
