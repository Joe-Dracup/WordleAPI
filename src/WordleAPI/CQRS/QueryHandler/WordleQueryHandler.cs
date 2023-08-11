using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordleAPI.Models.Query;
using WordleAPI.Models.Interfaces;

namespace WordleAPI.CQRS.QueryHandler
{
    public class WordleQueryHandler : IRequestHandler<WordleQuery, WordleQueryResult>
    {
        private readonly IWordleQueryValidator _validator;
        private readonly IWordleService _wordleService;
        private readonly IWordleRepo _wordleRepo;
        public WordleQueryHandler(IWordleQueryValidator validator, IWordleService worldeService, IWordleRepo wordleRepo)
        {
            _validator = validator;
            _wordleService = worldeService;
            _wordleRepo = wordleRepo;
        }

        public async Task<WordleQueryResult> Handle(WordleQuery request, CancellationToken cancellationToken)
        {
            var isValid = _validator.Validate(request);

            if (!isValid)
            {
                return new WordleQueryResult() { Result = false, ErrorCode = WordleErrorCode.InvalidRequest, ErrorMessage = "Please enter a valid set of letters", ValidWords = null };
            }

            var possibleWords = _wordleService.GetValidWords(request, _wordleRepo.GetWordList());

            return new WordleQueryResult() { ErrorCode = WordleErrorCode.None, ErrorMessage = "", Result = true, ValidWords = possibleWords };
        }
    }
}
