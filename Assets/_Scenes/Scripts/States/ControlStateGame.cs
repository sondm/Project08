using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateGame;

public class ControlStateGame : MonoBehaviour
{
    private BaseStatesGame _currentState;
    private Step1 _step1 = new Step1(this);

    private void Start()
    {
        
    }

    public void ChangeState()
    {

    }


}
