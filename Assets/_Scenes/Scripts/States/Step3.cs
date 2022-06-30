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
            CheckFieldStep3 checkField = new CheckFieldStep3();
            checkField.StartCheck(); //TODO: в этот момент кубики еще не освобождены от родителя, и соответственно ось Z у них -2, проверка их не видит
            _controlStateGame.ChangeState(_controlStateGame._step1);
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }
    }
}
