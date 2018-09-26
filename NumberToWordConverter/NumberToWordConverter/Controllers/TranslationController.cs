using Microsoft.Web.Http;
using NumericToWord.Entities;
using NumericToWord.Framework.Interface;
using NumericToWord.Repository.Contracts;
using System;
using System.Net;
using System.Web.Http;

namespace NumericToWord.Controllers
{
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:apiVersion}/convert")]
    public class TranslationController : ApiController
    {
        readonly IConverterRepository _converterRepository;
        readonly ILogger _logger;

        public TranslationController(ILogger logger, IConverterRepository converterRepository)
        {
            _logger = logger;
            _converterRepository = converterRepository;
        }
        //Api to convert to number
        [HttpPost]
        [Route("number")]
        public IHttpActionResult ConvertNumber(InputModel input)
        {
            try
            {
                _logger.WriteDebug("ConversionController - ConvertNumber: Method Started");
                if (ModelState.IsValid && input.Number >= Constants.MinLimit && input.Number <= Constants.MaxLimit)
                {
                    _logger.WriteDebug("ConversionController - ConvertNumber: Convert input in service");
                    var output = _converterRepository.ConvertToWord(input);
                    _logger.WriteDebug("ConversionController - ConvertNumber: Conversion Successful");
                    return Ok(new Response<OutputModel>()
                    {
                        Success = output != null,
                        Data = output,
                        ErrorCode = output == null ? (int?)HttpStatusCode.NoContent : null,
                        ErrorMessage = output == null ? Convert.ToString(HttpStatusCode.NoContent) : string.Empty
                    });
                }
                else
                {
                    _logger.WriteError("ConversionController - ConvertNumber: Bad Request. Method Ended");
                    return Ok(new Response<string>()
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ErrorMessage = Constants.GenericErrorMessage
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("ConversionController - ConvertNumber: Method Failed. Error Details: " + ex.Message, ex);
                return Ok(new Response<string>()
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = Constants.GenericErrorMessage
                });
            }
        }
    }
}