using UnityEngine;

namespace Cube
{
    /// <summary>
    /// Поиск свободного места на этапе step2, для установки фигуры на поле
    /// </summary>
    /// 
    [RequireComponent(typeof(ChangeMaterial))]
    public class SearchFreeSpace : MonoBehaviour
    {
        private ChangeMaterial _changeMaterial;
        private bool _readyToPlace = false; // true - фигура готова к размещению

        private void Start()
        {
            _changeMaterial = GetComponent<ChangeMaterial>();
            _changeMaterial.SetMaterial(ListEnums.CubeColor.grey);
        }

        private void Update()
        {
            CheckBackObj();
        }

        /// <summary>
        /// Пускаем луч "назад" в поиске уже установленной фигуры
        /// </summary>
        private bool CheckBackObj()
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.transform.tag == "Cube")
                {
                    //Debug.Log("Место занято");
                    _changeMaterial.SetMaterial(ListEnums.CubeColor.red);
                    _readyToPlace = false;
                    return true;
                }
            }

            if (_changeMaterial.GetColor() == ListEnums.CubeColor.red)
                _changeMaterial.SetMaterial(ListEnums.CubeColor.grey);
            _readyToPlace = true;
            return false;
        }

        /// <summary>
        /// Есть свободное пространство под кубиком или нет
        /// </summary>
        /// <returns>true = можно ставить</returns>
        public bool ReadyToPlace() => _readyToPlace;
    }
}
