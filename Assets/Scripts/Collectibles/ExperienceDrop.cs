using System;
using Player;
using UnityEngine;

namespace Collectibles
{
    public class ExperienceDrop : MonoBehaviour
    {
        public int experienceValue;

        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}
