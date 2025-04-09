using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TextAnalyzeDZ
{
    internal class StreamReaderFile
    {
        public string ?path { get; set; }
        public string readText()
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs);
            var text = sr.ReadToEnd();
            fs.Close();
            
            return text;
        }

        public int countSentences(string text, CancellationToken token)
        {
            var sent = text.Count (c=> c=='.');
            Console.WriteLine($"Количество предложений: {sent}\n");
            return sent;
        }
        public int countSymbols(string text, CancellationToken token)
        {
            var symbols = text.Length;
            Console.WriteLine($"Количество символов: {symbols}\n");
            return symbols;
        }
        public int countWords(string text, CancellationToken token)
        {
            var words = text.Count(c => c == ' ');
            Console.WriteLine($"Количество слов: {words}\n");
            return words;
        }
        public int countQuestions(string text, CancellationToken token)
        {
            var quest = text.Count(c => c == '?');
            Console.WriteLine($"Количество вопросительных предложений: {quest}\n");
            return quest;
        }

        public int countExclamation(string text, CancellationToken token)
        {
            var excl = text.Count(c => c == '!');
            Console.WriteLine($"Количество восклицательных предложений: {excl}\n");
            return excl;
        }

        public StreamReaderFile (string path)
        {
            this.path = path;
        }
            
    }
}
