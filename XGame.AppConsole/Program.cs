using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando");

            var service = new ServiceJogador();
            Console.WriteLine("Criei Instancia do servico");

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            Console.WriteLine("Criei Instancia do objeto request");
            request.Email = "cesar@cesar.com";
            var response = service.AutenticarJogador(request);


            if (service.IsInvalid())
            {
                service.Notifications.ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Message);
                });
            }

            Console.ReadKey();
        }
    }
}
