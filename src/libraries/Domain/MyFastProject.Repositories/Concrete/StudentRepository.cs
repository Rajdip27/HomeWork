using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFastProject.DataAccess.DatabaseContext;
using MyFastProject.Repositories.Interfaces;
using MyFastProject.Shared.Contracts;

namespace MyFastProject.Repositories.Concrete;

public class StudentRepository : RepositoryBase<Model.Entites.Student, Service.Models.ViewModel.Student, int>,IStudentRepository
{
	public StudentRepository(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
	{

	}
}
