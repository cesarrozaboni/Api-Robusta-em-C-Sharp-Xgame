using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Domain.Interfaces.Services.Base;
using XGame.Infra.Transactions;

namespace XGame.Api.Controller.Base
{
    public class ControllerBase : ApiController
    {
        private readonly IUnityOfWork _unitiOfWork;
        private IServiceBase _serviceBase;

        public ControllerBase(IUnityOfWork unitiOfWork)
        {
            _unitiOfWork = unitiOfWork;
        }

        public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (serviceBase.Notifications.Any())
            {
                try
                {
                    _unitiOfWork.Commit();
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
                }catch(Exception ex)
                {
                    //aqui devo logar o erro
                    return Request.CreateResponse(System.Net.HttpStatusCode.Conflict, $"Houve um problema interno com o servidor");
                }
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { errors = serviceBase.Notifications });
            }
        }

        public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception ex)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            //realiza o dispose no serviço para que possa ser zerada as notificações
            if(_serviceBase != null)
            {
                _serviceBase.Dispose();
            }

            base.Dispose(disposing);
            
        }
    }
}