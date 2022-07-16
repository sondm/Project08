using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    /// <summary>
    /// Уничтожение кубиков по присланному списку
    /// </summary>
    public class DestroyCubes : MonoBehaviour
    {
        [SerializeField] private Points.ControlPoints _controlPoints;

        public void DestroyThisLineCubes(List<GameObject> listObjs)
        {
            StartCoroutine(DeleteLineCubes(listObjs));
        }

        private IEnumerator DeleteLineCubes(List<GameObject> listObjs)
        {
            float f = .9f;
            foreach (GameObject obj in listObjs)
            {
                //obj.GetComponent<ChangeMaterial>().SetMaterial(ListEnums.CubeColor.green);
                Destroy(obj, f);
                f -= .1f;
            }
            _controlPoints.AddPoints(10); // за уничтожение линии начисляем 10 очков
            yield return null;
        }
    }
}
