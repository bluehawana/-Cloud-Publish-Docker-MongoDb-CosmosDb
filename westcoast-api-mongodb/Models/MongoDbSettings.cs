using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace westcoast_api_mongodb.Models
{
  public class MongoDbSettings
  {
    public string ConnectionUri { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
  }
}