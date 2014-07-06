using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge170Easy.Cards
{
    public class Player
    {
        public List<Card> Hand
        {
            get;
            private set;
        }

        public bool Bust
        {
            get
            {
                return LowestValue > 21;
            }
        }

        public int LowestValue
        {
            get
            {
                return Hand
                    .Select(c => c.GetValue(false))
                    .Aggregate((c, d) => c + d);
            }
        }

        public int HighestValue
        {
            get
            {
                int value = LowestValue;
                int numberOfAces = Hand
                    .Where(c => c.Rank == CardRank.Ace)
                    .Count();

                for (int i = 0; i < numberOfAces; i++)
                {
                    if (value + 10 > 21) break;
                    value += 10;
                }

                return value;
            }
        }

        public string Name
        {
            get;
            private set;
        }

        public Player()
        {
            Hand = new List<Card>();
            Name = "Unnamed";
        }

        public Player(IEnumerable<Card> hand)
        {
            Hand = new List<Card>(hand);
            Name = "Unnamed";
        }

        public Player(string playerInfo)
        {
            string[] playerInfoArray = playerInfo.Split(':').Select(s => s.Trim()).ToArray();
            Name = playerInfoArray[0];

            string[] cardsInHand = playerInfoArray[1].Split(',').Select(s => s.Trim()).ToArray();
            Hand = new List<Card>(cardsInHand.Select(s => new Card(s)));
        }
    }
}
