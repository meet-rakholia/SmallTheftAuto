using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletPoolManager : MonoBehaviour
    {
        public GameObject bullet;
        public int poolSize = 50;
        private List<GameObject> bulletPool = new List<GameObject>();

        private void Start()
        {
            InitalizePool();
        }

        private void InitalizePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject b = Instantiate(bullet);
                bullet.SetActive(false);
                bulletPool.Add(b);
            }
        }

        public GameObject getBullet()
        {
            for (int i = 0; i < bulletPool.Count; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    return bulletPool[i];
                }
            }

            return null;
        }
    }
}