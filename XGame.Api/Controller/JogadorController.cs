using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controller.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controller
{
    //cgmae.com.br/api/jogador

    [RoutePrefix("api/jogador")]
    public class JogadorController : ControllerBase
    {
        private readonly IServiceJogador _serviceJogador;

        public JogadorController(IUnityOfWork unityOfWork, IServiceJogador serviceJogador) : base(unityOfWork)
        {
            _serviceJogador = serviceJogador;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogadorRequest request)
        {
            try
            {
                var response = _serviceJogador.AdicionarJogador(request);

                if(response == null)
                {
                    return await ResponseAsync(_serviceJogador.Notifications, _serviceJogador);
                }

                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                });
                //return await ResponseAsync(response.Message, _serviceJogador);
            }
            catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceJogador.ListarJogador();

                if (response == null)
                {
                    return await ResponseAsync(_serviceJogador.Notifications, _serviceJogador);
                }

                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                });

                //return await ResponseAsync(response, _serviceJogador);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}