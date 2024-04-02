using AutoMapper;
using Lucid_Scribe.Data.Entities;
using Lucid_Scribe.Data.Repositories.Abstractions;
using Lucid_Scribe.Services.Abstractions;
using Lucid_Scribe.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services
{
    public class EmotionService : IEmotionService
    {
        private readonly IRepository<Emotion> _emotionRepository;

        private readonly IMapper _mapper;
        public EmotionService(IRepository<Emotion> emotionRepository,
            IMapper mapper)
        {
            _emotionRepository = emotionRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(EmotionDTO model)
        {
            var emotion = _mapper.Map<Emotion>(model);
            await _emotionRepository.AddAsync(emotion);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _emotionRepository.DeleteByIdAsync(id);
        }

        public async Task<EmotionDTO> GetByIdAsync(int id)
        {
            var emotion = await _emotionRepository
                .GetByIdAsync(id);

            return _mapper.Map<EmotionDTO>(emotion);
        }

        public async Task<EmotionDTO> GetByIdEditAsync(int id)
        {
            var emotion = await _emotionRepository
                .GetByIdAsync(id);
            return _mapper.Map<EmotionDTO>(emotion);
        }
        public async Task<List<EmotionDTO>> GetByNameAsync(string name)
        {
            var emotions = await _emotionRepository.GetAsync(item => item.Name == name);
            return _mapper.Map<List<EmotionDTO>>(emotions);
        }

        public async Task<List<EmotionDTO>> GetAsync()
        {
            var emotions = await _emotionRepository.GetAllAsync();
            return _mapper.Map<List<EmotionDTO>>(emotions);
        }

        public async Task UpdateAsync(EmotionDTO model)
        {
            var emotion = _mapper.Map<Emotion>(model);

            await _emotionRepository.UpdateAsync(emotion);
        }
    }
}
