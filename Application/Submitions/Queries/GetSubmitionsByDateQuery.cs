using Application.Services.Interfaces;
using Application.Submitions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submitions.Queries
{
    public class GetSubmitionsByDateQuery : IRequest<List<SubmitionDto>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public GetSubmitionsByDateQuery(DateTime? fromDate = null, DateTime? toDate = null)
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

        public class GetSubmitionsByDateQueryHandler : IRequestHandler<GetSubmitionsByDateQuery, List<SubmitionDto>>
        {
            private readonly ISubmissionsRepository _repository;
            private readonly IMapper _mapper;
            public GetSubmitionsByDateQueryHandler(ISubmissionsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<List<SubmitionDto>> Handle(GetSubmitionsByDateQuery request, CancellationToken cancellationToken)
            {
                List<Submission> submitions = await _repository.GetSubmissionsByDate(request.FromDate, request.ToDate);
                List<SubmitionDto> submitionDtos = new List<SubmitionDto>();

                foreach (Submission submition in submitions)
                    submitionDtos.Add(_mapper.Map<SubmitionDto>(submition));

                return submitionDtos;
            }
        }
    }
}
