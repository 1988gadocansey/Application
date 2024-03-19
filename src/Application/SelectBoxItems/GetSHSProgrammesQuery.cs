using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Application.SelectBoxItems;

public abstract record GetSHSProgrammesQuery : IRequest<IEnumerable<SHSProgrammesDto>>;
