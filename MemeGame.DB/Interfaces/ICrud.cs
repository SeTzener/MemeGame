using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.DB
{
    public interface ICrud<T>
    {
        bool Create();
        T Update(string name);
        T Update(ObjectId id);
        T Find(string name);
        T Find(ObjectId id);
        bool Delete(string name);
    }
}
