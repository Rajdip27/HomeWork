using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyFastProject.Repositories.Interfaces;

namespace MyFastProject.Core.Product.Command;

public record CreateProduct(Service.ViewModel.Product Product,IFormFile file) :IRequest<Service.ViewModel.Product>;
public class CreateProductHandeler : IRequestHandler<CreateProduct, Service.ViewModel.Product>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public CreateProductHandeler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public Task<Service.ViewModel.Product> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var fileName = request.file.FileName;
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            request.file.CopyTo(stream);
        }
         var data= _mapper.Map<Model.Entites.Product>(request.Product); 
        data.Image= fileName;


        return _productRepository.Add(data);
    }
}
