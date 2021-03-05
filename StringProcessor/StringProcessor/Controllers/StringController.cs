using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StringProcessor.Repository;

namespace StringProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {
        public StringController(IStringRepository stringRepository)
        {
            StringRepository = stringRepository;
        }

        public IStringRepository StringRepository { get; }

        // GET: api/String/ProcessStrings
        [HttpGet("ProcessStrings")]
        public ActionResult<IEnumerable<String>> ProcessStrings(List<String> originalStrings)
        {

            List<String> formatedStrings = StringRepository.ReplaceDollarSymbols(originalStrings);
            formatedStrings = StringRepository.RemoveNo4(formatedStrings);
            formatedStrings = StringRepository.RemoveUnderscore(formatedStrings);
            formatedStrings = StringRepository.RemoveDuplcateChars(formatedStrings);
            formatedStrings = StringRepository.TrucateStrings(formatedStrings);
            formatedStrings = StringRepository.RemoveNullEmptyStringMembers(formatedStrings);

            if (formatedStrings.Count == 0)
            {
                throw new ArgumentNullException("No items in array");
            }
            return formatedStrings;
        }
    }
}
