using MyFastProject.Shared.Contracts;

namespace MyFastProject.Repositories.Interfaces;

public interface IStudentRepository :IRepository<Model.Entites.Student,Service.Models.ViewModel.Student,int>
{ 

}
