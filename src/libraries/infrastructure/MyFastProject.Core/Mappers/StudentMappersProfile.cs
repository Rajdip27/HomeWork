using AutoMapper;

namespace MyFastProject.Core.Mappers;

public class StudentMappersProfile:Profile
{
	/// <summary>
	/// Initializes a new instance of the <see cref="StudentMappersProfile"/> class.
	/// </summary>
	public StudentMappersProfile()
    {
        CreateMap<Service.Models.ViewModel.Student,Model.Entites.Student>().ReverseMap();
        CreateMap<Service.ViewModel.Product,Model.Entites.Product>().ReverseMap();

    }
}
