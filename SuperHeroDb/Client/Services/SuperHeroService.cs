using SuperHeroDb.Shared;
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

        public List<Comic> Comics { get; set; } = new List<Comic>();
        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();

        public event Action Onchange;

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            var result = await _httpClient.PostAsJsonAsync("api/superhero/", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Onchange.Invoke();
            return Heroes;
        }

        public async Task GetComics()
        {
            Comics = await _httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
        }

        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            Heroes = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            return Heroes;
        }

        public async Task<List<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/superhero/{id}", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Onchange.Invoke();
            return Heroes;
        }
    }
}
