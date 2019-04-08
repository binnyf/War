using System;
using System.Collections;
using System.Collections.Generic;

namespace GameNamespace
{
    public class CardStock : IEnumerable<Card>
    {
        private static Random random = new Random();
        public const int NUM_CARDS = 26;
        List<Card> cards;
        

        #region ctor

        public CardStock()
        {
            cards = new List<Card>();
            for (int i = Card.MINVAL; i <= Card.MAXVAL; i++)
            {
                cards.Add(new Card(i, "black"));
                cards.Add(new Card(i, "red"));
            }
            shuffle();
        }
        #region private methods

        private void swap(List<Card> cards, int k1, int k2)
        {
            Card temp = cards[k1];
            cards[k1] = cards[k2];
            cards[k2] = temp;
        }

        #endregion


        #endregion

        #region public methods

        public void shuffle()
        {
            int klaf1, klaf2;
            for (int i = 0; i < 1000; i++)
            {
                // for (int delay = 0; delay < 10000; delay++) { }
                klaf1 = random.Next(0, 26);
                do
                {
                    klaf2 = random.Next(0, NUM_CARDS);
                }
                while (klaf1 == klaf2);

                swap(cards, klaf1, klaf2);
            }
        }
        public Card this[int index]
        {
            get
            {
                if (index < 0 || index > (NUM_CARDS - 1))
                {
                    return null;
                }
                return cards[index];
            }
        }

        public Card this[string indexName]
        {
            get
            {
                Card card = null;
                foreach (Card item in cards)
                {
                    if (item.CardName == indexName)
                    {
                        card = item;
                        break;
                    }
                }
                return card;
            }
        }

        public void addCard(Card c)
        {
            //cards.push(c);
            cards.Insert(0,c);
        }


        public void removeCard(Card c)
        {
            cards.Remove(c);
        }

        public void distribute(params Player[] players)
        {
            foreach (Player p in players)
            {
                for (int i = 0; i < NUM_CARDS/2; i++)
                {
                   //p.addCard(cards.pop());
                    p.addCard(cards[0]);
                    cards.RemoveAt(0);
                }
            }
        }


            #endregion

 
            #region override
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion ovveride

        #region IEnumerable
        public IEnumerator<Card> GetEnumerator()
        {
            return cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion IEnumerable

    }
}