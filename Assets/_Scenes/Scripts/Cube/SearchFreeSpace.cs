using UnityEngine;

namespace Cube
{
    /// <summary>
    /// ѕоиск свободного места на этапе step2, дл€ установки фигуры на поле
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
        /// ѕускаем луч "назад" в поиске уже установленной фигуры
        /// </summary>
        private bool CheckBackObj()
        {
            // ѕерва€ проверка, есть ли сзади кубик
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.transform.tag == "Cube")
                {
                    //Debug.Log("ћесто зан€то");
                    _changeMaterial.SetMaterial(ListEnums.CubeColor.red);
                    _readyToPlace = false;
                    return true;
                }
            }

            // ¬тора проверка, провер€ем границы игрового пол€
            if (transform.position.x < -.1f || transform.position.x > 9f)
            {
                _readyToPlace=false;
                return true;
            }    
            else if (transform.position.y < -.1f || transform.position.y > 9f)
            {
                _readyToPlace = false;
                return true;
            }
            
            // ћен€ем цвет в зависимости от разрешени€
            if (_changeMaterial.GetColor() == ListEnums.CubeColor.red)
                _changeMaterial.SetMaterial(ListEnums.CubeColor.grey);
            _readyToPlace = true;
            return false;
        }

        /// <summary>
        /// ≈сть свободное пространство под кубиком или нет
        /// </summary>
        /// <returns>true = можно ставить</returns>
        public bool ReadyToPlace() => _readyToPlace;
    }
}
