using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionar
{
    class Trivia
    {

        public Trivia(string json, int number)
        {
            JObject jObject = JObject.Parse(json);
            JToken jresults = jObject["results"];
            category = (string)jresults[number]["category"];
            type = (string)jresults[number]["type"];
            difficulty = (string)jresults[number]["difficulty"];
            question = (string)jresults[number]["question"];
            correct_answer = (string)jresults[number]["correct_answer"];

            incorrect_answers = jresults[number]["incorrect_answers"].ToArray();
        }




        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public Array incorrect_answers { get; set; }
    }
}
