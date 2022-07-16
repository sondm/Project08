using UnityEngine;

/// <summary>
/// Запуск методов при в функции Start (Когда нужно придерживаться очередности)
/// </summary>
public class StartRun : MonoBehaviour
{
    private Points.ControlPoints _controlPoints;

    private void Start()
    {
        _controlPoints = GetComponent<Points.ControlPoints>();
        _controlPoints.OnStartInitialized();
    }
}
