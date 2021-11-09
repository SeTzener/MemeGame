﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IGame : IGameInfos
    {
        List<IRule> Rules { get; }
        void DoWork();
    }
}
