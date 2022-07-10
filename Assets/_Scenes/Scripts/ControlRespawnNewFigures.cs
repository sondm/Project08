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

    // ��������� ���������� ��� ����������� ������� � ������
    private Dictionary<int, Vector3[]> _dictFigures = new Dictionary<int, Vector3[]>();
    private Dictionary<int, Vector3[]> _dictBoxCollider = new Dictionary<int, Vector3[]>();

    void Start()
    {
        AddVectorsToDictFigure();
        AddVectorsToDictBoxCollider();
        Create(); //TODO: delete after test
    }

    /// <summary>
    /// ��������� ������� �����
    /// </summary>
    private void AddVectorsToDictFigure() // ������������ �����
    {
        _dictFigures.Add(1, new Vector3[]
        {
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 0),
            new Vector3(-1, 0, 0),
        });

        _dictFigures.Add(2, new Vector3[]
        {
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
        }); 
        
        _dictFigures.Add(3, new Vector3[]
        {
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 2, 0),
        });
    }

    /// <summary>
    /// ��������� ������� ��������� ���������� ��� �����
    /// </summary>
    private void AddVectorsToDictBoxCollider() // ������ ����� ��� ���������, ������ ������
    {
        _dictBoxCollider.Add(1, new Vector3[]
        {
            new Vector3(-.5f, -.5f, 0f),
            new Vector3(2f, 2f, 1f),
        });

        _dictBoxCollider.Add(2, new Vector3[]
        {
            new Vector3(.5f, -.5f, 0f),
            new Vector3(2f, 2f, 1f),
        });

        _dictBoxCollider.Add(3, new Vector3[]
        {
            new Vector3(0f, .5f, 0f),
            new Vector3(1f, 4f, 1f),
        });
    }

    /// <summary>
    /// ������� ����� ������
    /// </summary>
    public void Create()
    {
        if (CheckPlaceBeforeSpawnNewFigures() == false) return;
        foreach (Transform point in _points)
        {
            // ������� ��������
            GameObject parentObj = new GameObject();

            // ��������� �������� ����������� ������
            ControlFigureParent cfp = parentObj.AddComponent<ControlFigureParent>();

            // �������� � ������� ��������� ������
            GetNewFigure(parentObj.transform);

            // ������ �������� �� ���� �����
            cfp.SetHomeTransform(point);
            cfp.MoveToHomePoint();

            // ��������� ��� ������
            cfp.ScaleDown();

            // ������������� � �������� ���������
            cfp.GetCollider();
            cfp.EnableCollider();
        }
    }

    private void GetNewFigure(Transform parent)
    {
        // ������ �������� ������� ������, ��������� ������ ��� ������
        int i = Random.Range(1, _dictFigures.Count + 1);
        ControlFigureParent cfp = parent.GetComponent<ControlFigureParent>();
        foreach (Vector3 v3 in _dictFigures[i])
        {
            // ������� ����� � ������� ���������� ��������
            GameObject figure = Instantiate(_prefabForFigure, Vector3.zero, Quaternion.identity, parent);

            // ������� ��� �� ���� �����
            figure.transform.localPosition = v3;
            cfp.AddChild(figure);
        }

        // ���� �������� ���, � ����������� �� �������� ������
        parent.name = $"figure{i}";

        // ������������� ���
        parent.tag = "Figure";

        // ��������� ���������
        parent.gameObject.AddComponent<BoxCollider>();

        // ������������ ������ � ��������� ����������
        parent.GetComponent<BoxCollider>().center = _dictBoxCollider[i][0];
        parent.GetComponent<BoxCollider>().size = _dictBoxCollider[i][1];
    }

    /// <summary>
    /// ��������� �����, ����� ��������� ����� �����
    /// </summary>
    public bool CheckPlaceBeforeSpawnNewFigures()
    {
        // ������ false, ���� ���� �� ���� ����� ��� ������
        RaycastHit[] hits;
        hits = Physics.RaycastAll(new Vector3(12, 0f, 0f), Vector3.up, 10f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag == "Cube")
            {
                Debug.Log($"��� {hits.Length} ����� ���� ���������");
                return false;
            }
        }
        Debug.Log("����� ���, ������� �����");
        return true;
    }
}
