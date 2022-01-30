using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }

        public int Status { get; set; }

        public string Email { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entity)
        {
            return new AutenticarJogadorResponse()
            {
                Id = entity.Id,
                Email = entity.Email.Endereco,
                PrimeiroNome = entity.Nome.PrimeiroNome,
                Status = (int)entity.Status
            };     
        }

     
    }
}
