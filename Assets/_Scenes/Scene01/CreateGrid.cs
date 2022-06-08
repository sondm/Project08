using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene01
{
    /// <summary>
    /// Создание игровой сетки
    /// </summary>
    public class CreateGrid
    {
        private int _countGridX = 10;
        private int _countGridY = 10;
        private GameObject _prefabCell;

        public CreateGrid (GameObject prefab)
        {
            _prefabCell = prefab;
        }

        public void Create()
        {
            for (float x = 0; x < _countGridX; x+=1f)
            {
                for (float y = 0; y < _countGridY; y+=1f)
                {
                    Object.Instantiate(_prefabCell, new Vector3(x, y, 0f), Quaternion.identity);
                }
            }
        }
    }
}
