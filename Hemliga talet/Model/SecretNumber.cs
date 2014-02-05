using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Hemliga_talet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;

        //Egenskaper
        public bool CanMakeGuess 
        {
            get
            {
                if (Count == MaxNumberOfGuesses)
                {   
                    return false;
                };
                return true;
            }
        }
        
        public int Count 
        {
            get 
            { 
                return _previousGuesses.Count;
            } 
        }

        public int? Number 
        {
            get 
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            } 
        }

        public Outcome Outcome
        {
            get;
            private set;
        }
        
        //Skickar enbart tillbaka en readonly referens av listan
        public IEnumerable<int> PreviousGuesses 
        {
            get 
            { 
                return _previousGuesses.AsReadOnly(); 
            }
        }

        //Metoder
        public void Initialize()
        {
            _previousGuesses.Clear();

            Random random = new Random();
            _number = random.Next(1, 101);

            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (PreviousGuesses.Contains(guess))
            {
                Outcome = Outcome.PreviousGuess;
            }
            else if (CanMakeGuess == false)
            {
                Outcome = Outcome.NoMoreGuesses;
            }
            else if (guess < _number)
            {
                _previousGuesses.Add(guess);
                Outcome = Outcome.Low;
            }
            else if (guess > _number)
            {
                _previousGuesses.Add(guess);
                Outcome = Outcome.High;
            }
            else
            {
                _previousGuesses.Add(guess);
                Outcome = Outcome.Correct;
            }

            return Outcome;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }
}