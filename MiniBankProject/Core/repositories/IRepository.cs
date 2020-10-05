using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.Core.repositories
{
    public interface IRepository<K, T>
    {
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        T GetById(K Id);
        IEnumerable<T> GetAll();
    }
}
