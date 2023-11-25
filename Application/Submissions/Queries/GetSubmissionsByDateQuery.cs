using Application.Services.Interfaces;
using Application.Submissions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submissions.Queries
{
    public class GetSubmissionsByDateQuery : IRequest<List<SubmissionDto>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public GetSubmissionsByDateQuery(DateTime fromDate, DateTime toDate)
        {
            if (fromDate != default)
                FromDate = fromDate;
            else
                FromDate = DateTime.MinValue;

            if (toDate != default)
                ToDate = toDate;
            else
                ToDate = DateTime.MaxValue;
        }

        public class GetSubmissionsByDateQueryHandler : IRequestHandler<GetSubmissionsByDateQuery, List<SubmissionDto>>
        {
            private readonly ISubmissionsRepository _repository;
            private readonly IMapper _mapper;
            public GetSubmissionsByDateQueryHandler(ISubmissionsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<List<SubmissionDto>> Handle(GetSubmissionsByDateQuery request, CancellationToken cancellationToken)
            {
                List<Submission> Submissions = await _repository.GetSubmissionsByDate(request.FromDate, request.ToDate);
                List<SubmissionDto> SubmissionDtos = new List<SubmissionDto>();

                foreach (Submission Submission in Submissions)
                    SubmissionDtos.Add(_mapper.Map<SubmissionDto>(Submission));

                return SubmissionDtos;
            }
        }
    }
}
