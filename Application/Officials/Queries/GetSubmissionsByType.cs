using Application.Services.Interfaces;
using Application.Submissions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using Domain.Enums;
using MediatR;

namespace Application.Officials.Queries
{
    public class GetSubmissionsByType : IRequest<List<SubmissionDto>>
    {
        public SubmissionType SubmissionType { get; set; }

        public GetSubmissionsByType(SubmissionType submissionType)
        {
            SubmissionType = submissionType;
        }
    }

    public class GetSubmissionsByTypeHandler : IRequestHandler<GetSubmissionsByType, List<SubmissionDto>>
    {
        private readonly ISubmissionsRepository _repository;
        private readonly IMapper _mapper;

        public GetSubmissionsByTypeHandler(ISubmissionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SubmissionDto>> Handle(GetSubmissionsByType request, CancellationToken cancellationToken)
        {
            List<Submission> submissions = await _repository.GetSubmissionsByType(request.SubmissionType);
            List<SubmissionDto> result = _mapper.Map<List<SubmissionDto>>(submissions);

            return result;
        }
    }
}
