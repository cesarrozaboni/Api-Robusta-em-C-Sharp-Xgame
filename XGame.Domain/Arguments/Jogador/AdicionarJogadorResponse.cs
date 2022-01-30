using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;
using XGame.Domain.Resources;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }


        public string Message { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entity)
        {
            return new AdicionarJogadorResponse()
            {
                Id = entity.Id,
                Message = ResourceMessage.Operacao_Realizada_Com_Sucesso
            };
        }
    }
}
