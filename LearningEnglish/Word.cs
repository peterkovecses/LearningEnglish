using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEnglish
{
    public class Word
    {
        public string HunName { get; set; }
        public string EngName { get; set; }

        public Word(string hunName, string engName)
        {
            HunName = hunName;
            EngName = engName;
        }
    }
}
