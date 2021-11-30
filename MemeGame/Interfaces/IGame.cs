using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IGame : IGameIdentity
    {
        decimal Timer { get; }
        decimal TimeCount();
        IBoard Board { get; }
        List<IRules> Rules { get; }
        void DoWork();
    }
}
