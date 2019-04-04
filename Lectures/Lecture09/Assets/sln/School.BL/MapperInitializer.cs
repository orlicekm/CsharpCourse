using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL
{
    public class MapperInitializer
    {
        public void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
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