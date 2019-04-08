
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNamespace
{
    public class Card : IComparable<Card>
    {
        #region public members
        public const int MINVAL = 2;
        public const int MAXVAL = 14;

        #endregion public members

        #region private members
        private int number;

        #endregion private members

        #region getters & setters

        public Color Color
        {
            get;
            set;
        }


        public int Number
        {
            set
            {
                if (value < MINVAL || value > MAXVAL)
                {
                    throw new Exception(string.Format("value is not valid:\n Enter value <{0}:{1}>", MINVAL, MAXVAL));
                }
                number = value;
            }
        }

        public string CardName
        {
            get
            {
                switch (number)
                {
                    case 14:
                        return "Ace";
                    case 13:
                        return "King";
                    case 12:
                        return "Queen";
                    case 11:
                        return "Jack";

                    default:
                        return number.ToString();
                }
            }
        }

        #endregion getters & setters

        #region methods
        public override string ToString()
        {
            String result = null;

            result += "the card details are :\n";
            result += "----------------------\n";
            result += String.Format("color : {0},\t", Color);
            result += String.Format("Value:  {0}", CardName);

            return result;
        }

        public int CompareTo(Card other)
        {
            return number.CompareTo(other.number);
        }

        #endregion

        #region ctors

        public Card(int number, string tzeva)
        {
            try
            {
                Number = number;
                Color = (Color)Enum.Parse(typeof(Color), tzeva.ToUpper());
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Console.WriteLine("tzeva {0} lo matim", tzeva);
                }
                else throw ex;
            }
        }
        //explicit default constructor
        public Card() { }
        #endregion
    }

}