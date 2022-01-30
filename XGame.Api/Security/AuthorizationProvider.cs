using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;

namespace XGame.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        } 

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            IServiceJogador serviceJogador = _container.Resolve<IServiceJogador>();

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            request.Email = context.UserName;
            request.Senha = context.Password;

            AutenticarJogadorResponse response =  serviceJogador.AutenticarJogador(request);

            if (serviceJogador.IsInvalid())
            {
                if(response == null)
                {
                    context.SetError("Invalid_grant", "jogador não encontrado!");
                    return;
                }
            }

            serviceJogador.ClearNotifications();

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //definindo as claims
            identity.AddClaim(new Claim("jogador", JsonConvert.SerializeObject(response)));

            var principal = new GenericPrincipal(identity, new string[] { });

            Thread.CurrentPrincipal = principal;

            context.Validated(identity); 
        }
    }
}