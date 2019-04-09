using App.BLL.Models;
using App.BLL.Services;
using App.DAL.DbLayer;
using App.DAL.Repositories;
using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Address
            builder.RegisterType(typeof(AddresService))
                        .As(typeof(IGenericService<AddressDTO>));
            builder.RegisterType(typeof(AddressRepository))
                      .As(typeof(IGenericRepository<Address>));

            //Street
            builder.RegisterType(typeof(StreetService))
                        .As(typeof(IGenericService<StreetDTO>));
            builder.RegisterType(typeof(StreetRepository))
                      .As(typeof(IGenericRepository<Street>));

            //Subdivision
            builder.RegisterType(typeof(SubdivisionService))
                        .As(typeof(IGenericService<SubdivisionDTO>));
            builder.RegisterType(typeof(SubdivisionRepository))
                      .As(typeof(IGenericRepository<Subdivision>));

            builder.RegisterType(typeof(AddressContext))
                     .As(typeof(DbContext)).InstancePerLifetimeScope();
        }
    }
}
