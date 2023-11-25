using Application.Services.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Commands
{
    public class GetTestCommand : IRequest<Test>
    {
        public int Id { get; set; }

        public GetTestCommand(int id)
        {
            Id = id;
        }
    }

    public class GetTestCommandHandler : IRequestHandler<GetTestCommand, Test>
    {
        private readonly IGenericRepository<Test> _testRepository;

        public GetTestCommandHandler(IGenericRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }

        async Task<Test> IRequestHandler<GetTestCommand, Test>.Handle(GetTestCommand request, CancellationToken cancellationToken)
        {
            Test? record = await _testRepository.Get(request.Id);

            if (record is null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            return record;
        }
    }
}
