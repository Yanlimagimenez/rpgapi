using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Utils;
using System.Collections.Generic;
using RpgApi.Models;
using RpgApi.Models.Enuns;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _Context;

        public UsuariosController(DataContext Context)
        {
            _Context = Context;
        }
       
       private async Task<bool> UsuariosExistente (string username)
       {
           if (await _Context.Usuarios.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
           {
               return true;
           }

           return false;
       }

  [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        { 
            try 
        {
            if (await UsuariosExistente(user.Username))
             throw new System.Exception("Nome de usuário já existe");
            
            Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[]salt);
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            await _Context.Usuarios.AddAsync(user);
            await _Context.SaveChangesAsync();

            return Ok(user.Id);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    

 [HttpPost("Autenticar")]

 public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)

  {
    try
    {

     Usuario usuario = await _Context.Usuarios
     .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

     if (usuario == null)
     {
         throw new System.Exception("Usuário não encontrado.");
     }
     else if (!Criptografia
     .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
     {
      throw new System.Exception("Senha Incorreta");   
     }
     else
     {
      return Ok(usuario.Id);
     }
  
    }
    catch (System.Exception ex)
    {
        return BadRequest(ex.Message);
    }


   }




    
    }
    
    }
