using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  онтролируем по€вление новых фигур на обозначеных местах
/// </summary>
public class ControlRespawnNewFigures : MonoBehaviour
{
    [Header("“очки дл€ новых фигур")]
    [SerializeField] private Transform[] _points;

    void Start()
    {
        
    }

    /// <summary>
    /// —оздать новые фигуры
    /// </summary>
    public void Create()
    {
        foreach (Transform point in _points)
        {
            // выбираем случайную фигуру

            // создаем фигуру на точке
            Instantiate(gameObject, point.position, Quaternion.identity);
        }
    }
}
