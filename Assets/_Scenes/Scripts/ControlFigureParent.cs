using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� � ���������� �������� ��� �������� ������
/// </summary>
public class ControlFigureParent : MonoBehaviour
{
    private Transform _homePoint; // �����, �� ������� ������� ������ ����������.
    private BoxCollider _boxCollider;
    private List<GameObject> _childrenList = new List<GameObject>();

    public void SetHomeTransform(Transform tr) => _homePoint = tr;
    public void MoveToHomePoint() => gameObject.transform.position = _homePoint.position;

    public void ScaleDown() => transform.localScale = new Vector3(.5f, .5f, .5f);
    public void ScaleUp() => transform.localScale = new Vector3(1f, 1f, 1f);
    public void RotationToZero() => transform.localRotation = Quaternion.identity;
    public void GetCollider() => _boxCollider = GetComponent<BoxCollider>();
    public void EnableCollider() => _boxCollider.enabled = true;
    public void DisableCollider() => _boxCollider.enabled = false;

    public void AddChild(GameObject obj)
    {
        _childrenList.Add(obj);
    }

    /// <summary>
    /// ���������� �� ���������� �������� �� ����
    /// </summary>
    /// <returns>true = ����� ���������</returns>
    public bool AcceptChildObject()
    {
        foreach (GameObject child in _childrenList)
        {
            if(!child.GetComponent<Cube.SearchFreeSpace>().ReadyToPlace()) return false;
        }
        return true;
    }

    /// <summary>
    /// ��������������� ���������� ������� �� ����, � ����������� ��������
    /// </summary>
    public void PlaceObjInGame()
    {
        foreach (GameObject child in _childrenList)
        {
            child.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
