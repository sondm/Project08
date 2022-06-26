using UnityEngine;

namespace StateGame
{
    public class Step2 : BaseStatesGame
    {
        /// <summary>
        /// ���2. ����� ������ ���� ��� ���������
        /// </summary>
        /// ��� ��������� ���� ������ ������, ���� ����� ���������.
        public Step2(ControlStateGame controlStateGame) : base(controlStateGame)
        {
        }

        // private
        private GameObject _controlFigure;

        public override void EnterState()
        {
            _controlFigure = _controlStateGame.GetSelectFigure();
            _controlFigure.GetComponent<ControlFigureParent>().DisableCollider(); // ��������� �������� ��� ��� �� �����
            _controlFigure.GetComponent<ControlFigureParent>().ScaleUp();
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
            // ��� ����������� ������ ��������� �� �������
            //TODO: ��������, ���� ������ ��������� �� �� �������
            Vector3 positionFigure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionFigure.z = -2f;

            // ��������� �������
            positionFigure = new Vector3(
                Mathf.Round(positionFigure.x),
                Mathf.Round(positionFigure.y),
                positionFigure.z
                );

            _controlFigure.transform.position = positionFigure;

            // ������������ ������ ��� ���������
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

            // ��� - ������������� ������, ��� - ������, ������� ������ �� ���� �����
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("������ ����� ������");
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                if (cfp.AcceptChildObject())
                {
                    Debug.Log("����� ���������� ������");
                    cfp.PlaceObjInGame();
                }
                else Debug.Log("��� ������ ���������� ������");

                _controlStateGame.SetSelectFigure(null); // ������ ������ �� �����������
                _controlStateGame.ChangeState(_controlStateGame._step3); // ��������� � ���������� ����
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("������ ������ ������");
                // ��� ������ ���� ������� ��� �� ���� �����
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                cfp.MoveToHomePoint(); // ������ �� �������������� �����
                cfp.ScaleDown(); // ��������� ������
                cfp.RotationToZero(); // ���������� ���� ��������
                cfp.EnableCollider();
                _controlStateGame.SetSelectFigure(null); // ������ ������ �� �����������
                _controlStateGame.ChangeState(_controlStateGame._step1); // ������������ � ������� ����
            }
        }
    }
}
