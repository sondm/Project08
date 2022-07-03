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
        List<GameObject> listLinesForDestroy = new List<GameObject>();
        List<List<GameObject>> listForAll = new List<List<GameObject>>();
        Debug.Log("Проверка по Х");
        int countInLine = 0;
        RaycastHit[] hits;
        for (float x = 0; x < 10; x += 1f)
        {
            hits = Physics.RaycastAll(new Vector3(x, 0f, 0f), Vector3.up, 10f);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "Cube")
                {
                    listLinesForDestroy.Add(hits[i].transform.gameObject);
                    countInLine++;
                }
            }

            // если по линии набирается 10 кубиков, то добавляем линию в очередь на уничтожение
            if (countInLine > 9)
            {
                Debug.Log($"Линия X={x} заполнена и готова к удалению");
                countInLine = 0;
                listForAll.Add(listLinesForDestroy);
            }
            else countInLine = 0;
        }

        Debug.Log("Проверка по У");
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

            // если по линии набирается 10 кубиков, то добавляем линию в очередь на уничтожение
            if (countInLine > 4)
            {
                Debug.Log($"Линия Y={y} заполнена и готова к удалению");
                countInLine = 0;
                listForAll.Add(listLinesForDestroy);
            }
            else countInLine = 0;
        }

        if (countInLine == 10)
        {
            //TODO: ОСТАНОВИЛСЯ ТУТ
            Debug.Log("Уничтожаем линию");
        }
    }
}
