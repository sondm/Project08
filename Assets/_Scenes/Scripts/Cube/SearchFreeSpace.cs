using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    /// <summary>
    /// ����� ���������� ����� �� ����� step2, ��� ��������� ������ �� ����
    /// </summary>
    public class SearchFreeSpace : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshFigure;
        [SerializeField] private Material _materialGrey;
        [SerializeField] private Material _materialRed;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GetBackObj();
        }

        /// <summary>
        /// ������� ��� "�����" � ������ ��� ������������� ������
        /// </summary>
        private bool GetBackObj()
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.transform.tag == "Cube")
                {
                    Debug.Log("����� ���");
                    //_material.color = Color.blue;
                    //_materialGrey.SetColor("Albedo", Color.blue);
                    //_meshFigure.materials[0].SetColor("Albedo", Color.blue);
                    _meshFigure.materials[0] = _materialRed;
                }
                //else _material.color = Color.gray;
            }
            return false;
        }
    }
}
