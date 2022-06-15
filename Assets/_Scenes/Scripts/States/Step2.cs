using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{
    public class Step2 : BaseStatesGame
    {
        /// <summary>
        /// Шаг2. Игрок выбрал блок для установки
        /// </summary>
        /// Щас ожидается либо отмена выбора, либо место установки.
        public Step2(ControlStateGame controlStateGame) : base(controlStateGame)
        {

        }

        // private
        private GameObject _controlFigure;

        public override void EnterState()
        {
            _controlFigure = _controlStateGame.GetSelectFigure();
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            // при перемещении фигура двигается на единицу
            _controlFigure.transform.position = Input.mousePosition;
        }
    }
}
