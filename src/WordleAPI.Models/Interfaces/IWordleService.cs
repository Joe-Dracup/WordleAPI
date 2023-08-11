using System.Collections.Generic;
using WordleAPI.Models.Query;

namespace WordleAPI.Models.Interfaces
{
    public interface IWordleService
    {
        public List<string> GetValidWords(WordleQuery query, List<string> wordList);
    }
}
