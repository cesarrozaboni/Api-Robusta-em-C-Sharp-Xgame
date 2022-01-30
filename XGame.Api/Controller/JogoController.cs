using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controller.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controller
{
    //cgmae.com.br/api/jogador

    [RoutePrefix("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly IServiceJogo _serviceJogo;

        public JogoController(IUnityOfWork unityOfWork, IServiceJogo serviceJogo) : base(unityOfWork)
        {
            _serviceJogo = serviceJogo;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AdicionarJogo(request);

                if(response == null)
                {
                    return await ResponseAsync(response, _serviceJogo);
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

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AlterarJogo(request);

                if (response == null)
                {
                    return await ResponseAsync(response, _serviceJogo);
                }

                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                });
                //return await ResponseAsync(response.Message, _serviceJogador);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Excluir")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Excluir(Guid id)
        {
            try
            {
                var response = _serviceJogo.ExcluirJogo(id);

                if (response == null)
                {
                    return await ResponseAsync(response, _serviceJogo);
                }

                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                });
                //return await ResponseAsync(response.Message, _serviceJogador);
            }
            catch (Exception ex)
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
                var response = _serviceJogo.ListarJogo();

                if (response == null)
                {
                    return await ResponseAsync(_serviceJogo.Notifications, _serviceJogo);
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