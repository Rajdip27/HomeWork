using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyFastProject.Repositories.Interfaces;

namespace MyFastProject.Core.Student.Command;

public class DeleteStudent
{
	public record DeleteStudentCommand(int id):IRequest<Service.Models.ViewModel.Student>;
	public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Service.Models.ViewModel.Student>
	{
		private readonly IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Service.Models.ViewModel.Student> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			await _studentRepository.Delete(request.id);
			return new Service.Models.ViewModel.Student();
		}
	}

	public class DeleteStudentCommandValidator: AbstractValidator<DeleteStudentCommand> 
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteStudentCommandValidator"/> class.
		/// </summary>
		public DeleteStudentCommandValidator()
        {
			RuleFor(x => x.id).NotEmpty().WithMessage("Id is required");
        }
    }
}
