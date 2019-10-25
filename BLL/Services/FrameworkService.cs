using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FrameworkService : IService<FrameworkDTO>
    {
        readonly IRepository<Framework> repository;
        IMapper mapper;
        public FrameworkService(IRepository<Framework> repository)
        {
            this.repository = repository;
            MapperConfiguration config;
            config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Framework, FrameworkDTO>();
                    cfg.CreateMap<FrameworkDTO, Framework>();
                });
            mapper = config.CreateMapper();
        }

        public void CreateOrUpdate(FrameworkDTO data)
        {
            repository.CreateOrUpdate(mapper.Map<Framework>(data));
        }

        public FrameworkDTO Delete(FrameworkDTO data)
        {
            Framework framework = repository.Get(data.Id);
            repository.Delete(framework);
            return data;
        }

        public FrameworkDTO Get(int id)
        {
            return mapper.Map<FrameworkDTO>(repository.Get(id));
        }

        public IEnumerable<FrameworkDTO> GetAll()
        {
            return repository.GetAll().Select(x=> mapper.Map<FrameworkDTO>(x));
        }

        public void SaveChanges()
        {
            repository.SaveAll();
        }
    }
}
