using Lucid_Scribe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Data.Repositories.Abstractions
{
    public interface IDreamRepository : IRepository<Dream>
    {
        public Task UpdateDreamAsync(Dream dream, List<Emotion> emotions);
    }
}
