
namespace Generics
{
    using System;
    using System.Collections.Generic;

    class Program
    {
     

        static void Main(string[] args)
        {
            GenericsExmaple();
            GenericaNullableExample();
        }

        private static void GenericaNullableExample()
        {
            var number = new Nullable<int>(1);
            Console.WriteLine("Has Value ?" + number.HasValue);
            Console.WriteLine("Value = " + number.GetValueOrDefault());
        }

        private static void GenericsExmaple()
        {

            var film = new Film() { Title = "Jaws", Id = "121" };

            //var films = new FilmList();
            //films.Add(film);

            //var numbers = new List();
            //numbers.Add(11);

            // Creating a generic list is more performant as its created at run time, there is no casting or boxing and more code resuability. 

            var numnbers = new GenericList<int>();
            numnbers.Add(1);

            var films = new GenericList<Film>();
            films.Add(film);

            var dictionary = new GenericDictionary<int, Film>();
            dictionary.Add(123, new Film());
        }
    }
}
