using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Obstacle
    {
        public GameObject enemyPrefab;
        public float maxX;
        public float minX;
        public float maxY;
        public float minY;
    }
}
