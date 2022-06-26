using UnityEngine;

namespace StateGame
{
    public class Step2 : BaseStatesGame
    {
        /// <summary>
        /// Ўаг2. »грок выбрал блок дл€ установки
        /// </summary>
        /// ўас ожидаетс€ либо отмена выбора, либо место установки.
        public Step2(ControlStateGame controlStateGame) : base(controlStateGame)
        {
        }

        // private
        private GameObject _controlFigure;

        public override void EnterState()
        {
            _controlFigure = _controlStateGame.GetSelectFigure();
            _controlFigure.GetComponent<ControlFigureParent>().DisableCollider(); // коллайдер родител€ нам уже не нужен
            _controlFigure.GetComponent<ControlFigureParent>().ScaleUp();
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
            // при перемещении фигура двигаетс€ на единицу
            //TODO: доделать, пока фигура двигаетс€ не на единицу
            Vector3 positionFigure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionFigure.z = -2f;

            // округл€ем позицию
            positionFigure = new Vector3(
                Mathf.Round(positionFigure.x),
                Mathf.Round(positionFigure.y),
                positionFigure.z
                );

            _controlFigure.transform.position = positionFigure;

            // поворачиваем фигуру дл€ установки
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
                Debug.Log("Ќажали левую кнопку");
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                if (cfp.AcceptChildObject())
                {
                    Debug.Log("ћожно разместить фигуру");
                    cfp.PlaceObjInGame();
                }
                else Debug.Log("“ут нельз€ разместить фигуру");

                _controlStateGame.SetSelectFigure(null); // убрать фигуру из запоминалки
                _controlStateGame.ChangeState(_controlStateGame._step3); // переходим к следующему шагу
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Ќажали правую кнопку");
                // при отмене надо вернуть все на свои места
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                cfp.MoveToHomePoint(); // фигуру на первоначальную точку
                cfp.ScaleDown(); // уменьшаем размер
                cfp.RotationToZero(); // сбрасываем угол поворота
                cfp.EnableCollider();
                _controlStateGame.SetSelectFigure(null); // убрать фигуру из запоминалки
                _controlStateGame.ChangeState(_controlStateGame._step1); // возвращаемс€ к первому шагу
            }
        }
    }
}
