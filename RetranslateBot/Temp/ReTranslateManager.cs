using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetranslateBot.Temp
{
    public class ReTranslateManager
    {
        private readonly Dictionary<char, char> _alphabetDictionary;

        private static ReTranslateManager _instance;
        public static ReTranslateManager Instance
        {
            get { return _instance ?? (_instance = new ReTranslateManager()); }
        }

        public ReTranslateManager()
        {
            _alphabetDictionary = new Dictionary<char, char>();
            FillAlphabet();
        }

        public string ReTranslate(string inputText)
        {
            var result = string.Empty;

            foreach (var currentChar in inputText)
            {
                var isUpperCase = char.IsUpper(currentChar);
                if (isUpperCase)
                {
                    var newChar = char.ToLower(currentChar);
                    if (_alphabetDictionary.ContainsKey(newChar))
                    {
                        result += char.ToUpper(_alphabetDictionary[newChar]);
                    }
                    else
                        result += currentChar;
                }
                else
                {
                    if (_alphabetDictionary.ContainsKey(currentChar))
                        result += _alphabetDictionary[currentChar];
                    else
                        result += currentChar;
                }
;            }

            return result;
        }

        private void FillAlphabet()
        {
            AddToAlphabet('q','й');
            AddToAlphabet('w','ц');
            AddToAlphabet('e','у');
            AddToAlphabet('r','к');
            AddToAlphabet('t','е');
            AddToAlphabet('y','н');
            AddToAlphabet('u','г');
            AddToAlphabet('i','ш');
            AddToAlphabet('o','щ');
            AddToAlphabet('p','з');
            AddToAlphabet('[','х');
            AddToAlphabet(']','ъ');
            AddToAlphabet('a','ф');
            AddToAlphabet('s','ы');
            AddToAlphabet('d','в');
            AddToAlphabet('f','а');
            AddToAlphabet('g','п');
            AddToAlphabet('h','р');
            AddToAlphabet('j','о');
            AddToAlphabet('k','л');
            AddToAlphabet('l','д');
            AddToAlphabet(';','ж');
            AddToAlphabet('z','я');
            AddToAlphabet('x','ч');
            AddToAlphabet('c','с');
            AddToAlphabet('v','м');
            AddToAlphabet('b','и');
            AddToAlphabet('n','т');
            AddToAlphabet('m','ь');
            AddToAlphabet(',','б');
            AddToAlphabet('.','ю');
            AddToAlphabet('/','.');
        }

        private void AddToAlphabet(char key, char value)
        {
            _alphabetDictionary.Add(key, value);
        }
        
    }
}