using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateGame;

public class ControlStateGame : MonoBehaviour
{
    public BaseStatesGame _currentState { get; private set; }
    private Step1 _step1;

    private void Awake()
    {
        _step1 = new Step1(this);
    }

    private void Start()
    {
        ChangeState(_step1);
    }

    private void Update()
    {
        
    }

    public void ChangeState(BaseStatesGame newState)
    {
        if (_currentState != null) _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }


}
