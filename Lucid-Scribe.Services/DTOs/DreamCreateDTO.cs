using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.DTOs
{
    public class DreamCreateDTO : DreamDTO
    {
        public List<int> EmotionsIds { get; set; }
    }
}
