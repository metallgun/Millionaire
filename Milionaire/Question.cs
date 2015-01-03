using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaire
{
    class Question
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string QuestionName { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public string RightAnswer { get; set; }
    }
}
