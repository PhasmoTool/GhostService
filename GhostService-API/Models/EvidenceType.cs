using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EvidenceType
    {
        primary,
        secondary
    }
}
