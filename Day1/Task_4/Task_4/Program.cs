using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Level Head = new Level(null);
            Level CurrentLevel = Head;


            string s = Console.ReadLine();
            s = "snow affects sports such as skiing, snowboarding, and snowmachine travel. snowboarding is a recreational activity and olympic and paralympic sport.";
            string[] stringArray = s.Split(new char[] { ' ', '.', ',', '?', '!', (char)39, '-'});

            int S = s.Length + 1;

            foreach (string word in stringArray)
            {
                if (word == "")
                    continue;
                bool newWord = false;
                int KeyLevel = 1;
                foreach (char c in word)
                {
                    int key = CharToInt(c);
                    if (!newWord && CurrentLevel.N > 1 && CurrentLevel.ChekKey(key))
                        KeyLevel++;
                    if (!newWord && CurrentLevel.ChekKey(key))
                    {
                        CurrentLevel = CurrentLevel.NextLevelArray[key];
                    }
                    else
                    {
                        CurrentLevel.NextLevelArray[key] = new Level(CurrentLevel);
                        CurrentLevel = CurrentLevel.NextLevelArray[key];
                        newWord = true;
                    }
                }
                if (newWord)
                {
                    CurrentLevel.Word = true;
                    CurrentLevel.AddedWord();
                }
                else if (word.Length > KeyLevel)
                {
                    if (KeyLevel == 0)
                        KeyLevel = 1;
                    S -= word.Length - KeyLevel;
                }
                CurrentLevel = Head;
            }
            Console.WriteLine(S);
            Console.Read();
        }
        public static int CharToInt(char c)
        {
            return ((int)c) - 97;
        }
    }

    public class Level
    {
        public Level[] NextLevelArray = new Level[26];
        public int N = 0;
        public Level PreviousLevel;
        public bool Word = false;

        public Level(Level PreviousLevel)
        {
            this.PreviousLevel = PreviousLevel;
        }

        public void AddLevel(char key)
        {
            NextLevelArray[CharToInt(key)] = new Level(this);
        }
        public int CharToInt(char c)
        {
            return ((int)c) - 97;
        }
        public void AddedWord()
        {
            N++;
            if (PreviousLevel != null)
                PreviousLevel.AddedWord();
        }
        public bool ChekKey(int key)
        {
            if (NextLevelArray[key] != null)
                return true;
            else
                return false;
        }
    }
}
