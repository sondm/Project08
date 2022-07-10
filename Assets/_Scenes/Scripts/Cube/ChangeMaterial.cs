using UnityEngine;

namespace Cube
{
    public class ChangeMaterial : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshFigure; // ��� ������
        [SerializeField] private Material _materialGrey; // ������� ��������
        [SerializeField] private Material _materialRed; // ��������, ����� ����� ��� ��������� ������
        [SerializeField] private Material _materialGreen; // �������� ��� ������

        private ListEnums.CubeColor _currentColor; // ������� ���� ������
        public ListEnums.CubeColor GetColor() => _currentColor; // ��������� ����� ���������� ���������

        public void SetMaterial(ListEnums.CubeColor color)
        {
            switch (color)
            {
                case ListEnums.CubeColor.grey:
                    _meshFigure.material = _materialGrey;
                    _currentColor = color;
                    break;
                case ListEnums.CubeColor.red:
                    _meshFigure.material = _materialRed;
                    _currentColor = color;
                    break;
                case ListEnums.CubeColor.green:
                    _meshFigure.material = _materialGreen;
                    _currentColor = color;
                    break;
                default:
                    Debug.LogError("����������� ����!");
                    break;
            }
        }
    }
}
