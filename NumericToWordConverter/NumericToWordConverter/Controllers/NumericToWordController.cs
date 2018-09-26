using NumericToWord.Entities;
using NumericToWord.Framework.Interface;
using NumericToWord.Repository.Contracts;
using System.Web.Mvc;

namespace NumericToWord.Controllers
{
    public class NumericToWordController : Controller
    {
        readonly IConverterRepository _converterRepository;
        readonly ILogger _logger;

        public NumericToWordController(ILogger logger, IConverterRepository converterRepository)
        {
            _logger = logger;
            _converterRepository = converterRepository;
        }
        // GET: NumberToWord
        public ActionResult NumericToWord()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult NumericToWordConverter(InputModel input)
        {
            _logger.WriteDebug("NumericToWordController - Index: Method Started");
            if (ModelState.IsValid && input.Number >= (decimal)0.01 && input.Number <= (decimal)999999999999999.99)
            {
                _logger.WriteDebug("NumericToWordController - Index: Convert input in service");
                ViewBag.Result = _converterRepository.ConvertNumberToWord(input.Number.ToString());
                _logger.WriteDebug("NumericToWordController - Index: Conversion Successful");
            }
            return View("NumberToWord");
        }
    }
}