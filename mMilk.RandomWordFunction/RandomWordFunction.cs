using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RandomWordFunctionApp
{
    public static class RandomWordFunction
    {
        [FunctionName("RandomWord")]
        public async static Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request,
            ILogger logger, ExecutionContext context)
        {
            var word = await new WordGenerator(context.FunctionAppDirectory)
                .NextWordAsync()
                .ConfigureAwait(false);

            logger.LogInformation("Next: {word} ", word);

            return new OkObjectResult(word);
        }
    }
}
