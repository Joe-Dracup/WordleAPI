using System.Collections.Generic;
using System.IO;
using WordleAPI.Repositories.Interfaces;

namespace WordleAPI.Repositories.Concrete
{
    public class WordleTextRepo : IWordleRepo
    {
        public List<string> GetWordList()
        {
            //CodeReview: this could be from appsettings
            var logFile = File.ReadAllLines(@"C:\Development\WordleAPI\WordleAPI.Repositories\Resources\Words.Txt");
            return new List<string>(logFile);
        }
    }
}
