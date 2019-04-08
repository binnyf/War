using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNamespace
{
    public class Game
    {
        private Player[] players = new Player[2];
        private CardStock cardDeck = new CardStock();
        private CardStock warMiddle = new CardStock();

        //constructor, distributes cards to players of the game
        public Game(params Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                this.players[i] = players[i];
            }

            distribute(players);
        }

        //give out the cards
        public void distribute(params Player[] players)
        {
            int i = 0;
            while (i < CardStock.NUM_CARDS)
            {
                foreach (Player p in players)
                {
                    p.addCard(cardDeck[i]);
                    i++;

                }

            }
        }

        //The actual gameplay
        public void start()
        {

            Console.WriteLine("WELCOME TO WAR!!!");
            Console.WriteLine("Today's Players are: ", players[0], "and", players[1], "\n");

            cardDeck.shuffle();

            Console.WriteLine("our deck consists of: \n");
            for (int i = 0; i < CardStock.NUM_CARDS; i++)
            {
                Console.WriteLine(cardDeck[i]);
            }

            cardDeck.distribute(players); //give out the cards

            Console.WriteLine("THE GAME WILL NOW BEGIN!");


            while(players[0].top()!=null || players[1].top()!=null)
                
            {
                Console.WriteLine("Player 1: ");
                Console.WriteLine(players[0].top());
                Console.WriteLine("\nPlayer 2: \n");
                Console.WriteLine(players[1].top());
                if (players[0].top().CompareTo(players[1].top())==1) //if player1 wins
                {
                    players[0].addCard(players[1].pop()); //player 1 gets player 2's card
                    players[0].addCard(players[0].pop()); //put your own card on the bottom

                    Console.WriteLine("Player 1 wins hand!");
                    if (players[1].loseout() == true)
                    {
                        Console.WriteLine("Player 1 Wins!!!");
                        return;
                    }
                    
                }

                else if (players[0].top().CompareTo(players[1].top())==-1)
                {
                    players[1].addCard(players[0].pop()); //player 2 gets player 1's card
                    players[1].addCard(players[1].pop()); //put your own card on the bottom
                       Console.WriteLine("Player 2 wins hand!");
                    if (players[0].loseout() == true)
                    {
                        Console.WriteLine("Player 2 Wins!!!");
                        return;
                    }

                }
                else while (players[0].top().CompareTo(players[1].top())==0)
                    {
                        Console.WriteLine("WAR!!!");
                        warMiddle.addCard(players[0].pop());
                        warMiddle.addCard(players[1].pop());

                        if (players[1].loseout() == true) //player 2 is out of cards
                        {
                            Console.WriteLine("Player 1 Wins!!!");
                            return;
                        }
                        if (players[0].loseout() == true) //player 1 is out of cards
                        {
                            Console.WriteLine("Player 1 Wins!!!");
                            return;
                        }

                        warMiddle.addCard(players[0].pop());  //put next card of each player into the middle as per the rules of war
                        warMiddle.addCard(players[1].pop());

                        Console.WriteLine("Player 1: "); //show each players next card
                        Console.WriteLine(players[0].top());
                        Console.WriteLine("\nPlayer 2: \n");
                        Console.WriteLine(players[1].top());

                        if (players[0].top().CompareTo(players[1].top())==1)
                        {
                            players[0].addCard(players[1].pop()); //player 1 gets player 2's card
                            players[0].addCard(players[0].pop()); //put your own card on the bottom
                            Console.WriteLine("Player 1 wins hand!");
                            foreach (Card card in warMiddle) //player one gets the middle
                            {
                                players[0].addCard(card);
                            }
                            if (players[1].loseout() == true) //player 2 is out of cards
                            {
                                Console.WriteLine("Player 1 Wins!!!");
                                return;
                            }
                        }

                        else if (players[0].top().CompareTo(players[1].top())==-1) //player 2 gets player 1's card
                        {
                            players[1].addCard(players[0].pop());
                            players[1].addCard(players[1].pop()); //put your own card on the bottom
                            Console.WriteLine("Player 2 wins hand!");
                            foreach (Card card in warMiddle) //player two gets the middle
                            {
                                players[1].addCard(card);
                            }
                            if (players[0].loseout() == true) //player 1 is out of cards
                            {
                                Console.WriteLine("Player 2 Wins!!!");
                                return;
                            }
                        }
                    }//loop continues until someone wins the war
            }




        }
    }
}
