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
            _controlFigure.GetComponent<BoxCollider>().enabled = false; // коллайдер родителя нам уже не нужен
            ScaleUpFigure(); // меняем размер
            Debug.Log("get obj - " + _controlFigure.name);
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            // при перемещении фигура двигается на единицу
            //TODO: доделать, пока фигура двигается не на единицу
            Vector3 positionFigure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionFigure.z = 0f;
            _controlFigure.transform.position = positionFigure;

            // поворачиваем фигуру для установки
            if (Input.mouseScrollDelta.y > 0f)
            {
                Vector3 newAngles = _controlFigure.transform.eulerAngles;
                newAngles += new Vector3(0f, 0f, 90f);
                _controlFigure.transform.rotation = Quaternion.Euler(newAngles);
            }
            else if (Input.mouseScrollDelta.y < 0f)
            {
                Vector3 newAngles = _controlFigure.transform.eulerAngles;
                newAngles += new Vector3(0f, 0f, -90f);
                _controlFigure.transform.rotation = Quaternion.Euler(newAngles);
            }

            // лкм - устанавливаем фигуру, пкм - отмена, возврат фигуры на сове место
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Нажали левую кнопку");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Нажали правую кнопку");
            }
        }

        /// <summary>
        /// Возврат выбранной фигуры к ее нормальному размеру
        /// </summary>
        private void ScaleUpFigure()
        {
            _controlFigure.transform.localScale = Vector3.one;
        }
    }
}
