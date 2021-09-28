﻿using SuperHeroDb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroDb.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;

        public SuperHeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

     

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            return await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
        }
    }
}
