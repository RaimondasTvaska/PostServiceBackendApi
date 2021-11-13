using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PostServiceBackendApi.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public int Capacity { get; set; }
        public string PostCode { get; set; }
        [JsonIgnore]
        public List<Parcel> Parcel { get; set; }
    }
}
