using UnityEngine;

namespace StateGame
{
    /// <summary>
    /// Выбор фигуры
    /// </summary>
    public class SelectingFigure : MonoBehaviour
    {
        private float _raycastMaxDistance = 60f;

        public GameObject GetObject(Camera mainCamera)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _raycastMaxDistance))
            {
                Debug.Log("Срабоатл GetObject");
                if (hit.transform.tag == "Figure")
                {
                    return hit.transform.gameObject;
                }
            }
            return null;
        }
    }
}
