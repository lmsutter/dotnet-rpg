using System.Text.Json.Serialization;

namespace dotnet_rpg.Models
{
    // this attribute was added so that swagger would see the enum as a string
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}