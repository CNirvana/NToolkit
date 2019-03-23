using System.Collections.Generic;
using UnityEngine;

namespace Nirvana.Toolkit
{
    public class PoolManager : SingletonBehaviour<PoolManager>
    {
        private Dictionary<GameObject, Pool> _pools = new Dictionary<GameObject, Pool>();
        private Dictionary<GameObject, Pool> _lookup = new Dictionary<GameObject, Pool>();

        public void Preload(GameObject prefab, int count)
        {
            if (!this.TryCreatePool(prefab, count))
            {
                _pools[prefab].Preload(count);
            }
        }

        public void PreloadTo(GameObject prefab, int count)
        {
            if (!this.TryCreatePool(prefab, count))
            {
                _pools[prefab].PreloadTo(count);
            }
        }

        public GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            this.TryCreatePool(prefab, 1);
            var go = _pools[prefab].Get();
            _lookup.Add(go, _pools[prefab]);
            go.SetActive(true);
            go.transform.localPosition = position;
            go.transform.localRotation = rotation;
            go.transform.localScale = prefab.transform.localScale;
            return go;
        }

        public void ReleaseObject(GameObject go)
        {
            if (!_lookup.ContainsKey(go))
            {
                Debug.LogWarning("No pool contains the object: " + go.name);
                Destroy(go);
                return;
            }

            var pool = _lookup[go];
            pool.Release(go);
            _lookup.Remove(go);
        }

        private bool TryCreatePool(GameObject prefab, int size)
        {
            if (!_pools.ContainsKey(prefab))
            {
                var pool = new Pool(prefab, size);
                _pools.Add(prefab, pool);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}