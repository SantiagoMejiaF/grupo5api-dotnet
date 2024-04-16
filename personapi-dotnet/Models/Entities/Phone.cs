namespace personapi_dotnet.Models.Entities;

public partial class Phone
{
    public string Number { get; set; } = null!;

    public string? Operator { get; set; }

    public int? CcPerson { get; set; }

    public virtual Person? CcPersonNavigation { get; set;}
}
