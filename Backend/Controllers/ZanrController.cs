using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZbirkaIgara.Data;
using ZbirkaIgara.Models.DTO;
using ZbirkaIgara.Models;

namespace ZbirkaIgara.Controllers
{
	
		[ApiController]
		[Route("api/v1/[controller]/")]
		public class ZanrController(ZbirkaIgaraContext context, IMapper mapper) : BackendController(context, mapper)
		{
			[HttpGet]
			[Route("DohvatiSveZanrove")]
			public ActionResult<List<ZanrDTO>> GetSveZanrove()
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(new { poruka = ModelState });
				}
				try
				{
					return Ok(_mapper.Map<List<ZanrDTO>>(_context.Zanrovi));

				}
				catch (Exception ex)
				{
					return BadRequest(new { poruka = ex.Message });
				}
			}
			[HttpGet]
			[Route("DohvatiZanr")]
			public ActionResult<ZanrDTO> GetZanr(int IdZanra)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(new { poruka = ModelState });
				}
				try
				{
					var zanr = _context.Igre.FirstOrDefault(zanr => zanr.Id == IdZanra);
					if (zanr == null)
					{
						return NotFound(new { poruka = "Žanr nije pronađena." });
					}
					return Ok(_mapper.Map<ZanrDTO>(zanr));
				}
				catch (Exception ex)
				{
					return BadRequest(new { poruka = ex.Message });
				}
			}
			[HttpPost]
			[Route("UpdateZanr")]
			public ActionResult<List<ZanrDTO>> UrediZanr(ZanrDTO AzuriranZanr)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(new { poruka = ModelState });
				}
				try
				{
					var zanr = _context.Zanrovi.Find(AzuriranZanr.Id);
					if (zanr == null)
					{
						return NotFound(new { poruka = "Igra nije pronađena." });
					}
				zanr.ImeZanra = AzuriranZanr.ImeZanra;

					_context.SaveChanges();

					return Ok("Uspješno ažurirano!");
				}
				catch (Exception ex)
				{
					return BadRequest(new { poruka = ex.Message });
				}
			}
			[HttpPost]
			[Route("DodajZanr")]
			public ActionResult<ZanrDTO> DodajZanr(ZanrDTO noviZanr)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(new { poruka = ModelState });
				}
				try
				{
					var zanr = _mapper.Map<Zanr>(noviZanr);
					_context.Zanrovi.Add(zanr);
					_context.SaveChanges();
					return Ok(_mapper.Map<ZanrDTO>(zanr));
				}
				catch (Exception ex)
				{
					return BadRequest(new { poruka = ex.Message });
				}
			}
		//potrebno jos azurirati da se obrise zanr i u igrama
			[HttpDelete]
			[Route("ObrisiZanr")]
			public ActionResult ObrisiZanr(int id)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(new { poruka = ModelState });
				}
				try
				{
					var zanr = _context.Zanrovi.Find(id);
					if (zanr == null)
					{
						return NotFound(new { poruka = "Zanr nije pronađen." });
					}
					_context.Zanrovi.Remove(zanr);
					_context.SaveChanges();
					return Ok("Zanr je uspješno obrisan.");
				}
				catch (Exception ex)
				{
					return BadRequest(new { poruka = ex.Message });
				}
			}
		}
	}
