using System.Collections.Generic;

namespace SovTechBackend.Service.DTOs
{
    public class JokeModel
    {
        public List<string> Categories { get; set; }
        public string CreatedAt { get; set; }
        public string IconUrl { get; set; }
        public string Id { get; set; }
        public string UpdatedAt { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }

    public class JokeDTO
    {
        public int Total { get; set; }
        public List<JokeModel> Result { get; set; }
    }
}
