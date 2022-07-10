using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateGame;

[RequireComponent(typeof(ControlRespawnNewFigures))]
[RequireComponent(typeof(Cube.DestroyCubes))]
public class ControlStateGame : MonoBehaviour
{
    public BaseStatesGame _currentState { get; private set; }
    public Step1 _step1 { get; private set; }
    public Step2 _step2 { get; private set; }
    public Step3 _step3 { get; private set; }

    private GameObject _selectingFigure; // выбранная фигура

    private ControlRespawnNewFigures _controlRespawnNewFigures;

    private Cube.DestroyCubes _destroyCubes;


    private void Awake()
    {
        _step1 = new Step1(this);
        _step2 = new Step2(this);
        _step3 = new Step3(this);
    }

    private void Start()
    {
        ChangeState(_step1);
        _controlRespawnNewFigures = gameObject.GetComponent<ControlRespawnNewFigures>();
        _destroyCubes = gameObject.GetComponent<Cube.DestroyCubes>();
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
    public void CreateNewFigures() => _controlRespawnNewFigures.Create();
    public Cube.DestroyCubes GetDestroyCubes() => _destroyCubes;
}
