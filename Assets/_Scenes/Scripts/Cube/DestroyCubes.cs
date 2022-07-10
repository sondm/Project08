using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    /// <summary>
    /// ”ничтожение кубиков по присланному списку
    /// </summary>
    public class DestroyCubes : MonoBehaviour
    {
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
            yield return null;
        }
    }
}
