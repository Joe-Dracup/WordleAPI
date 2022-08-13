using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAPI.Repositories.Interfaces
{
    public interface IWordleRepo
    {
        public List<string> GetWordList();
    }
}
