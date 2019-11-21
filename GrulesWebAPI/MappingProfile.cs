using AutoMapper;
using Entidades.Models;
using GrulesWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrulesWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoModel>();
            CreateMap<AlunoModel, Aluno>();

            CreateMap<Grupo, GrupoModel>();
            CreateMap<GrupoModel, Grupo>();

            CreateMap<EventoModel, Evento>();
            CreateMap<Evento, EventoModel>();
        }
    }
}
