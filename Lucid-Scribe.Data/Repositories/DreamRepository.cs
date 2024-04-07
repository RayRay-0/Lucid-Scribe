using Lucid_Scribe.Data.Entities;
using Lucid_Scribe.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Data.Repositories
{
    public class DreamRepository
        : Repository<Dream>, IDreamRepository
    {
        private readonly ApplicationDbContext _context;
        public DreamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateDreamAsync(Dream dream, List<Emotion> emotions)
        {
            _context.ChangeTracker.LazyLoadingEnabled = true;
            _context.Dreams.Attach(dream);

            if (!_context.Entry(dream).Collection(d => d.Emotions).IsLoaded)
            {
                await _context.Entry(dream).Collection(d => d.Emotions).LoadAsync();
            }
            dream.Emotions = emotions;

            await UpdateAsync(dream);
        }
    }
}
