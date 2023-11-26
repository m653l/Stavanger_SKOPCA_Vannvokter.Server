using Application.Services.Interfaces;
using Application.Submissions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Officials.Queries
{
    public class GetAllSubmissionsQuery : IRequest<List<SubmissionDto>>
    {
    }

    public class GetAllSubmissionsCommandHandler : IRequestHandler<GetAllSubmissionsQuery, List<SubmissionDto>>
    {
        private readonly ISubmissionsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSubmissionsCommandHandler(ISubmissionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SubmissionDto>> Handle(GetAllSubmissionsQuery request, CancellationToken cancellationToken)
        {
            List<Submission> submissions = await _repository.GetAllSubmissions();
            List<SubmissionDto> result = _mapper.Map<List<SubmissionDto>>(submissions);

            return result;
        }
    }
}
