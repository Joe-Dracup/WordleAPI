using WordleAPI.Models.Query;

namespace WordleAPI.Models.Interfaces
{
    public interface IWordleQueryValidator
    {
        public bool Validate(WordleQuery query);
    }
}
