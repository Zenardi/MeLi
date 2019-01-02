using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using meli.Controllers.Resources;
using meli.Models;
using meli.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meli.Controllers
{
    public class FeatureController : Controller
    {
        private readonly MeliDbContext context;
        private readonly IMapper mapper;
        public FeatureController(MeliDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();

            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}