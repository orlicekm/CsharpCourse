using AutoMapper;
using School.DAL.Entities;
using School.FrameworkBL.Models.DetailModels;
using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkBL
{
    public class MapperInitializer
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentEntity, StudentDetailModel>();
                cfg.CreateMap<StudentEntity, StudentListModel>();

                cfg.CreateMap<StudentDetailModel, StudentEntity>();
                cfg.CreateMap<StudentListModel, StudentEntity>();

                cfg.CreateMap<AddressEntity, AddressDetailModel>();
                cfg.CreateMap<AddressEntity, AddressListModel>();

                cfg.CreateMap<AddressDetailModel, AddressEntity>();
                cfg.CreateMap<AddressListModel, AddressEntity>();
            });
        }
    }
}