﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using EmailAddress = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public record AddEmailAddressCommand(StoreKeyDto ParentKeyDto, EmailAddressCreateDto EntityDto, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;

public partial class AddEmailAddressCommandHandler: CommandBase<AddEmailAddressCommand, EmailAddress>, IRequestHandler <AddEmailAddressCommand, EmailAddressKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<EmailAddress,EmailAddressCreateDto> _entityFactory;

	public AddEmailAddressCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<EmailAddress,EmailAddressCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<EmailAddressKeyDto?> Handle(AddEmailAddressCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nuid>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.EmailAddress = entity;
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmailAddressKeyDto();
	}
}