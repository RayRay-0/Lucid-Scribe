using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid_Scribe.Data.Entities.Abstractions;

namespace Lucid_Scribe.Data.Entities
{
    public class Emotion : BaseEntity
    {
        public Emotion()
        {
            Dreams = new HashSet<Dream>();
        }
        public string Name { get; set; }
        public string IconURL { get; set; }
        public virtual ICollection<Dream>? Dreams { get; set; }
    }
}
