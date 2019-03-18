// --------------------------------------------------------------------------------------------------------------------
// <copyright company="twentysix" file="FilmList.cs">
// Copyright (c) twentysix.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Generics
{
    using System;
    using System.Data;

    public class FilmList
    {
        public void Add(Film film)
        {
            throw new NotImplementedException();
        }

        public Film this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException();}
        }
    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }

    }

}