using Application.Services.Interfaces;
using Application.Submitions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submitions.Commands
{
    public record CreateSubmitionCommand(int producerId, CreateSubmitionDto Submition) : IRequest<int>
    { }

    public class CreateSubmitionCommandHandler : IRequestHandler<CreateSubmitionCommand, int>
    {

        private readonly IProducersRepository _producersRepository;
        private readonly IMapper _mapper;

        public CreateSubmitionCommandHandler(IProducersRepository producersRepository, IMapper mapper)
        {
            _producersRepository = producersRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSubmitionCommand request, CancellationToken cancellationToken)
        {
            int id = await _producersRepository.AddSubmitions(request.producerId, _mapper.Map<Submition>(request.Submition));

            return id;
        }
    }
}
