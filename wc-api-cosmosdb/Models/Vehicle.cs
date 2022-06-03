using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wc_api_cosmosdb.Models;

public class Vehicle
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }
    [JsonProperty(PropertyName = "registrationNumber")]
    public string? RegNo { get; set; }
    [JsonProperty(PropertyName = "manufacturer")]
    public string? Make { get; set; }
    [JsonProperty(PropertyName = "model")]
    public string? Model { get; set; }
}