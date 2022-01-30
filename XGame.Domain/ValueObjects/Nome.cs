using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Resources;

namespace XGame.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        protected Nome()
        {

        }

        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 50, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Primeiro Nome", "3", "50"))
            .IfNullOrInvalidLength(x => x.UltimoNome, 3, 50, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Ultimo Nome", "3", "50"));
        }

        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }

        public override string ToString()
        {
            return string.Concat(PrimeiroNome, UltimoNome);
        }
    }
}
