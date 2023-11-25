using Application.Officials.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Officials.Commands
{
    public record CreateOfficialCommand(OfficialDto Official) : IRequest<int>
    { }

    public class CreateOfficialCommandHandler : IRequestHandler<CreateOfficialCommand, int>
    {
        private readonly IGenericRepository<Official> _repository;
        private readonly IMapper _mapper;

        public CreateOfficialCommandHandler(IGenericRepository<Official> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOfficialCommand request, CancellationToken cancellationToken)
        {
            Official entity = _mapper.Map<Official>(request.Official);

            if (entity.Id == default)
                await _repository.Create(entity);
            else
                await _repository.Update(entity);

            return entity.Id;
        }
    }
}
