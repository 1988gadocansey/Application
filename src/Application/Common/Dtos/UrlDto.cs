namespace ApplicantPortal.Application.Common.Dtos;
public class UrlsDto
{
    public ICollection<string> Urls { get; }

    public UrlsDto(ICollection<string> urls)
    {
        Urls = urls;
    }
}
