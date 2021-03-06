﻿using System;
using System.Collections.Generic;

namespace Phone_book.DAL.Repositoys.Intarfaces
{
    public interface IGenericDataRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetList(Func<T, bool> where);
        T GetSingle(Func<T, bool> where);
        T GetSingle(T item1);
        void Add(T item);
        void Add(IEnumerable<T> item);

        void Remove(T item);
        void Update(T item);
    }
}