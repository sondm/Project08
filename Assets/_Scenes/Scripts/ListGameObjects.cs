using UnityEngine;

public class ListGameObjects : MonoBehaviour
{
    public static ListGameObjects Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Основные объекты")]
    [SerializeField]
    private Camera _mainCamera;
    public Camera GetMainCamera() => _mainCamera;

    [Header("Префабы")]
    [SerializeField]
    private GameObject _prefabPopupDamage;
    public GameObject GetPrefabPopupDamage() => _prefabPopupDamage;
}
