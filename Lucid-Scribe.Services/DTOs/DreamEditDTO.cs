using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.DTOs
{
    public class DreamEditDTO : DreamDTO
    {
        public DreamEditDTO(DreamDTO dream)
        {
            Id = dream.Id;
            Title = dream.Title;
            Description = dream.Description;
            EntryDate = dream.EntryDate;
            UserId = dream.UserId;
        }

        public DreamEditDTO()
        {
        }

        public List<int> EmotionsIds { get; set; }
    }
}
