using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordleAPI.CQRS.Query;

namespace WordleAPI.Services.Interfaces
{
    public interface IWordleService
    {
        public List<string> GetValidWords(WordleQuery query, List<string> wordList);
    }
}
