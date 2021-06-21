using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LetnjiBarController : ControllerBase
    {
       public BarContext Context { get; set; }

        public LetnjiBarController(BarContext context)
        {
            Context = context;
        }

        [Route("PreuzmiBarove")]
        [HttpGet]
        public async Task<List<LetnjiBar>> PreuzmiBarove()
        {
            return await Context.Barovi.Include(p => p.Lezaljke).Include(p => p.Porudzbine).ToListAsync();
        }

        [Route("UpisiBar")]
        [HttpPost]
        public async Task UpisiBar([FromBody] LetnjiBar bar)
        {
            Context.Barovi.Add(bar);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniBar")]
        [HttpPut]
        public async Task IzmeniBar([FromBody] LetnjiBar bar)
        {
            Context.Barovi.Update(bar);
            await Context.SaveChangesAsync();
        }

        [Route("ObrisiBar/{id}")]
        [HttpDelete]
        public async Task ObrisiBar(int id)
        {
            var bar = await Context.Barovi.FindAsync(id);
            Context.Barovi.Remove(bar);
            await Context.SaveChangesAsync();
        }

        [Route("ZauzmiLezaljku/{id}")]
        [HttpPost]
        public async Task ZauzmiLezaljku(int id, [FromBody] Lezaljka lez)
        {
           var bar = await Context.Barovi.FindAsync(id);
           lez.Bar = bar;
           Context.Lezaljke.Add(lez);
           await Context.SaveChangesAsync();
        }

        [Route("OslobodiLezaljku/{br}/{id}")]
        [HttpDelete]
        public async Task OslobodiLezaljku(int br, int id)
        {
           var lez = await Context.Lezaljke.Where(l => l.BrojLezaljke == br &&  l.Bar.IDBara == id).FirstOrDefaultAsync();
           Context.Lezaljke.Remove(lez);
           await Context.SaveChangesAsync();
        }

        [Route("IzmeniLezaljku/{br}/{ime}/{prezime}")]
        [HttpPut]
        public async Task IzmeniLezaljku(int br, string ime, string prezime)
        {
            var lez = await Context.Lezaljke.Where( l => l.BrojLezaljke == br).FirstOrDefaultAsync();           
            lez.Ime = ime;
            lez.Prezime = prezime;
            await Context.SaveChangesAsync();
        }

        [Route("DodajPorudzbinu{id}")]
        [HttpPost]
        public async Task DodajPorudzbinu(int id, [FromBody] Porudzbina porudzbina)
        {
           var bar = await Context.Barovi.FindAsync(id);
           porudzbina.Bar = bar;
           Context.Porudzbine.Add(porudzbina);           
           await Context.SaveChangesAsync();
        }

        [Route("OtkaziPorudzbinu/{br}")]
        [HttpDelete]
        public async Task OtkaziPorudzbinu(int br)
        {
            var porudzbina = await Context.Porudzbine.Where(p => p.IDPorudzbine == br).FirstOrDefaultAsync();
            Context.Porudzbine.Remove(porudzbina);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniPorudzbinu/{br}/{hrana}/{pice}")]
        [HttpPut]
        public async Task IzmeniPorudzbinu(int br, string hrana, string pice)
        {
            var porudzbina = await Context.Porudzbine.Where(p => p.IDPorudzbine == br).FirstOrDefaultAsync();           
            porudzbina.Hrana = hrana;
            porudzbina.Pice = pice;
            await Context.SaveChangesAsync();
        }


    }
}
