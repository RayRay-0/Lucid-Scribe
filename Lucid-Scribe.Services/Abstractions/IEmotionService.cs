using Lucid_Scribe.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.Abstractions
{
    public interface IEmotionService
    {
        Task<List<EmotionDTO>> GetAsync();
        Task<EmotionDTO> GetByIdAsync(int id);
        Task AddAsync(EmotionDTO Emotion);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(EmotionDTO Emotion);
    }
}
