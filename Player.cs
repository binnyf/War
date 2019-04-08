
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNamespace
{
    public class Player
    {
        public String Name { get; set; }
        Queue<Card> queue = new Queue<Card>();


        public void addCard(Card card)
        {
            queue.Enqueue(card);
        }

        //when player's queue is empty they have lost
        public bool loseout()
        {
            return queue.Count == 0;
        }

        //show top card
        public Card top()
        {
            Card top = queue.Peek();
            return top;
        }

        //used to play the top card
        public Card pop()
        {
            Card top = queue.Dequeue();
            return top;
        }
    }
}