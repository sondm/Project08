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

    // Локальные координаты для выставления кубиков в фигуре
    private Dictionary<int, Vector3[]> _dictFigures = new Dictionary<int, Vector3[]>();
    private Dictionary<int, Vector3[]> _dictBoxCollider = new Dictionary<int, Vector3[]>();

    void Start()
    {
        AddVectorsToDictFigure();
        AddVectorsToDictBoxCollider();
        Create(); //TODO: delete after test
    }

    /// <summary>
    /// Заполняем словарь фигур
    /// </summary>
    private void AddVectorsToDictFigure() // расположение фигур
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
    /// Заполняем словарь положения коллайдера для фигур
    /// </summary>
    private void AddVectorsToDictBoxCollider() // первый вектр это положение, второй размер
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
    /// Создать новые фигуры
    /// </summary>
    public void Create()
    {
        foreach (Transform point in _points)
        {
            // создаем родителя
            GameObject parentObj = new GameObject();

            // выбираем и создаем случайную фигуру
            GetNewFigure(parentObj.transform);

            // ставим родителя на свое место
            parentObj.transform.position = point.position;

            // уменьшаем его размер
            parentObj.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
    }

    private void GetNewFigure(Transform parent)
    {
        // внутри родителя создаем кубики, составляя нужную нам фигуру
        int i = Random.Range(1, _dictFigures.Count + 1);
        foreach (Vector3 v3 in _dictFigures[i])
        {
            // создаем кубик у нулевой координате родителя
            GameObject figure = Instantiate(_prefabForFigure, Vector3.zero, Quaternion.identity, parent);

            // двигаем его на свое место
            figure.transform.localPosition = v3;
        }

        // даем родителю имя, в зависимости от выпавшей фигуры
        parent.name = $"figure{i}";

        // устанавливаем тег
        parent.tag = "Figure";

        // добавляем коллайдер
        parent.gameObject.AddComponent<BoxCollider>();

        // корректируем размер и положение коллайдера
        parent.GetComponent<BoxCollider>().center = _dictBoxCollider[i][0];
        parent.GetComponent<BoxCollider>().size = _dictBoxCollider[i][1];
    }
}
