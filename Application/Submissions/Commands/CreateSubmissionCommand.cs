using Application.Services.Interfaces;
using Application.Submissions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submissions.Commands
{
    public record CreateSubmitionCommand(int producerId, CreateSubmissionDto Submission) : IRequest<int>
    { }

    public class CreateSubmissionCommandHandler : IRequestHandler<CreateSubmitionCommand, int>
    {

        private readonly IProducersRepository _producersRepository;
        private readonly IMapper _mapper;

        public CreateSubmissionCommandHandler(IProducersRepository producersRepository, IMapper mapper)
        {
            _producersRepository = producersRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSubmitionCommand request, CancellationToken cancellationToken)
        {
            int id = await _producersRepository.AddSubmitions(request.producerId, _mapper.Map<Submission>(request.Submission));

            return id;
        }
    }
}
