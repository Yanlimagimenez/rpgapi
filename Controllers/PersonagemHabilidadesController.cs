using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models.Enuns;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult>  AddPersonagemHabilidade(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {
                Personagem personagem = await _context.Personagens.Include(p => p.Arma)
                .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);
                
                if(personagem == null)
                {
                    throw new System.Exception("Personagem não encontrado para Id infromado");
                   
                } 

                Habilidade habilidade = await _context.Habilidades.FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if(habilidade == null)
                {
                    throw new System.Exception("Habilidade não encontrada");
                }
                
                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.PersonagemHabilidades.AddAsync(ph);

                
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
    [HttpGet("{id}")] //Busca pelo id

    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            Personagem p = await _context.Personagens
              .Include(ar => ar.Arma)//Inclui na propriedade
              .Include(ph => ph.PersonagemHabilidades)
              .ThenInclude(h => h.Habilidade)//Inclui na lista de personagemHabilidade de p
              .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

              return Ok(p);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }




        
    
    }
}