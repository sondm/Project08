using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene01
{
    public class ControlScene : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefabCell;

        void Start()
        {
            CreateGrid createGrid = new CreateGrid(_prefabCell);
            createGrid.Create();
        }
    }
}
