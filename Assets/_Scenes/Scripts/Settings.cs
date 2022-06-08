using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("��������� �����")]
    [SerializeField] private float _soundVolume = 1f;
    [SerializeField] private float _musicVolume = 1f;

    [Header("���������� ���������")]
    [SerializeField]
    [Tooltip("����������� ������� ������")]
    [Range(30, 90)]
    private int _frameRate = 50;

    private void Awake()
    {
        Application.targetFrameRate = _frameRate;
    }
}
