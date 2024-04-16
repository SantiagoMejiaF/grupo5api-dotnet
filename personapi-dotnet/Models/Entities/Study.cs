namespace personapi_dotnet.Models.Entities;

public partial class Study
{
    public int IdProffesion { get; set; }

    public int CcPerson { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? University { get; set; }

    public virtual Person CcPersonNavigation { get; set; } = null!;
}
