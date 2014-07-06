using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge170Easy.Cards;

namespace Challenge170Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlayers = Int32.Parse(Console.ReadLine());
            List<Player> players = GetPlayers(numberOfPlayers);

            try
            {
                Player winning = GetFiveCardTrickWinner(players);

                if (winning != null)
                {
                    Console.WriteLine("{0} has won with a 5-card trick!", winning.Name);
                }
                else
                {
                    winning = GetNormalWinner(players);

                    if (winning != null)
                    {
                        Console.WriteLine("{0} has won!", winning.Name);
                    }
                    else
                    {
                        Console.WriteLine("Everyone has bust, there are no winners.");
                    }
                }
            }
            catch (DrawException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static List<Player> GetPlayers(int count)
        {
            List<Player> players = new List<Player>(count);
            for (int i = 0; i < count; i++)
            {
                players.Add(new Player(Console.ReadLine()));
            }

            return players;
        }

        static Player GetFiveCardTrickWinner(IEnumerable<Player> players)
        {
            Player currentlyWinning = null;
            foreach (Player player in players)
            {
                if (!player.Bust && player.Hand.Count >= 5)
                {
                    if (currentlyWinning == null)
                    {
                        currentlyWinning = player;
                    }
                    else
                    {
                        throw new DrawException();
                    }
                }
            }
            return currentlyWinning;
        }

        static Player GetNormalWinner(IEnumerable<Player> players)
        {
            Player highestPlayer = players
                .Where(p => !p.Bust)
                .OrderByDescending(p => p.HighestValue)
                .First();

            if (highestPlayer == null)
            {
                return null;
            }
            else
            {
                int numberOfEqualPlayers = players
                    .Where(p => !p.Bust)
                    .Where(p => p.HighestValue == highestPlayer.HighestValue)
                    .Count();

                if (numberOfEqualPlayers > 1)
                {
                    throw new DrawException();
                }
                else
                {
                    return highestPlayer;
                }
            }
        }
    }
}
