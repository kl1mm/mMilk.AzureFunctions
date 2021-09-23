using System;
using System.IO;
using System.Threading.Tasks;

namespace RandomWordFunctionApp
{
    internal class WordGenerator
    {
        private static Random rnd = new Random();
        private readonly string appDirectory;

        public WordGenerator(string appDirectory) => this.appDirectory = appDirectory;

        internal async Task<string> NextWordAsync()
        {
            var filePath = Path.Combine(appDirectory, "wortlist.txt");
            var words = await File.ReadAllLinesAsync(filePath).ConfigureAwait(false);
            return words[rnd.Next(0, words.Length)];
        }
    }
}
