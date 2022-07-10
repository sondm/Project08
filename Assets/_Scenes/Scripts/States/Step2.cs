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
            _controlFigure.GetComponent<ControlFigureParent>().DisableCollider(); // коллайдер родителя нам уже не нужен
            _controlFigure.GetComponent<ControlFigureParent>().ScaleUp();
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
            // при перемещении фигура двигается на единицу
            Vector3 positionFigure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionFigure.z = -1f;

            // округляем позицию
            positionFigure = new Vector3(
                Mathf.Round(positionFigure.x),
                Mathf.Round(positionFigure.y),
                positionFigure.z
                );

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

            // лкм - устанавливаем фигуру, пкм - отмена, возврат фигуры на свое место
            if (Input.GetMouseButtonDown(0))
            {
                List<GameObject> ListZPosition = new List<GameObject>();
                //Debug.Log("Нажали левую кнопку");
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                ListZPosition = cfp.GetObkForCheckZPosition();
                if (cfp.AcceptChildObject())
                {
                    //Debug.Log("Можно разместить фигуру");
                    cfp.PlaceObjInGame();
                    CheckZPosition(ListZPosition);
                }
                else
                {
                    Debug.Log("Тут нельзя разместить фигуру");
                    return;
                }

                _controlStateGame.SetSelectFigure(null); // убрать фигуру из запоминалки
                _controlStateGame.ChangeState(_controlStateGame._step3); // переходим к следующему шагу
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //Debug.Log("Нажали правую кнопку");
                // при отмене надо вернуть все на свои места
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                cfp.MoveToHomePoint(); // фигуру на первоначальную точку
                cfp.ScaleDown(); // уменьшаем размер
                cfp.RotationToZero(); // сбрасываем угол поворота
                cfp.EnableCollider();
                _controlStateGame.SetSelectFigure(null); // убрать фигуру из запоминалки
                _controlStateGame.ChangeState(_controlStateGame._step1); // возвращаемся к первому шагу
            }
        }
        private void CheckZPosition(List<GameObject> objs)
        {
            bool zPosition = false;
            int x = 0;
            int count = 0;
            while (zPosition == false && count < 15)
            {
                foreach (var item in objs)
                {
                    //Debug.Log($"Position Z of {item} = {item.transform.position.z}");
                    //Debug.Log($"tag {item.name} = {item.transform.tag}");
                    if (item.transform.position.z == 0) x++;
                }
                count ++;
                if (x==3) zPosition = true;
            }
        }
    }
}
