using Application.Services.Interfaces;
using Application.Submitions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submitions.Queries
{
    public class GetSubmissionsByDateQuery : IRequest<List<SubmissionDto>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public GetSubmissionsByDateQuery(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (fromDate != null)
                FromDate = fromDate.Value;
            else
                FromDate = DateTime.MinValue;

            if (ToDate != null)
                ToDate = toDate.Value;
            else
                ToDate = DateTime.MaxValue;
        }

        public class GetSubmitionsByDateQueryHandler : IRequestHandler<GetSubmissionsByDateQuery, List<SubmissionDto>>
        {
            private readonly ISubmissionsRepository _repository;
            private readonly IMapper _mapper;
            public GetSubmitionsByDateQueryHandler(ISubmissionsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<List<SubmissionDto>> Handle(GetSubmissionsByDateQuery request, CancellationToken cancellationToken)
            {
                List<Submission> submitions = await _repository.GetSubmissionsByDate(request.FromDate, request.ToDate);
                List<SubmissionDto> submitionDtos = new List<SubmissionDto>();

                foreach (Submission submition in submitions)
                    submitionDtos.Add(_mapper.Map<SubmissionDto>(submition));

                return submitionDtos;
            }
        }
    }
}
