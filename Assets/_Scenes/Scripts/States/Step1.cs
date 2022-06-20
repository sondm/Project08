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

        // private
        private SelectingFigure _selectingFigure = new SelectingFigure();

        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // надо поймать объект
                //GameObject obj = _selectingFigure.GetObject(ListGameObjects.Instance.GetMainCamera());
                GameObject obj = _selectingFigure.GetObject(Camera.main);
                if (obj == null) return;

                // зафиксировать его (только при нажатой кнопке? или просто повесить на курсор?)
                // пока просто вешаю на курсор
                _controlStateGame.SetSelectFigure(obj);

                // переключиться с этой фигурой на второй шаг
                Debug.Log($"Obj is find ({obj.name}), switch to step2");
                _controlStateGame.ChangeState(_controlStateGame._step2);
            }
        }
    }
}
