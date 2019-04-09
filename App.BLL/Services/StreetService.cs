using App.BLL.Models;
using App.DAL.DbLayer;
using App.DAL.Repositories;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class StreetService : IGenericService<StreetDTO>
    {
        IGenericRepository<Street> streetRepository;
        private readonly IMapper _mapper;

        public StreetService(IGenericRepository<Street> streetRepository)
        {
            this.streetRepository = streetRepository;
            _mapper = new MapperConfiguration(cfg => {

                cfg.AddExpressionMapping();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<StreetDTO, Street>();
            }).CreateMapper();
        }

        public StreetDTO Add(StreetDTO obj)
        {
            Street street = _mapper.Map<Street>(obj);
            streetRepository.AddOrUpdate(street);
            streetRepository.Save();
            return _mapper.Map<StreetDTO>(street);
        }

        public StreetDTO Delete(int id)
        {
            Street street = streetRepository.Get(id);
            streetRepository.Delete(street);
            streetRepository.Save();
            return _mapper.Map<StreetDTO>(street);
        }

        public IEnumerable<StreetDTO> FindBy(Expression<Func<StreetDTO, bool>> predicate)
        {
            try
            {
                var predicateStreet = _mapper.Map<Expression<Func<Street, bool>>>(predicate);
                return streetRepository.FindBy(predicateStreet)
                    .Select(c => _mapper.Map<StreetDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StreetDTO Get(int id)
        {
            Street street = streetRepository.Get(id);
            return _mapper.Map<StreetDTO>(street);
        }

        public IEnumerable<StreetDTO> GetAll()
        {
            return streetRepository.GetAll().Select(str => _mapper.Map<StreetDTO>(str));
        }

        public void Save()
        {
            streetRepository.Save();
        }

        public StreetDTO Update(StreetDTO obj)
        {
            Street street = _mapper.Map<Street>(obj);
            streetRepository.AddOrUpdate(street);
            streetRepository.Save();
            return _mapper.Map<StreetDTO>(street);
        }
    }
}
