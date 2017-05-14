using AppQuanLyThuHocPhi.Entities.Models;
using AppQuanLyThuHocPhi.Web.Models.ViewModel;
using AutoMapper;

namespace AppQuanLyThuHocPhi.Web.App_Start
{
    public class MappingConfig
    {
        private static IMapper _mapper = null;
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    InitMap();

                return _mapper;
            }
        }

        public static void InitMap()
        {
            var config = new MapperConfiguration(map =>
            {
                map.CreateMap<Lop, LopViewModel>();
             

            });

            _mapper = config.CreateMapper();
        }
    }
}