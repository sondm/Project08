using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ���� �� ������������ ����� �� ����������� � ���������
/// </summary>
public class CheckFieldStep3
{
    private Cube.DestroyCubes _destroyCubes;
    public CheckFieldStep3(Cube.DestroyCubes linkDestroyCubes) {
        _destroyCubes = linkDestroyCubes;
    }

    public void StartCheck()
    {
        List<GameObject> listLinesForDestroy = new List<GameObject>();
        Debug.Log("�������� �� �");
        int countInLine = 0;
        RaycastHit[] hits;
        for (float x = 0; x < 10; x += 1f)
        {            
            hits = Physics.RaycastAll(new Vector3(x, -.5f, 0f), Vector3.up, 10f);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "Cube")
                {
                    listLinesForDestroy.Add(hits[i].transform.gameObject);
                    countInLine++;
                }
            }

            // ���� �� ����� ���������� 10 �������, �� ��������� ����� � ������� �� �����������
            if (countInLine > 9)
            {
                Debug.Log($"����� X={x} ��������� � ������ � ��������");
                _destroyCubes.DestroyThisLineCubes(listLinesForDestroy);
                countInLine = 0;
            }
            else 
            {
                listLinesForDestroy.Clear();
                countInLine = 0; 
            }
        }

        Debug.Log("�������� �� �");
        hits = null;
        countInLine = 0;
        for (float y = 0; y < 10f; y += 1f)
        {
            hits = Physics.RaycastAll(new Vector3(-.5f, y, 0f), Vector3.right, 10f);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "Cube")
                {
                    listLinesForDestroy.Add(hits[i].transform.gameObject);
                    countInLine++;
                }
            }

            // ���� �� ����� ���������� 10 �������, �� ��������� ����� � ������� �� �����������
            if (countInLine > 9)
            {
                Debug.Log($"����� Y={y} ��������� � ������ � ��������");
                countInLine = 0;
                _destroyCubes.DestroyThisLineCubes(listLinesForDestroy);
            }
            else
            {
                listLinesForDestroy.Clear();
                countInLine = 0;
            }
        }
    }
}
