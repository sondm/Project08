using UnityEngine;

/// <summary>
/// ������ ������� ��� � ������� Start (����� ����� �������������� �����������)
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
