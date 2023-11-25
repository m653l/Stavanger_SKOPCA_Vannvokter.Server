using Application.Officials.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Officials.Commands
{
    public record UpdateOfficialCommand(UpdateOfficialDto Official) : IRequest<int>
    {
    }

    public class UpdateOfficialCommandHandler : IRequestHandler<UpdateOfficialCommand, int>
    {
        private readonly IGenericRepository<Official> _repository;
        private readonly IMapper _mapper;

        public UpdateOfficialCommandHandler(IGenericRepository<Official> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOfficialCommand request, CancellationToken cancellationToken)
        {
            Official currentEntity = await _repository.Get(request.Official.Id);
            Official updatedEntity = _mapper.Map(request.Official, currentEntity);

            await _repository.Update(updatedEntity);

            return updatedEntity.Id;
        }
    }
}
