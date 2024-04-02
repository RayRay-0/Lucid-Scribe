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
    public class DreamService : IDreamService
    {
        private readonly IRepository<Dream> _repository;
        private readonly IMapper _mapper;
        public DreamService(IRepository<Dream> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(DreamDTO model)
        {
            var dream = _mapper
                .Map<Dream>(model);

            await _repository.AddAsync(dream);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<DreamDTO>> GetAsync()
        {
            var dreams = (await _repository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<DreamDTO>>(dreams);
        }

        public async Task<DreamDTO> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<DreamDTO>(category);
        }

        public async Task<List<DreamDTO>> GetByNameAsync(string title)
        {
            var dreams = (await _repository.GetAsync(item => item.Title == title))
                .ToList();
            return _mapper.Map<List<DreamDTO>>(dreams);
        }

        public async Task UpdateAsync(DreamDTO model)
        {
            var dream = _mapper.Map<Dream>(model);
            await _repository.UpdateAsync(dream);
        }
    }
}
