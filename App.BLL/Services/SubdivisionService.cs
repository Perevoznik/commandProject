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
    public class SubdivisionService : IGenericService<SubdivisionDTO>
    {
        IGenericRepository<Subdivision> subdvsRepository;
        private readonly IMapper _mapper;

        public SubdivisionService(IGenericRepository<Subdivision> subdvsRepository)
        {
            this.subdvsRepository = subdvsRepository;
            _mapper = new MapperConfiguration(cfg => {

                cfg.AddExpressionMapping();
                cfg.CreateMap<Subdivision, SubdivisionDTO>();
                cfg.CreateMap<SubdivisionDTO, Subdivision>();
            }).CreateMapper();
        }

        public SubdivisionDTO Add(SubdivisionDTO obj)
        {
            Subdivision subdivision = _mapper.Map<Subdivision>(obj);
            subdvsRepository.AddOrUpdate(subdivision);
            subdvsRepository.Save();
            return _mapper.Map<SubdivisionDTO>(subdivision);
        }

        public SubdivisionDTO Delete(int id)
        {
            Subdivision subdivision = subdvsRepository.Get(id);
            subdvsRepository.Delete(subdivision);
            subdvsRepository.Save();
            return _mapper.Map<SubdivisionDTO>(subdivision);
        }

        public IEnumerable<SubdivisionDTO> FindBy(Expression<Func<SubdivisionDTO, bool>> predicate)
        {
            try
            {
                var predicateSubdvs = _mapper.Map<Expression<Func<Subdivision, bool>>>(predicate);
                return subdvsRepository.FindBy(predicateSubdvs)
                    .Select(c => _mapper.Map<SubdivisionDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SubdivisionDTO Get(int id)
        {
            Subdivision subdivision = subdvsRepository.Get(id);
            return _mapper.Map<SubdivisionDTO>(subdivision);
        }

        public IEnumerable<SubdivisionDTO> GetAll()
        {
            return subdvsRepository.GetAll().Select(str => _mapper.Map<SubdivisionDTO>(str));
        }

        public void Save()
        {
            subdvsRepository.Save();
        }

        public SubdivisionDTO Update(SubdivisionDTO obj)
        {
            Subdivision subdivision = _mapper.Map<Subdivision>(obj);
            subdvsRepository.AddOrUpdate(subdivision);
            subdvsRepository.Save();
            return _mapper.Map<SubdivisionDTO>(subdivision);
        }
    }
}
