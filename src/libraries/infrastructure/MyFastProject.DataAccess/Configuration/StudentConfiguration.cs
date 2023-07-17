using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFastProject.Model.Entites;
using MyFastProject.Shared.Enums;

namespace MyFastProject.DataAccess.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
	/// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
	/// <param name="builder">The builder to be used to configure the entity type.</param>
	public void Configure(EntityTypeBuilder<Student> builder)
	{
		builder.ToTable("Students");
		builder.HasKey(x => x.Id);
	}
}
