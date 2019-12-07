using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    
    public static class NumberGenerater
    {
        public static List<int> bingoNumbers = new List<int>();
        
        private static void FillTheList()
        {
            for (int i = 0; i < 99; i++)
            {
                bingoNumbers.Add(i);
            }
        }

        private static void NewList()
        {
            List<int> emptyList = new List<int>();
            bingoNumbers = emptyList;
        }

        public static void StartGame()
        {
            NewList();
            FillTheList();
        }

        public static int GetBingoNumber()
        {  
            Random rnd = new Random();
            int numberToWorkWith = rnd.Next(1, bingoNumbers.Count);
            int numberToReturn = bingoNumbers[numberToWorkWith];
            bingoNumbers.RemoveAt(numberToWorkWith);
            return numberToReturn;
        }
    }
}