using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Application.SelectBoxItems;

public   record GetSHSProgrammesQuery : IRequest<IEnumerable<SHSProgrammesDto>>;
