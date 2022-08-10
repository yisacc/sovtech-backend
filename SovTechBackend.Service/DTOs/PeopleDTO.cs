using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovTechBackend.Service.DTOs
{
    public class PeopleDTO
    {

        public int Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
        public List<PeopleModel> Results { get; set; }
    }
    public class PeopleModel
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public List<Uri> Films { get; set; }
        public List<Uri> Species { get; set; }
        public List<Uri> Vehicles { get; set; }
        public List<Uri> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }


}
