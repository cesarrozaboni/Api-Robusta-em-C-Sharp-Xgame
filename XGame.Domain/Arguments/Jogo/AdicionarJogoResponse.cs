using System;
using XGame.Domain.Resources;

namespace XGame.Domain.Arguments.Jogo
{
    public class AdicionarJogoResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AdicionarJogoResponse(Entities.Jogo entidade)
        {
            return new AdicionarJogoResponse()
            {
                Id = entidade.Id,
                Message = ResourceMessage.Operacao_Realizada_Com_Sucesso
            };
        }
    }
}
