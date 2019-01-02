using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using meli.Models;
using meli.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using meli.Controllers.Resources;

namespace meli.Controllers
{
    public class MakersController : Controller
    {
        private readonly MeliDbContext context;
        private readonly IMapper mapper;
        public MakersController(MeliDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/makers")]
        public async Task<IEnumerable<MakersResource>> GetMakers()
        {
            var makes =  await context.Makers.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Maker>, List<MakersResource>>(makes);
        }
    }
}