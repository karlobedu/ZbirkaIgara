using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZbirkaIgara.Data;
using ZbirkaIgara.Models;
using ZbirkaIgara.Models.DTO;

namespace ZbirkaIgara.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class IgreController(ZbirkaIgaraContext context, IMapper mapper):BackendController(context,mapper)
    {
        [HttpGet]
		[Route("DohvatiSveIgre")]
		public ActionResult<List<IgraDTO>>GetSveIgre()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<IgraDTO>>(_context.Igre));

            }
            catch (Exception ex)
            {
            return BadRequest(new {poruka =ex.Message});
            }
        }
		[HttpGet]
		[Route("DohvatiIgru")]
		public ActionResult <IgraDTO> GetIgru(int IdIgre)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { poruka = ModelState });
			}
			try
			{
				var igra = _context.Igre.FirstOrDefault(igra => igra.Id == IdIgre);
				if (igra == null)
				{
					return NotFound(new { poruka = "Igra nije pronađena." });
				}
				return Ok(_mapper.Map<IgraDTO>(igra));
			}
			catch (Exception ex)
			{
				return BadRequest(new { poruka = ex.Message });
			}
		}
		[HttpGet]
		[Route("DohvatiIgruPoZanru")]
		public ActionResult<List<IgraDTO>> GetIgruPoZanru(int IdZanra)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { poruka = ModelState });
			}
			try
			{
				var igre = _context.Igre.Where(igra => igra.IdZanra == IdZanra).ToList();
				return Ok(_mapper.Map<List<IgraDTO>>(igre));
			}
			catch (Exception ex)
			{
				return BadRequest(new { poruka = ex.Message });
			}
		}
		[HttpPost]
		[Route("UpdateIgru")]
		public ActionResult<List<IgraDTO>> UpdateIgru(IgraDTO AzuriranaIgra)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { poruka = ModelState });
			}
			try
			{
				var igra = _context.Igre.Find(AzuriranaIgra.Id);
				if (igra == null)
				{
					return NotFound(new { poruka = "Igra nije pronađena." });
				}

				igra.Naslov = AzuriranaIgra.Naslov;
				igra.Opis = AzuriranaIgra.Opis;
				igra.Hltb = AzuriranaIgra.Hltb;
				igra.Ocjena = AzuriranaIgra.Ocjena;
				igra.Platforme = AzuriranaIgra.Platforme;
				igra.IdZanra = AzuriranaIgra.IdZanra;
				igra.Trailer = AzuriranaIgra.Trailer;
				igra.UrlSlike = AzuriranaIgra.UrlSlike;

                _context.SaveChanges();

				return Ok("Uspješno ažurirano!");
			}
			catch (Exception ex)
			{
				return BadRequest(new { poruka = ex.Message });
			}
		}
		[HttpPost]
		[Route("DodajIgru")]
		public ActionResult<IgraDTO> DodajIgru(IgraDTO novaIgra)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { poruka = ModelState });
			}
			try
			{
				var igra = _mapper.Map<Igra>(novaIgra);
				_context.Igre.Add(igra);
				_context.SaveChanges();
				return Ok(_mapper.Map<IgraDTO>(igra));
			}
			catch (Exception ex)
			{
				return BadRequest(new { poruka = ex.Message });
			}
		}

		[HttpDelete]
		[Route("ObrisiIgru")]
		public ActionResult ObrisiIgru(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { poruka = ModelState });
			}
			try
			{
				var igra = _context.Igre.Find(id);
				if (igra == null)
				{
					return NotFound(new { poruka = "Igra nije pronađena." });
				}
				_context.Igre.Remove(igra);
				_context.SaveChanges();
				return Ok("Igra je uspješno obrisana.");
			}
			catch (Exception ex)
			{
				return BadRequest(new { poruka = ex.Message });
			}
		}
	}
}
