using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{

    /// Подразумевается, что с этого шага начинается игра, блоки для выставления уже созданы, 
    /// и ждут выбора игрока. Либо игрок сделал ход и уже сделаны все подсчеты и действия,
    /// и можно делать новый ход.
    public class Step1 : BaseStatesGame
    {
        /// <summary>
        /// Шаг1. Ожидание выбора блока от игрока.
        /// </summary>
        public Step1 (ControlStateGame controlStateGame) : base (controlStateGame)
        {

        }

        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            
        }
    }
}
