using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{
    /// <summary>
    /// Состояния игры
    /// </summary>
    public abstract class BaseStatesGame
    {
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
    }
}
