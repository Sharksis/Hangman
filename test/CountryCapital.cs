using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace test
{
    class CountryCapital
    {
        private string _country;
        private string _capital;
        private char[] _randomCountry;

        public string GetCountry()
        {
            return _country;
        }

        public void SetCountry(string s)
        {
            _country = s;
        }

        public string GetCapital()
        {
            return _capital;
        }

        public void SetCapital(string s)
        {
            _capital = s;
        }

        public char[] GetRandomCountry()
        {
            _randomCountry = _country.ToCharArray();
            return _randomCountry;
        }

        public CountryCapital SetRandomCountry()
        {
            string filePath = @"C:\Hangman\countries_and_capitals.txt.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Could not find file");
            }

            List<CountryCapital> countryCapitals = new List<CountryCapital>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    countryCapitals.Add(new CountryCapital()
                        { _country = parts[0].Trim(), _capital = parts[1].Trim() });
                }
            }

            Random rnd = new Random();
            int randomCountry = rnd.Next(0, countryCapitals.Count - 1);
            return countryCapitals[randomCountry];
        }
    }
}