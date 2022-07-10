using System.Collections.Generic;
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
            Vector3 positionFigure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionFigure.z = -1f;

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
                List<GameObject> ListZPosition = new List<GameObject>();
                //Debug.Log("������ ����� ������");
                ControlFigureParent cfp = _controlFigure.GetComponent<ControlFigureParent>();
                ListZPosition = cfp.GetObkForCheckZPosition();
                if (cfp.AcceptChildObject())
                {
                    //Debug.Log("����� ���������� ������");
                    cfp.PlaceObjInGame();
                    CheckZPosition(ListZPosition);
                }
                else
                {
                    Debug.Log("��� ������ ���������� ������");
                    return;
                }

                _controlStateGame.SetSelectFigure(null); // ������ ������ �� �����������
                _controlStateGame.ChangeState(_controlStateGame._step3); // ��������� � ���������� ����
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //Debug.Log("������ ������ ������");
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
