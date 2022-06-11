using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контролируем появление новых фигур на обозначеных местах
/// </summary>
public class ControlRespawnNewFigures : MonoBehaviour
{
    [Header("Точки для новых фигур")]
    [Tooltip("Точки расположения фигур для выбора игроку")]
    [SerializeField] private Transform[] _points;

    [Header("Префабы")]
    [Tooltip("Базовый префаб, из которого выстраивается фигура")]
    [SerializeField] private GameObject _prefabForFigure;

    // private
    private GameObject _newFigure;

    // Локальные координаты для выставления кубиков в фигуре
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
    /// Создать новые фигуры
    /// </summary>
    public void Create()
    {
        foreach (Transform point in _points)
        {
            // выбираем случайную фигуру
            _newFigure = GetNewFigure();

            // создаем фигуру на точке
            Instantiate(_newFigure, point.position, Quaternion.identity);
        }
    }

    private GameObject GetNewFigure()
    {
        //TODO: Остановился тут
        GameObject figure = null;
        return figure;
    }
}
