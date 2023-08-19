using MyFastProject.Shared;
using System.Text.Json.Serialization;

namespace MyFastProject.Service.ViewModel;

public class Product:IVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
   

}
