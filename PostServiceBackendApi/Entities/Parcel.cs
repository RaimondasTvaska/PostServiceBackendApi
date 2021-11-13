using System.Text.Json.Serialization;

namespace PostServiceBackendApi.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public string PhoneNo { get; set; }
        public string Info { get; set; }
        public int? PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }
    }
}
