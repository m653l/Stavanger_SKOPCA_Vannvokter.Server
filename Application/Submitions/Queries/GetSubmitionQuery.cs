using Application.Services.Interfaces;
using Application.Submitions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submitions.Queries
{
    public class GetSubmitionQuery : IRequest<SubmitionDto>
    {
        public int Id { get; set; }

        public GetSubmitionQuery(int id) 
        {
            Id = id;
        }
    }

    public class GetSubmitionQueryHandler : IRequestHandler<GetSubmitionQuery, SubmitionDto>
    {
        private readonly ISubmitionsRepository _repository;
        private readonly IMapper _mapper;

        public GetSubmitionQueryHandler(ISubmitionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SubmitionDto> Handle(GetSubmitionQuery request, CancellationToken cancellationToken)
        {
            Submition submition = await _repository.GetSubmitionById(request.Id);
            SubmitionDto submitionDto = _mapper.Map<SubmitionDto>(submition);

            return submitionDto;
        }
    }
}
