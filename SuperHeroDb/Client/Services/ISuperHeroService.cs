using SuperHeroDb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDb.Client.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetSuperHeroes();
    }
}
