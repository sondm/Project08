using UnityEngine;

namespace Cube
{
    public class ChangeMaterial : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshFigure; // меш кубика
        [SerializeField] private Material _materialGrey; // обычный материал
        [SerializeField] private Material _materialRed; // материал, когда место для установки занято
        [SerializeField] private Material _materialGreen; // материал для тестов

        private ListEnums.CubeColor _currentColor; // текущий цвет кубика
        public ListEnums.CubeColor GetColor() => _currentColor; // получение цвета сторонними скриптами

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
                    Debug.LogError("Неизвестный цвет!");
                    break;
            }
        }
    }
}
