using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

using Swashbuckle.Swagger.Annotations;

using SpInfra5WSUtils.Filters;
using SpInfra5WSUtils.Session;
using SpInfra8Log;
using SpInfra9Utils.Exceptions.WebServicesException;
using SpInfra4Generics.Models.Combobox;
using SpEst3Gerenciamento.RegraNegocio;

namespace SpExemplo2PublicWS.Controllers
{
    //  Rota da API
    [RoutePrefix("api/EstCategoriaProduto")]
    [UserAuthentication]
    public class EstCategoriaProdutoController : ApiController
    {

        #region Public Methods

        #region GET

        [Route("GetCategorisCombobox")]
        [HttpGet]
        [ResponseType(typeof(RetGUIDRecordsCombobox))]
        [SwaggerResponse(HttpStatusCode.OK, "Execução com sucesso.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Erro de parâmetros.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro de servidor.")]
        public IHttpActionResult GetCategorisCombobox()
        {
            long idLog = 0;

            RetGUIDRecordsCombobox ret = new RetGUIDRecordsCombobox()
            {
                Error = false,
                ErrorMessage = string.Empty
            };

            try
            {
                idLog = Log.LogWs.WriteLog(Session.DalConnections.DalBaseLog, System.Reflection.MethodBase.GetCurrentMethod());

                CategoriasProduto3Rn categoriasProdutoRn = new CategoriasProduto3Rn(Session.DalConnections.DalBaseApl);
                ret.Data = categoriasProdutoRn.GetCategoriasCombobox();

                Log.LogWs.WriteLogOk(Session.DalConnections.DalBaseLog, idLog);
            }
            catch (WebServiceException ex)
            {
                Log.LogWs.WriteLogError(Session.DalConnections.DalBaseLog, idLog, ex);

                ret.Error = true;
                ret.ErrorMessage = ex.Message;

                // Erro de usuário recebe mensagem com status 200 (erro tratado)
                if (ex.ErrorType == WebServiceExceptionType.USER_OK)
                {
                    return Content(HttpStatusCode.OK, ret);
                }
                // Erro de usuário recebe mensagem com status 400
                if (ex.ErrorType == WebServiceExceptionType.USER_ERROR)
                {
                    return Content(HttpStatusCode.BadRequest, ret);
                }
                // Senão considera-se erro de servidor.
                return Content(HttpStatusCode.InternalServerError, ret);
            }
            catch (Exception ex)
            {
                Log.LogWs.WriteLogError(Session.DalConnections.DalBaseLog, idLog, ex);

                ret.Error = true;
                ret.ErrorMessage = ex.Message;

                // Erro tratado
                return Content(HttpStatusCode.OK, ret);
            }

            return Ok(ret);
        }

        #endregion GET

        #endregion Public Methods

    }
}
