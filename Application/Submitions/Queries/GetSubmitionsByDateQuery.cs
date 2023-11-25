using Application.Services.Interfaces;
using Application.Submitions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submitions.Queries
{
    public class GetSubmitionsByDateQuery : IRequest<List<SubmitionDto>>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public GetSubmitionsByDateQuery(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (fromDate != null)
                FromDate = fromDate;
            else
                FromDate = DateTime.MinValue;

            if (ToDate != null)
                ToDate = toDate;
            else
                ToDate = DateTime.MaxValue;
        }

        public class GetSubmitionsByDateQueryHandler : IRequestHandler<GetSubmitionsByDateQuery, List<SubmitionDto>>
        {
            private readonly ISubmitionsRepository _repository;
            private readonly IMapper _mapper;
            public GetSubmitionsByDateQueryHandler(ISubmitionsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public Task<List<SubmitionDto>> Handle(GetSubmitionsByDateQuery request, CancellationToken cancellationToken)
            {
                List<Submition> submitions = await _repository.GetSubmitionsByDate(request.FromDate, request.ToDate);
                List<SubmitionDto> submitionDtos = new List<SubmitionDto>();

                foreach (Submition submition in submitions)
                    submitionDtos.Add(_mapper.Map<SubmitionDto>(submition));

                return submitionDtos;
            }
        }
    }
}
