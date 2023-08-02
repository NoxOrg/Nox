// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ODataNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Create{{entity.Name}}Command() : IRequest<O{{entity.Name}}>;

public class Create{{entity.Name}}CommandHandler: IRequestHandler<Create{{entity.Name}}Command, O{{entity.Name}}>
{
    public  Create{{entity.Name}}CommandHandler({{codeGeneratorState.Solution.Name}}DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

    public async Task<O{{entity.Name}}> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(O{{entity.Name}})!;
    }
}