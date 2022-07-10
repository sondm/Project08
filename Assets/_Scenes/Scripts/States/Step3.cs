using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateGame
{
    public class Step3 : BaseStatesGame
    {
        /// <summary>
        /// ���3. ����� ��������� ������ �� ����, ������ ���� ��������� ����� ����� �������
        /// </summary>
        /// ��� �� ���������� ��������� ����
        public Step3(ControlStateGame controlStateGame) : base(controlStateGame)
        {
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
            // �� ������ � ����� ����� ���� ���������, �������� �� ������ ��� ����������.
            // ���� �� ���, �� ������� ��� ���.
            _controlStateGame.CreateNewFigures();
        }

        public override void UpdateState()
        {
            // ������� ��� � ���� EnterState ������, ����� �� �������� ��������, ������ ������������� 
            //������ �� �������� � ��������, ������ �� ��������� ���
            Debug.Log($"������ ��� �������� = {_controlStateGame.GetDestroyCubes()}");
            CheckFieldStep3 checkField = new CheckFieldStep3(_controlStateGame.GetDestroyCubes());
            checkField.StartCheck();
            _controlStateGame.ChangeState(_controlStateGame._step1);
        }
    }
}
