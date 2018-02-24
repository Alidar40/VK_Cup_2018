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
            Console.WriteLine((char)39);

            Level Head = new Level(null);
            Level CurrentLevel = Head;

            string s = Console.ReadLine();
            string[] stringArray = s.Split(new char[] { ' ', '.', ',', '?', '!', (char)39, '-'});

            foreach (string word in stringArray)
            {
                foreach (char c in word)
                {
                    int key = CharToInt(c);
                    if (CurrentLevel.ChekKey(key))
                    {

                    }
                }
            }

        }
        public static int CharToInt(char c)
        {
            return ((int)c) - 97;
        }
    }

    public class Level
    {
        Level[] NextLevelArray = new Level[26];
        int N = 0;
        Level PreviousLevel;
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
