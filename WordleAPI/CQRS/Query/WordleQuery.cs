using MediatR;
using System.Collections.Generic;

namespace WordleAPI.CQRS.Query
{
    public class WordleQuery :  IRequest<WordleQueryResult>
    {
        public List<Letter> Letters { get; set; }
    }

    public class Letter
    {
        public char Char { get; set; }
        public int? KnownPos { get; set; }
        public List<int> KnownNotPos { get; set; }
    }

    public class WordleQueryResult
    {
        public bool Result { get; set; }
        public WordleErrorCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> ValidWords { get; set; }
    }

     public enum WordleErrorCode
    {
        None,
        InvalidRequest
    }
}
