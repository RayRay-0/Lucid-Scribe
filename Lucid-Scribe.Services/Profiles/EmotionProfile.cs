using AutoMapper;
using Lucid_Scribe.Data.Entities;
using Lucid_Scribe.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Services.Profiles
{
    public class EmotionProfile : Profile
    {
        public EmotionProfile()
        {
            CreateMap<Emotion, EmotionDTO>()
                .ReverseMap();
        }
    }
}
