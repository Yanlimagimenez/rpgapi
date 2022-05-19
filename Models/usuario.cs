using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace RpgApi.Models
{
    public class Usuario
    {
        
        
     //Atalho para a propriedade(Prop+tab)

     public int Id { get; set; }

     public string Username { get; set; }

     public byte[] PasswordHash { get; set; }

     public byte[] PasswordSalt { get; set; }

     public byte[] Foto { get; set; }

     public string Latitude { get; set; }

     public string Longitude { get; set; }

     public DateTime? DataAcesso { get; set; } //Using system;

     [NotMapped]//using System.ComponentModel.DataAnnotations.schema;

     public string PasswordString { get; set; }

     public List<Personagem> Personagens { get; set; } //using System.Collections.Generic;



    }
}