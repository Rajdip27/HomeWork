using AutoMapper;
using MyFastProject.DataAccess.DatabaseContext;
using MyFastProject.Repositories.Interfaces;
using MyFastProject.Shared.Contracts;

namespace MyFastProject.Repositories.Concrete;

public class ProductRepository : RepositoryBase<Model.Entites.Product, Service.ViewModel.Product, int>, IProductRepository
{
    public ProductRepository(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
