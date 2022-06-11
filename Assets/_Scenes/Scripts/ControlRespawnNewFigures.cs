using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������ ��������� ����� ����� �� ����������� ������
/// </summary>
public class ControlRespawnNewFigures : MonoBehaviour
{
    [Header("����� ��� ����� �����")]
    [Tooltip("����� ������������ ����� ��� ������ ������")]
    [SerializeField] private Transform[] _points;

    [Header("�������")]
    [Tooltip("������� ������, �� �������� ������������� ������")]
    [SerializeField] private GameObject _prefabForFigure;

    // private
    private GameObject _newFigure;

    // ��������� ���������� ��� ����������� ������� � ������
    private Vector3[] _localsPointFigure1 =
    {
        new Vector3(0, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, 2, 1),
    };

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
            _newFigure = GetNewFigure();

            // ������� ������ �� �����
            Instantiate(_newFigure, point.position, Quaternion.identity);
        }
    }

    private GameObject GetNewFigure()
    {
        //TODO: ����������� ���
        GameObject figure = null;
        return figure;
    }
}
