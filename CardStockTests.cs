using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameNamespace;
using System.Collections.Generic;

namespace TestGame
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Card card = new Card { Color = Color.BLACK, Number = 12 };
            Console.WriteLine(card);
            Card anothercard = new Card(tzeva: "BLACK", number: 12);
            Console.WriteLine(anothercard);

            if (card.CompareTo(anothercard) == 0)
            {
                Console.WriteLine("shavim");
            }

        }
        [TestMethod]
        public void Testmethod3()
        {
            CardStock cardDeck = new CardStock();
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine(cardDeck[i]);
            }

        }
        [TestMethod]
        public void kukuMethod4U()
        {
            CardStock cardDeck = new CardStock();
            foreach (Card item in cardDeck)
            {
                Console.WriteLine(item);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {

            List<Card> cardList = new List<Card>
            {
                new Card { Color = Color.BLACK, Number=10},
                new  Card(9,"BLACK"),
                new Card(tzeva: "RED", number:12),
                new Card { Number = 6, Color=  Color.RED}
            };
            Console.WriteLine("before sorting");
            foreach (Card item in cardList)
            {
                Console.WriteLine(item);
            }
            cardList.Sort();
            Console.WriteLine("after sorting");
            foreach (Card item in cardList)
            {
                Console.WriteLine(item);
            }

        }
    }
}