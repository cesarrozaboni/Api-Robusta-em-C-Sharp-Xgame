using System;

namespace XGame.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = Resources.ResourceMessage.Operacao_Realizada_Com_Sucesso;
        }
        public string Message { get; set; }

        public static explicit operator ResponseBase(Entities.Jogo jogo)
        {
            return new ResponseBase()
            {
                Message = Resources.ResourceMessage.Operacao_Realizada_Com_Sucesso
            };
        }
    }
}
