using MyFastProject.Shared;

namespace MyFastProject.Model.Entites;

public class Product : BaseAuditableEntity, IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } 
}
