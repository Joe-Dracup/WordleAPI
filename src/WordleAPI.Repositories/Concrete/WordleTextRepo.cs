using System.Collections.Generic;
using System.IO;
using WordleAPI.Models.Interfaces;

namespace WordleAPI.Repositories.Concrete
{
    public class WordleTextRepo : IWordleRepo
    {
        public List<string> GetWordList()
        {
            //CodeReview: this could be from appsettings
            var logFile = File.ReadAllLines(@"C:\Development\WordleAPI\src\WordleAPI.Repositories\Resources\Words.Txt");
            return new List<string>(logFile);
        }
    }
}
