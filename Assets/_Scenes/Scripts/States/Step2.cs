using System.Collections;
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
            _controlFigure.GetComponent<BoxCollider>().enabled = false; // ��������� �������� ��� ��� �� �����
            ScaleUpFigure(); // ������ ������
            Debug.Log("get obj - " + _controlFigure.name);
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            // ��� ����������� ������ ��������� �� �������
            //TODO: ��������, ���� ������ ��������� �� �� �������
            Vector3 positionFigure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionFigure.z = 0f;
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
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("������ ������ ������");
            }
        }

        /// <summary>
        /// ������� ��������� ������ � �� ����������� �������
        /// </summary>
        private void ScaleUpFigure()
        {
            _controlFigure.transform.localScale = Vector3.one;
        }
    }
}
