using System;
using System.Collections.Generic;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogador
{
    public class JogadorReponse
    {
        public Guid Id { get; set; }

        public string NomeCompleto { get;  set; }

        public string PrimeiroNome{ get;  set; }

        public string UltimoNome{ get;  set; }

        public string Email { get;  set; }


        public string Status { get;  set; }

        public JogadorReponse()
        {

        }

        public static explicit operator JogadorReponse(Entities.Jogador entidade)
        {
            return new JogadorReponse()
            {
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.ToString(),
               // Status = entidade.Status.ToString()
            };
        }
    }
}
