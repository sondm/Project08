using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{
    public class Step3 : BaseStatesGame
    {
        /// <summary>
        /// Ўаг3. »грок разместил фигуру на поле, теперь надо проверить какие линии сгорают
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
            // Ќа выходе с этого этапа надо проверить, остались ли фигуры дл€ добавлени€.
            // ≈сли их нет, то создать все три.
            _controlStateGame.CreateNewFigures();
        }

        public override void UpdateState()
        {
            // убирать это в блок EnterState Ќ≈Ћ№«я, лини€ не проходит проверку, только установленные 
            //кубики не попадают в проверку, только на следующий ход
            Debug.Log($"—сылка дл€ передачи = {_controlStateGame.GetDestroyCubes()}");
            CheckFieldStep3 checkField = new CheckFieldStep3(_controlStateGame.GetDestroyCubes());
            checkField.StartCheck();
            _controlStateGame.ChangeState(_controlStateGame._step1);
        }
    }
}
