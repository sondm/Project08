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
            CheckFieldStep3 checkField = new CheckFieldStep3();
            checkField.StartCheck(); //TODO: � ���� ������ ������ ��� �� ����������� �� ��������, � �������������� ��� Z � ��� -2, �������� �� �� �����
            _controlStateGame.ChangeState(_controlStateGame._step1);
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }
    }
}
