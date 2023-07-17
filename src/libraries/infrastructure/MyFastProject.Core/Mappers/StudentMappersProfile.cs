using AutoMapper;

namespace MyFastProject.Core.Mappers;

public class StudentMappersProfile:Profile
{
    public StudentMappersProfile()
    {
        CreateMap<Service.Models.ViewModel.Student,Model.Entites.Student>().ReverseMap();
    }
}
