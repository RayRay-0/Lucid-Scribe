using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.DTOs
{
    public class DreamDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public string UserId { get; set; }
        public List<EmotionDTO>? Emotions { get; set; }
        public string People { get; set; }
        public string Places { get; set; }
        public string Objects { get; set; }
        public int Weirdness { get; set; }
    }
}
