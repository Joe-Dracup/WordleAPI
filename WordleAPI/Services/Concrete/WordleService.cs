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
                    //Remove all words without letter in this pos
                    wordList = wordList.Where(s => s[(int)letter.KnownPos] == letter.Char).ToList();
                }
                else
                {
                    if (letter.KnownNotPos != null && letter.KnownNotPos.Count > 0)
                    {
                        //Ensure the letter is in the word
                        wordList = wordList.Where(s => s.Contains(letter.Char)).ToList();

                        foreach (var position in letter.KnownNotPos)
                        {
                            //Remove words where letter is in the wrong pos
                            wordList = wordList.Where(s => s[position] != letter.Char).ToList();
                        }
                    }
                }
            }
            return wordList;
        }
    }
}
