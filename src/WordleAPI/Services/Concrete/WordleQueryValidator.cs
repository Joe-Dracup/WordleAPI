using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordleAPI.CQRS.Query;
using WordleAPI.Services.Interfaces;

namespace WordleAPI.Services.Concrete
{
    public class WordleQueryValidator : IWordleQueryValidator
    {
        //CodeReview: return an object with a bool and a string to show why this has failed validation
        public bool Validate(WordleQuery query)
        {
            var maxLetters = 5;
            var isValid = true;

            if (query.Letters.Count <= 0 || query.Letters.Count > maxLetters)
            {
                isValid = false;
            }

            foreach (var item in query.Letters)
            {
                if (item.KnownNotPos != null)
                {
                    if (item.KnownNotPos.Count > maxLetters)
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }
    }
}
