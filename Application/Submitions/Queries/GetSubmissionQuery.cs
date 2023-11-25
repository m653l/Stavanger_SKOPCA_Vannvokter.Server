using Application.Services.Interfaces;
using Application.Submitions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submitions.Queries
{
    public class GetSubmissionQuery : IRequest<SubmissionDto>
    {
        public int Id { get; set; }

        public GetSubmissionQuery(int id) 
        {
            Id = id;
        }
    }

    public class GetSubmitionQueryHandler : IRequestHandler<GetSubmissionQuery, SubmissionDto>
    {
        private readonly ISubmissionsRepository _repository;
        private readonly IMapper _mapper;

        public GetSubmitionQueryHandler(ISubmissionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SubmissionDto> Handle(GetSubmissionQuery request, CancellationToken cancellationToken)
        {
            Submission submission = await _repository.GetSubmissionById(request.Id);
            SubmissionDto submissionDto = _mapper.Map<SubmissionDto>(submission);

            return submissionDto;
        }
    }
}
