using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AlexaBackendAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public SkillResponse Post([FromBody]SkillRequest request)
        {
            SkillResponse response = null;
            if (request != null)
            {
                PlainTextOutputSpeech outputSpeech = new PlainTextOutputSpeech();
                string firstName = (request.Request as IntentRequest)?.Intent.Slots.FirstOrDefault(s => s.Key == "FirstName").Value.Value;
                outputSpeech.Text = "Hello " + firstName;
                response = ResponseBuilder.Tell(outputSpeech);
            }

            return response;
        }
    }
}
