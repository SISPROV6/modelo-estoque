using SpEst3Gerenciamento12.RegraNegocio;
using SpInfra4Generics.Models.Combobox;
using SpInfra5WSUtils.Filters;
using SpInfra5WSUtils.Session;
using SpInfra8Log;
using SpInfra9Utils.Exceptions.WebServicesException;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SpExemplo2PublicWS.Controllers.Pessoas
{
    //  Rota da API
    [RoutePrefix("api/Pessoas")]
    [UserAuthentication]
    public class PessoasController : ApiController
    {

        #region Private Methods



        #endregion Private Methods

        #region Public Methods

        #region GET

        [Route("GetPessoasCombobox")]
        [HttpGet]
        [ResponseType(typeof(RetGUIDRecordsCombobox))]
        [SwaggerResponse(HttpStatusCode.OK, "Execução com sucesso.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Erro de parâmetros.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Erro de servidor.")]
        public IHttpActionResult GetPessoasCombobox(
            [FromUri] string pesquisa = ""
            )
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

                Pessoas3Rn pessoasRn = new Pessoas3Rn(Session.DalConnections.DalBaseApl);
                ret.Data = pessoasRn.GetPessoasCombobox(pesquisa);

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
