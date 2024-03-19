namespace ApplicantPortal.Application.Address.Commands;
public record CreateAddressRequest : IRequest<Guid>
{
    public Guid Id { set; get; }
    public string? Street { set; get; }
    public string? HouseNumber { set; get; }
    public string? City { set; get; }
    public string? Gprs { set; get; }
    public string? Box { set; get; }
    public int Applicant { set; get; }
    
}
