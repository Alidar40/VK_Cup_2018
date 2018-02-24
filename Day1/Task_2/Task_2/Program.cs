using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            int n = int.Parse(s.Split(' ')[0]);
            int k = int.Parse(s.Split(' ')[1]);
            Message[] MessageArray = new Message[n+1];

            s = Console.ReadLine();
            string[] sArray = s.Split(' ');
            MessageArray[0] = new Message(null, 0, 0, k);
            for (int i = 1; i <= n; i++)
            {
                int j = int.Parse(sArray[i-1]);
                MessageArray[i] = new Message(MessageArray[j], i, j, k);
            }


            for (int i = 1; i <= n-k; i++)
            {
                int j = MessageArray[i].indexOfPreviousElement;
                if (i - k > j + k)
                    MessageArray[i].S = MessageArray[i].PreviousElement.S + k * 2 + 1;
                else
                    MessageArray[i].S = MessageArray[i].PreviousElement.S + i - j;

                Console.Write(MessageArray[i].S + " ");
            }
            for (int i = n - k + 1; i <= n; i++)
            {
                int j = MessageArray[i].indexOfPreviousElement;
                if (i - k > j + k)
                    MessageArray[i].S = MessageArray[i].PreviousElement.S + n - (i - k) + 1;
                else if (j + k > n)
                    MessageArray[i].S = MessageArray[i].PreviousElement.S;
                else
                    MessageArray[i].S = MessageArray[i].PreviousElement.S + n - (j + k);

                Console.Write(MessageArray[i].S + " ");
            }

            Console.Read();
        }
    }
}

public class Message
{
    public Message PreviousElement;
    public int indexOfCurrentElement;
    public int indexOfPreviousElement;
    public int S = 0;

    public Message(Message Link, int CurrentElement, int PreviousElement, int k)
    {
        if (PreviousElement == 0)
            PreviousElement = -k;

        this.PreviousElement = Link;
        this.indexOfCurrentElement = CurrentElement;
        this.indexOfPreviousElement = PreviousElement;
    }
}