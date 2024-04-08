using AutoMapper;
using Lucid_Scribe.Data.Entities;
using Lucid_Scribe.Data.Repositories.Abstractions;
using Lucid_Scribe.Services.Abstractions;
using Lucid_Scribe.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services
{
    public class DreamService : IDreamService
    {
        private readonly IDreamRepository _dreamRepository;
        private readonly IRepository<Emotion> _emotionRepository;
        private readonly IMapper _mapper;
        public DreamService(IDreamRepository dreamRepository, IRepository<Emotion> emotionRepository, IMapper mapper)
        {
            _dreamRepository = dreamRepository;
            _emotionRepository = emotionRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(DreamCreateDTO model)
        {
            var dream = _mapper
                .Map<Dream>(model);
            var emotions = model.EmotionsIds
               .Select(item => _emotionRepository.GetByIdAsync(item).Result)
               .ToList();
            dream.Emotions = emotions;

            await _dreamRepository.AddAsync(dream);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _dreamRepository.DeleteByIdAsync(id);
        }

        public async Task<List<DreamDTO>> GetAsync()
        {
            var dreams = (await _dreamRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<DreamDTO>>(dreams);
        }

        public async Task<DreamDTO> GetByIdAsync(int id)
        {
            var category = await _dreamRepository.GetByIdAsync(id);
            return _mapper.Map<DreamDTO>(category);
        }

        public async Task<List<DreamDTO>> GetByNameAsync(string title)
        {
            var dreams = (await _dreamRepository.GetAsync(item => item.Title == title))
                .ToList();
            return _mapper.Map<List<DreamDTO>>(dreams);
        }

        public async Task<List<DreamDTO>> GetByUserAsync(string id)
        {
            var dreams = (await _dreamRepository.GetAsync(item => item.UserId == id))
                .ToList();
            return _mapper.Map<List<DreamDTO>>(dreams);
        }

        public async Task UpdateAsync(DreamEditDTO model)
        {
            var dream = _mapper.Map<Dream>(model);
            var emotions = model.EmotionsIds
                .Select(item => _emotionRepository.GetByIdAsync(item).Result)
                .ToList();

            await _dreamRepository.UpdateDreamAsync(dream, emotions);
        }
    }
}
