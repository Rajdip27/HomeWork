using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFastProject.Core.Product.Command;
using static MyFastProject.Core.Student.Command.CreateStudent;

namespace MyFastProject.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Service.ViewModel.Product>> Create([FromForm] Service.ViewModel.Product product,IFormFile file)
    {
        
      var result = await _mediator.Send(new CreateProduct(product, file));
        return Ok(result);
    }
}
