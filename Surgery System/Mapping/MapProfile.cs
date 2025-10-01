namespace Surgery_System.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateSurgeryVM, Surgery>()
                .ForMember(dest => dest.ImageUrl, src => src.Ignore())
                .ForMember(dest => dest.SurgeryDevices,opt => opt
                .MapFrom(src => src.DeviceIds.Select(id => new SurgeryDevice { DeviceId = id })));
            CreateMap<Surgery,EditSurgeryVM>()
                .ForMember(dest => dest.DeviceIds, opt => opt
                .MapFrom(src => src.SurgeryDevices.Select(sd => sd.DeviceId)));
            CreateMap<EditSurgeryVM, Surgery>()
                .ForMember(dest => dest.ImageUrl, src => src.Ignore())
                .ForMember(dest => dest.SurgeryDevices, opt => opt
                .MapFrom(src => src.DeviceIds.Select(id => new SurgeryDevice { DeviceId = id })));
        }
    }
}
