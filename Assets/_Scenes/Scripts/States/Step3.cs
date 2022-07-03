using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{
    public class Step3 : BaseStatesGame
    {
        /// <summary>
        /// Шаг3. Игрок разместил фигуру на поле, теперь надо проверить какие линии сгорают
        /// </summary>
        /// так же необходимо насчитать очки
        public Step3(ControlStateGame controlStateGame) : base(controlStateGame)
        {
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
            // На выходе с этого этапа надо проверить, остались ли фигуры для добавления.
            // Если их нет, то создать все три.
        }

        public override void UpdateState()
        {
            // убирать это в блок EnterState НЕЛЬЗЯ, линия не проходит проверку, только установленные 
                //кубики не попадают в проверку, только на следующий ход
            CheckFieldStep3 checkField = new CheckFieldStep3();
            checkField.StartCheck();
            _controlStateGame.ChangeState(_controlStateGame._step1);
        }
    }
}
