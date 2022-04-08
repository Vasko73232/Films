using Films.Core.Domain.SharedKernel.Model;

namespace Films.Core.Domain.Model;

public class Film : BaseModel
{
    public string Name { get; set; }
    public string Link { get; set; }
    public string Review { get; set; }
        
    public string DateCreate { get; set; }
}