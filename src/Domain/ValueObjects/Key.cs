namespace ApplicantPortal.Domain.ValueObjects;

public class Key
{
    public Key(int id) => Id = id;
    public int Id { get; private set; }
}
