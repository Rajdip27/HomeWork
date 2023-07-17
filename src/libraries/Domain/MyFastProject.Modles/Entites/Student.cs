using MyFastProject.Shared;

namespace MyFastProject.Model.Entites;
/// <summary>class Student</summary>
public class Student: BaseAuditableEntity,IEntity
{
	/// <summary>
	/// Gets or sets the name of the student.
	/// </summary>
	/// <value>
	/// The name of the student.
	/// </value>
	public string StudentName { get; set; } = string.Empty;
	/// <summary>Gets or sets the address.</summary>
	/// <value>The address.</value>
	public string Address { get; set; } = string.Empty;
	/// <summary>Gets or sets the phone.</summary>
	/// <value>The phone.</value>
	public string Phone { get; set; } = string.Empty;
	/// <summary>Gets or sets the email.</summary>
	/// <value>The email.</value>
	public string Email { get; set; } = string.Empty;
	/// <summary>Gets or sets the age.</summary>
	/// <value>The age.</value>
	public int Age { get; set; }


	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set;}
}
