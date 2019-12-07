using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class Bingo
    {
        static Random rnd = new Random();
        List<int> numbers = new List<int>();

        public void generateList()
        {
            for (int i = 1; i < 90; i++)
            {
                numbers.Add(i);
            }
        }

        public void generateBingoCard(){
            List<int> ClientCard = new List<int>();


        }

    }
}