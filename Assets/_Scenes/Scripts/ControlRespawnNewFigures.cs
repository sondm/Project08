using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������ ��������� ����� ����� �� ����������� ������
/// </summary>
public class ControlRespawnNewFigures : MonoBehaviour
{
    [Header("����� ��� ����� �����")]
    [SerializeField] private Transform[] _points;

    void Start()
    {
        
    }

    /// <summary>
    /// ������� ����� ������
    /// </summary>
    public void Create()
    {
        foreach (Transform point in _points)
        {
            // �������� ��������� ������

            // ������� ������ �� �����
            Instantiate(gameObject, point.position, Quaternion.identity);
        }
    }
}
