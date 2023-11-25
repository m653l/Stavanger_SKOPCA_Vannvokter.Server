using Application.Services.Interfaces;
using Application.Submissions.Dtos;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Submissions.Commands
{
    public record CreateSubmissionCommand(int producerId, CreateSubmissionDto Submission) : IRequest<int>
    { }

    public class CreateSubmissionCommandHandler : IRequestHandler<CreateSubmissionCommand, int>
    {

        private readonly IProducersRepository _producersRepository;
        private readonly IMapper _mapper;

        public CreateSubmissionCommandHandler(IProducersRepository producersRepository, IMapper mapper)
        {
            _producersRepository = producersRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSubmissionCommand request, CancellationToken cancellationToken)
        {
            int id = await _producersRepository.AddSubmissions(request.producerId, _mapper.Map<Submission>(request.Submission));

            return id;
        }
    }
}
