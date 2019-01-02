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
    public class MakerController : Controller
    {
        private readonly MeliDbContext context;
        private readonly IMapper mapper;
        public MakerController(MeliDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/makers")]
        public async Task<IEnumerable<MakerResource>> GetMakes()
        {
            // var makes = await context.Makers.Include(m => m.Models).ToListAsync();
            var makers = await context.Makers.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Maker>, List<MakerResource>>(makers);
        }
    }
}