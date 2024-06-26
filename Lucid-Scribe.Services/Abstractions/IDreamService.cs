﻿using Lucid_Scribe.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.Abstractions
{
    public interface IDreamService
    {
        Task<List<DreamDTO>> GetAsync();
        Task<DreamDTO> GetByIdAsync(int id);
        Task AddAsync(DreamCreateDTO Emotion);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(DreamEditDTO Emotion);
        Task<List<DreamDTO>> GetByUserAsync(string id);
    }
}
