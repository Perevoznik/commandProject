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
    public class AddresService : IGenericService<AddressDTO>
    {
        private readonly IMapper _mapper;
        IGenericRepository<Address> addressRepository;

        public AddresService(IGenericRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Address, AddressDTO>()
                .ForMember("StreetName", opt => opt.MapFrom(str => str.Street.StreetName))
                .ForMember("Subdivision", opt => opt.MapFrom(sdv => sdv.Subdivision.SubdivisionName));
                cfg.CreateMap<AddressDTO, Address>();
            }
               ).CreateMapper();
        }

        public AddressDTO Add(AddressDTO obj)
        {
            Address address = _mapper.Map<Address>(obj);
            addressRepository.AddOrUpdate(address);
            addressRepository.Save();
            return _mapper.Map<AddressDTO>(address);
        }

        public AddressDTO Delete(int id)
        {
            Address address = addressRepository.Get(id);
            addressRepository.Delete(address);
            addressRepository.Save();
            return _mapper.Map<AddressDTO>(address);
        }

        public IEnumerable<AddressDTO> FindBy(Expression<Func<AddressDTO, bool>> predicate)
        {
            try
            {
                var predicateAddr = _mapper.Map<Expression<Func<Address, bool>>>(predicate);
                return addressRepository.FindBy(predicateAddr)
                    .Select(c => _mapper.Map<AddressDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AddressDTO Get(int id)
        {
            Address address = addressRepository.Get(id);
            return _mapper.Map<AddressDTO>(address);
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            return addressRepository.GetAll().Select(addr => _mapper.Map<AddressDTO>(addr));
        }

        public void Save()
        {
            addressRepository.Save();
        }

        public AddressDTO Update(AddressDTO obj)
        {
            Address address = _mapper.Map<Address>(obj);
            addressRepository.AddOrUpdate(address);
            addressRepository.Save();
            return _mapper.Map<AddressDTO>(address);
        }
    }
}
