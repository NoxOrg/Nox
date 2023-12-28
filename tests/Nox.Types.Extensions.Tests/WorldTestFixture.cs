using Microsoft.EntityFrameworkCore;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests;

public class WorldTestFixture
{
    public WorldTestFixture()
    {
        World.Countries.Load();
    }
}