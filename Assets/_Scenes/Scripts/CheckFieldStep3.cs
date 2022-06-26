using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Проверка поля на заполненость линий по горизонтали и вертикали
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
        Debug.Log($"В линии найдено {countInLine} кубиков");
        if (countInLine == 10)
        {
            //TODO: ОСТАНОВИЛСЯ ТУТ
            Debug.Log("Надо убрать линию");
        }
    }
}
