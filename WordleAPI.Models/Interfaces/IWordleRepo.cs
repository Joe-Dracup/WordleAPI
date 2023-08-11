using System.Collections.Generic;

namespace WordleAPI.Models.Interfaces
{
    public interface IWordleRepo
    {
        public List<string> GetWordList();
    }
}
