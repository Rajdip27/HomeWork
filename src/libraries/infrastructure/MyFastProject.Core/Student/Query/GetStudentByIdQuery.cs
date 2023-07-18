using FluentValidation;
using MediatR;
using MyFastProject.Repositories.Interfaces;
using System.Text.Json.Serialization;

namespace MyFastProject.Core.Student.Query;

public class GetStudentByIdQuery
{
	public class GetStudentQueryById : IRequest<Service.Models.ViewModel.Student> 
	{
		[JsonConstructor]
		public GetStudentQueryById(int id) { 
			Id = id;
		}
		public int Id { get; set; }
	}
	public class GetStudentQueryByIdHandler : IRequestHandler<GetStudentQueryById, Service.Models.ViewModel.Student>
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IValidator<GetStudentQueryById> _validator;
		
        public GetStudentQueryByIdHandler(IStudentRepository studentRepository,IValidator<GetStudentQueryById> validator)
        {
			_studentRepository = studentRepository;
			_validator = validator;
				
        }
        public async Task<Service.Models.ViewModel.Student> Handle(GetStudentQueryById request, CancellationToken cancellationToken)
		{
			var validationResult= await _validator.ValidateAsync(request, cancellationToken);
			if(!validationResult.IsValid)
				throw new ValidationException(validationResult.Errors);
			return await _studentRepository.GetById(request.Id);
		}
	}
	public class GetStudentByIdQueryValidator: AbstractValidator<GetStudentQueryById> 
	{
        public GetStudentByIdQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
