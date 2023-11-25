using Application.Services.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Commands
{
    public class CreateTestCommand : IRequest
    {
        public Test Test { get; set; }

        public CreateTestCommand(Test test)
        {
            Test = test;
        }
    }

    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand>
    {
        private readonly IGenericRepository<Test> _repository;

        public CreateTestCommandHandler(IGenericRepository<Test> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(request.Test);
        }
    }
}
