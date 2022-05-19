using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models.Enuns;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                Personagem Atacante = await _context.Personagens
                  .Include(p => p.Arma)
                  .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                  Personagem oponente = await _context.Personagens
                  .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

            int dano = Atacante.Arma.Dano + (new Random().Next(Atacante.Forca));

            dano = dano - new Random().Next(oponente.Defesa);

              if(dano > 0)
                oponente.PontosVida = oponente.PontosVida - (int)dano;
              if(oponente.PontosVida <= 0)
                d.Narracao = $"{oponente.Nome} foi derrotado!";

                _context.Personagens.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat(" Atacante : {0}. ", Atacante.Nome);
                dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                dados.AppendFormat(" Pontos de Vida: {0}. ", Atacante.PontosVida);
                dados.AppendFormat(" Oponente de Vida: {0}. ", oponente.PontosVida);
                dados.AppendFormat(" Arma Utilizada: {0}. ",Atacante.Arma.Nome);
                dados.AppendFormat(" Dano: {0}. ",dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.Disputas.Add(d);
                _context.SaveChanges();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Habilidade")]

        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {

                Personagem Atacante = await _context.Personagens
                .Include(p => p.PersonagemHabilidades) .ThenInclude(ph => ph.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem oponente = await _context.Personagens
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                PersonagemHabilidade ph = await _context.PersonagemHabilidades
                .Include(ph => ph.Habilidade)
                .FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId);

                if (ph==null)
                 d.Narracao = $"{Atacante.Nome} não possui esta habilidade";
                else
                {
                    int dano = ph.Habilidade.Dano + (new Random().Next(Atacante.Inteligencia));
                    dano = dano - new Random().Next(oponente.Defesa);

                    if(dano > 0)
                     oponente.PontosVida = oponente.PontosVida - dano;
                    if(oponente.PontosVida <= 0)
                     d.Narracao +=$"{oponente.Nome} foi derrotado!";
                    
                    _context.Personagens.Update(oponente);
                    await _context.SaveChangesAsync();

                    StringBuilder dados = new StringBuilder();
                    dados.AppendFormat(" Atacante: {0}. ",Atacante.Nome);
                    dados.AppendFormat(" Oponente: {0}. ",oponente.Nome);
                    dados.AppendFormat(" Pontos de vida do atacante: {0}. ",Atacante.PontosVida);
                    dados.AppendFormat(" Pontos de vida do oponente: {0}. ",oponente.PontosVida);
                    dados.AppendFormat(" Habilidade Utilizada: {0}. ",ph.Habilidade.Nome);
                    dados.AppendFormat(" Dano: {0}. ",dano);

                    d.Narracao += dados.ToString();
                    d.DataDisputa = DateTime.Now;
                    _context.Disputas.Add(d);
                    _context.SaveChanges();
                }


                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("PersonagemRandom")]
        
        public async Task<IActionResult> Sorteio()
        {
            List<Personagem> personagens = await _context.Personagens.ToListAsync();

            int sorteio = new Random().Next(personagens.Count);

            Personagem p = personagens[sorteio];

            string msg = string.Format("N Sorteado {0}. Personagem: {1}", sorteio, p.Nome);

            return Ok(msg);
        }
        
        [HttpGet("DisputaEmGrupo")]

        public async Task<IActionResult> DisputaEmGrupo (Disputa d)

        {
            try
            {
                List<Personagem> personagens = await _context.Personagens
                .Include(p => p.Arma)
                .Include(p => p.PersonagemHabilidades).ThenInclude(ph => ph.Habilidade)
                .Where(p => d.ListaIdPersonagens.Contains(p.Id)).ToListAsync();

                int qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;

                while (qtdPersonagensVivos > 1)
                {
                List<Personagem> atacantes = personagens.Where(p => p.PontosVida > 0).ToList();
                Personagem Atacante = atacantes[new Random().Next(atacantes.Count)];
                d.AtacanteId = Atacante.Id;

                List<Personagem> oponentes = personagens.Where(p => p.Id != Atacante.Id && p.PontosVida > 0).ToList();
                Personagem oponente = oponentes[new Random().Next(oponentes.Count)];
                d.OponenteId = oponente.Id;

            int dano = 0;
            string ataqueUsado = string.Empty;
            string resultado = string.Empty;

            bool ataqueUsaArma = (new Random().Next(1) == 0);

                if (ataqueUsaArma && Atacante.Arma != null)
                {  
                    dano = Atacante.Arma.Dano + (new Random().Next(Atacante.Forca));
                    dano = dano - new Random().Next(oponente.Defesa);
                    ataqueUsado = Atacante.Arma.Nome;

                    if (dano > 0)
                    oponente.PontosVida = oponente.PontosVida - (int)dano;

                    resultado = string.Format("{0} atacou {1} usado {2} com dano {3}." , Atacante.Nome, oponente.Nome, ataqueUsado, dano);
                    d.Narracao += resultado; 
                    d. Resultados .Add(resultado);



                } 

            else if (Atacante.PersonagemHabilidades.Count != 0)
                {
                    int sorteioHabilidadeId = new Random().Next(Atacante.PersonagemHabilidades.Count);
                    Habilidade habilidadeEscolhida = Atacante.PersonagemHabilidades [sorteioHabilidadeId].Habilidade;
                    ataqueUsado = habilidadeEscolhida.Nome;


                    

                    dano = habilidadeEscolhida.Dano + (new Random().Next(Atacante. Inteligencia));
                    dano = dano - new Random() .Next (oponente.Defesa);

                    if (dano > 0)

                    oponente.PontosVida = oponente.PontosVida - (int)dano;


                    resultado = 
                    string.Format("{0} atacou {1} usado {2} com dano {3}." , Atacante.Nome, oponente.Nome, ataqueUsado, dano);

                    d.Narracao += resultado;
                    d. Resultados .Add(resultado);
                }
                if (!string.IsNullOrEmpty(ataqueUsado))
                {
                    Atacante.Vitorias++;
                    oponente.Vitorias++;
                    Atacante.Disputa++;
                    oponente.Disputa++;

                    d.Id = 0;
                    d.DataDisputa = DateTime.Now;
                    _context.Disputas.Add(d);
                    await _context.SaveChangesAsync();
                }

                qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;

                if(qtdPersonagensVivos == 1)
                {
                    string resultadoFinal =
                     $"{Atacante.Nome.ToUpper()}é CAMPEÃO com {Atacante.PontosVida} pontos de vida!";
                    
                    d.Narracao += resultadoFinal;
                    d.Resultados.Add(resultadoFinal);

                    break;
                }

                }
                
                _context.Personagens.UpdateRange(personagens);
                await _context.SaveChangesAsync();

                return Ok (d);
            }
            catch(System.Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ApagarDisputas")] 
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
              List<Disputa> disputas = await _context.Disputas.ToListAsync();

              _context.Disputas.RemoveRange(disputas);
              await _context.SaveChangesAsync(); 

              return Ok("Disputas apagadas"); 
            }
            catch (System.Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.Disputas.ToListAsync(); 
                return Ok(disputas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
          

    }
}