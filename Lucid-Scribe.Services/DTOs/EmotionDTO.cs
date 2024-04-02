using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.DTOs
{
    public class EmotionDTO : BaseDTO
    {
        public string Name { get; set; }
        public string IconURL { get; set; }
        public List<DreamDTO>? DreamsIds { get; set; }
    }
}
