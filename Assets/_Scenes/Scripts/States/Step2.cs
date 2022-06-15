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
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            // ��� ����������� ������ ��������� �� �������
            _controlFigure.transform.position = Input.mousePosition;
        }
    }
}
