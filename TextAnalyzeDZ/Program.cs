namespace TextAnalyzeDZ
{
    internal class Program
    {
        static async Task Main()
        {

            while (true)
            {
                Console.WriteLine("1 - Запустить анализ\n2 - Остановить\n3 - Выход\n\n");
                var key = Console.ReadLine();

                if (key == "1")
                {
                    cts = new CancellationTokenSource();
                    StartAnalysis(cts.Token);
                }
                else if (key == "2")
                {
                    cts.Cancel();
                    Console.WriteLine("Анализ остановлен.");
                }
                else if (key == "3")
                {
                    break;
                }
            }

        }
        private static CancellationTokenSource? cts;
        static void StartAnalysis(CancellationToken token)
        {
            Task.Run(() => AnalyzeText(token));
        }

        static void AnalyzeText(CancellationToken token)
        {
            if (File.Exists("E:\\STEP\\SystemProg\\DZ\\TextAnalyzeDZ\\TextAnalyzeDZ\\bin\\Debug\\net9.0\\1.txt"))
            {
                try
                {
                    var sr = new StreamReaderFile("E:\\STEP\\SystemProg\\DZ\\TextAnalyzeDZ\\TextAnalyzeDZ\\bin\\Debug\\net9.0\\1.txt");
                    var text = sr.readText();

                    Task.Run(() => sr.countSentences(text, token));
                    Task.Run(() => sr.countSymbols(text, token));
                    Task.Run(() => sr.countWords(text, token));
                    Task.Run(() => sr.countQuestions(text, token));
                    Task.Run(() => sr.countExclamation(text, token));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }


        }

    }
}

//3.Приложение для анализа текста
//Создайте приложение, которое использует механизм параллельных тасков. Приложение должно открывать большой текстовый файл,
//проанализировать текст, и вывести отчёт, который содержит информацию о:
//-Количестве предложений
//- Количестве символов
//- Количестве слов
//- Количестве вопросительных предложений
//- Количестве восклицательных предложений
//Отчёт должен быть отображён на экране, по мере готовности каждого таска.
//Также добавьте возможность остановки и повторного запуска анализа текста.