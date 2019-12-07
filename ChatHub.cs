using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        //skal sende list med ud til getbingonumbers
        public  List<int> bingoBoardNumbers = new List<int>();
        public void Send(string name, string message)
        {          
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void getBingoNumber()
        {
             Random rnd = new Random();
            int num = rnd.Next(1, 100);
            bingoBoardNumbers.Add(num);
            Clients.All.receiveBingoNumber(num);
        }
        public void CallBingo(string user)
        {
            string message = user + " has called Bingo. New game will start in 5 seconds";
            Clients.All.StartNewGame(message);
        }
        public void Send(string message)
        {
            string name;
            if (NumberGenerater.bingoNumbers.Count > 0)
            {
                name = "ChatBot";
                message = NumberGenerater.GetBingoNumber().ToString();
                Clients.All.broadcastMessage(name, message);
            }
            else
            {
                name = "GAME MASTER";
                message = "New Game has begun";
                NumberGenerater.StartGame();
                Clients.All.broadcastMessage(name, message);
                name = "ChatBot";
                message = NumberGenerater.GetBingoNumber().ToString();
                Clients.All.broadcastMessage(name, message);
            }           
        }
        public void Send()
        {
            string name = "GAME MASTER";
            string message = "New Game has begun";
            NumberGenerater.StartGame();
            Clients.All.broadcastMessage(name, message);
        }
       


        //public void GetBingoNumbers(string name, string message)
        //{
        //    name = "ChatBot";
        //    message = BingoGenerater.GetBingoNumber().ToString();
        //    Clients.All.broadcastMessage(name, message);
        //}
    }
}