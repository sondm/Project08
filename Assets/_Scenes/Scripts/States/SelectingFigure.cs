using UnityEngine;

namespace StateGame
{
    /// <summary>
    /// Выбор фигуры
    /// </summary>
    public class SelectingFigure : MonoBehaviour
    {
        private float _raycastMaxDistance = 160f;

        public GameObject GetObject(Camera mainCamera)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _raycastMaxDistance))
            {
                if (hit.transform.tag == "Figure")
                {
                    //Debug.Log("Click to obj - " + hit.transform.name);
                    return hit.transform.gameObject;
                }
            }
            return null;
        }
    }
}
