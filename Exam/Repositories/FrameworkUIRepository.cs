using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exam.Models;

namespace Exam.Repositories
{
    class FrameworkUIRepository : IRepository<FrameworkUIModel>
    {
        IService<FrameworkDTO> service;
        IMapper mapper;
        public FrameworkUIRepository(IService<FrameworkDTO> service)
        {
            this.service = service;
            MapperConfiguration configuration = new MapperConfiguration(cfg=> {
                cfg.CreateMap<FrameworkDTO, FrameworkUIModel>();
                cfg.CreateMap<FrameworkUIModel, FrameworkDTO>();
            });
            mapper = configuration.CreateMapper();
        }
        public void CreateOrUpdate(FrameworkUIModel data)
        {
            service.CreateOrUpdate(mapper.Map<FrameworkDTO>(data));
        }

        public FrameworkUIModel Delete(FrameworkUIModel data)
        {
            FrameworkDTO framework = service.Get(data.Id);
            service.Delete(framework);
            return data;
        }

        public FrameworkUIModel Get(int id)
        {
            return mapper.Map<FrameworkUIModel>(service.Get(id));
        }

        public ObservableCollection<FrameworkUIModel> GetAll()
        {
            return new ObservableCollection<FrameworkUIModel>(service.GetAll().Select(x=>mapper.Map<FrameworkUIModel>(x)));
        }

        public void SaveAll()
        {
            service.SaveChanges();
        }
    }
}
