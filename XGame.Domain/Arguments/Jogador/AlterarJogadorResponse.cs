using System;
using XGame.Domain.Entities;
using XGame.Domain.Resources;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {
        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
        public static explicit operator AlterarJogadorResponse(Entities.Jogador entity)
        {
            return new AlterarJogadorResponse()
            {
                Email = entity.Email.Endereco,
                Id = entity.Id,
                PrimeiroNome = entity.Nome.PrimeiroNome,
                UltimoNome = entity.Nome.UltimoNome,
                Message = ResourceMessage.Operacao_Realizada_Com_Sucesso
            };
        }
    }
}
