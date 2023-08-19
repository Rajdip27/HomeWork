using MyFastProject.Shared.Contracts;

namespace MyFastProject.Repositories.Interfaces;

public interface IProductRepository:IRepository<Model.Entites.Product,Service.ViewModel.Product,int>
{
}
