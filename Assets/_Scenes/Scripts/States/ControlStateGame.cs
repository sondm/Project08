using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateGame;

public class ControlStateGame : MonoBehaviour
{
    public BaseStatesGame _currentState { get; private set; }
    public Step1 _step1 { get; private set; }
    public Step2 _step2 { get; private set; }

    private GameObject _selectingFigure; // выбранная фигура


    private void Awake()
    {
        _step1 = new Step1(this);
        _step2 = new Step2(this);
    }

    private void Start()
    {
        ChangeState(_step1);
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void ChangeState(BaseStatesGame newState)
    {
        if (_currentState != null) _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void SetSelectFigure(GameObject obj) => _selectingFigure = obj;
    public GameObject GetSelectFigure() => _selectingFigure;


}
