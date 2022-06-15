using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{

    /// ���������������, ��� � ����� ���� ���������� ����, ����� ��� ����������� ��� �������, 
    /// � ���� ������ ������. ���� ����� ������ ��� � ��� ������� ��� �������� � ��������,
    /// � ����� ������ ����� ���.
    public class Step1 : BaseStatesGame
    {
        /// <summary>
        /// ���1. �������� ������ ����� �� ������.
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
                // ���� ������� ������
                GameObject obj = _selectingFigure.GetObject(ListGameObjects.Instance.GetMainCamera());

                // ������������� ��� (������ ��� ������� ������? ��� ������ �������� �� ������?)
                // ���� ������ ����� �� ������
                _controlStateGame.SetSelectFigure(obj);

                // ������������� � ���� ������� �� ������ ���,
                // ��������� ��������� ������ ��� ������ � ������� �� �� �����
                _controlStateGame.ChangeState(_controlStateGame._step2);
            }
        }
    }
}
