using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordleAPI.CQRS.Query;
using WordleAPI.Services.Interfaces;

namespace WordleAPI.Services.Concrete
{
    public class WordleService : IWordleService
    {
        public List<string> GetValidWords(WordleQuery query, List<string> wordList)
        {
            foreach (var letter in query.Letters)
            {
                if (letter.KnownPos != null)
                {
                    wordList = wordList.Where(s => s[(int)letter.KnownPos] == letter.Char).ToList();
                }
                else
                {
                    //CodeReview: move this into the validation logic to maintain single responsibility
                    if(letter.NotKnownPos.Count > 0)
                    {
                        foreach (var position in letter.NotKnownPos)
                        {
                            wordList = wordList.Where(s => s[position] != letter.Char).ToList();
                        }
                    }
                }

                //CodeReview: if letter is accounted for in all but one possible position, this is not reflected in the returned value
                //As below if "I" is not possible in all positions but index of 1, the above code will not reduce possible words
                //To only show words with an "I" at index of 1

                /*
                 {
	                "Letters":[
		                {
			                "Char": "f",
			                "KnownPos": 0,
			                "NotKnownPos": []
		                },
		                {
			                "Char": "i",
			                "KnownPos": null,
			                "NotKnownPos": [0,2,3,4]
		                }
	                ] 
                } 
                */
            }
            return wordList;
        }
    }
}
