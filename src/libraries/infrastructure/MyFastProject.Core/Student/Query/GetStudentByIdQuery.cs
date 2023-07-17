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
		
        public GetStudentQueryByIdHandler(IStudentRepository studentRepository)
        {
			_studentRepository = studentRepository;
				
        }
        public async Task<Service.Models.ViewModel.Student> Handle(GetStudentQueryById request, CancellationToken cancellationToken)
		{
			return await _studentRepository.GetById(request.Id);
		}
	}
}
