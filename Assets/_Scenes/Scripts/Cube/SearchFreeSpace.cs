using UnityEngine;

namespace Cube
{
    /// <summary>
    /// ����� ���������� ����� �� ����� step2, ��� ��������� ������ �� ����
    /// </summary>
    /// 
    [RequireComponent(typeof(ChangeMaterial))]
    public class SearchFreeSpace : MonoBehaviour
    {
        private ChangeMaterial _changeMaterial;
        private bool _readyToPlace = false; // true - ������ ������ � ����������

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
        /// ������� ��� "�����" � ������ ��� ������������� ������
        /// </summary>
        private bool CheckBackObj()
        {
            // ������ ��������, ���� �� ����� �����
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.transform.tag == "Cube")
                {
                    //Debug.Log("����� ������");
                    _changeMaterial.SetMaterial(ListEnums.CubeColor.red);
                    _readyToPlace = false;
                    return true;
                }
            }

            // ����� ��������, ��������� ������� �������� ����
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
            
            // ������ ���� � ����������� �� ����������
            if (_changeMaterial.GetColor() == ListEnums.CubeColor.red)
                _changeMaterial.SetMaterial(ListEnums.CubeColor.grey);
            _readyToPlace = true;
            return false;
        }

        /// <summary>
        /// ���� ��������� ������������ ��� ������� ��� ���
        /// </summary>
        /// <returns>true = ����� �������</returns>
        public bool ReadyToPlace() => _readyToPlace;
    }
}
