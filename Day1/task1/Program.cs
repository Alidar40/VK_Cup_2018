using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static bool Check(string _s, string _existingLogin)
        {
            if (_s.Length != _existingLogin.Length)
            {
                return false;
            }

            var length = _s.Length;
            bool key = false;
            bool[] checker = new bool[length];

            for (int _i = 0; _i < length; _i++)
            {

                if (Char.ToUpper(_s[_i]) == _existingLogin[_i] && _s[_i] != '_' && !(_s[_i] >= 48 && _s[_i] <= 57))
                {
                    checker[_i] = true;
                    continue;
                }

                if (Char.ToLower(_s[_i]) == _existingLogin[_i] && _s[_i] != '_' && !_s.Any(char.IsDigit))
                {
                    checker[_i] = true;
                    continue;
                }

                if ((_s[_i] == 'o' || _s[_i] == 'O') && _existingLogin[_i] == '0')
                {
                    checker[_i] = true;
                    continue;
                }

                if (_s[_i] == '0' && (_existingLogin[_i] == 'o' || _existingLogin[_i] == 'O'))
                {
                    checker[_i] = true;
                    continue;
                }

                if (_s[_i] == '1' && (_existingLogin[_i] == 'l' || _existingLogin[_i] == 'L'))
                {
                    checker[_i] = true;
                    continue;
                }

                if ((_s[_i] == 'l' || _s[_i] == 'L') && _existingLogin[_i] == '1')
                {
                    checker[_i] = true;
                    continue;
                }

                if (_s[_i] == '1' && (_existingLogin[_i] == 'i' || _existingLogin[_i] == 'I'))
                {
                    checker[_i] = true;
                    continue;
                }

                if ((_s[_i] == 'i' || _s[_i] == 'I') && _existingLogin[_i] == '1')
                {
                    checker[_i] = true;
                    continue;
                }

                if ((_s[_i] == 'l' || _s[_i] == 'L') && (_existingLogin[_i] == 'i' || _existingLogin[_i] == 'I'))
                {
                    checker[_i] = true;
                    continue;
                }

                if ((_s[_i] == 'i' || _s[_i] == 'I') && (_existingLogin[_i] == 'l' || _existingLogin[_i] == 'L'))
                {
                    checker[_i] = true;
                    continue;
                }

                if (_s[_i] == _existingLogin[_i])
                {
                    checker[_i] = true;
                    continue;
                }

                if (_s[_i] != _existingLogin[_i])
                {
                    checker[_i] = false;
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            string s = string.Empty;
            int n = 0;
            bool IsAcceptable = true;

            s = Console.ReadLine();

            n = int.Parse(Console.ReadLine());

            var login_db = new List<string>(); 

            for(int i = 0; i < n; i++)
            {
                login_db.Add(Console.ReadLine());
            }

            foreach(var login in login_db)
            {
                if (Check(s, login))
                {
                    IsAcceptable = false;
                }

            }

            if(IsAcceptable == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            

            Console.ReadKey();
        }
    }
}
