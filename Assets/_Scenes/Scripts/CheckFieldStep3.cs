using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ���� �� ������������ ����� �� ����������� � ���������
/// </summary>
public class CheckFieldStep3
{
    public void StartCheck()
    {
        int countInLine = 0;
        Ray ray = new Ray(new Vector3(0f, 0f, 0f), new Vector3(0f, 10f, 0f));
        RaycastHit[] hits;
        hits = Physics.RaycastAll(new Vector3(0f, 0f, 0f), new Vector3(0f, 10f, 0f));
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i].transform.tag == "Cube")
            {
                countInLine++;
            }
        }
        Debug.Log($"� ����� ������� {countInLine} �������");
        if (countInLine == 10)
        {
            //TODO: ����������� ���
            Debug.Log("���� ������ �����");
        }
    }
}
