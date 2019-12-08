using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class Bingo
    {
        static Random rnd = new Random();
        public List<int> numbers = new List<int>();

        public Bingo()
        {
            for (int i = 1; i < 90; i++)
            {
                numbers.Add(i);
            }
        }
        public int SelectRandomNumber() {
            int index;
            index = rnd.Next(1, numbers.Count());
            int selectedNumber = numbers[index];
            numbers.RemoveAt(index);
            return (selectedNumber);
        }
        
        public string[,] generateBingoCard(){
            string[,] arr = new string[3,9];
            List<int> numbers = new List<int>();            
            for (int ro = 0; ro < 3; ro++)
            {
                int numCount = 0;
                do
                {
                    int num = rnd.Next(1, 90);
                    int colIndex = num / 10;
                    if (colIndex < 0)
                    {
                        colIndex = 0;
                    }
                    if (arr[ro, colIndex] == null & !(numbers.Contains(num)))
                    {
                        arr[ro, colIndex] = num.ToString();
                        numbers.Add(num);
                        numCount++;
                    }
                
                } while (numCount < 5);
            }
            return (arr);
        }
        public string[,] GenerateUserBingoCard()
        {
            int[] rndnumbers = new int[15];
            string[,] numbers = new string[3, 9];
            for (int ro = 0; ro < 15; ro++)
            {
                var num = rnd.Next(1, 90);
                while (rndnumbers.Contains(num))
                {
                    num = rnd.Next(1, 90);
                }
                rndnumbers[ro] = num; 
            }
            // make it 3 x 9 
            for (int i = 0; i < 15; i++)
            {
                int rowIndex = i/5;
                int colIndex = rndnumbers[i]/11;
                numbers[rowIndex, colIndex] = rndnumbers[i].ToString();
            }
            return (numbers);
        }
    }
}