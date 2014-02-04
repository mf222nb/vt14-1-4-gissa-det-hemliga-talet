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
        Indefine,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber: IEnumerable
    {
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;

        //Egenskaper
        public bool CanMakeGuess 
        {
            get
            {
                if (_previousGuesses.Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;
                    
                    return false;
                };
                return true;
            }
        }
        
        public int Count 
        {
            get { return _previousGuesses.Count;} 
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
        
        public Outcome Outcome { get; set; }
        
        public IEnumerable<int> PreviousGuesses 
        {
            get { return _previousGuesses.AsReadOnly(); }
        }

        //Metoder
        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);

            _previousGuesses.Clear();
            Outcome = Outcome.Indefine;
        }

        public Outcome MakeGuess(int guess)
        {
            return Outcome;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}