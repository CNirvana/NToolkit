using UnityEngine;
using System.Collections.Generic;

namespace Nirvana.Toolkit
{
    public class Pool
    {
        private List<GameObject> _list;
        private GameObject _prefab;

        public Pool(GameObject prefab, int initialSize)
        {
            _prefab = prefab;
            _list = new List<GameObject>(initialSize);
            this.Preload(initialSize);
        }

        public void Preload(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var go = Object.Instantiate(_prefab);
                go.SetActive(false);
                _list.Add(go);
            }
        }

        public void PreloadTo(int count)
        {
            for (int i = _list.Count; i < count; i++)
            {
                var go = Object.Instantiate(_prefab);
                go.SetActive(false);
                _list.Add(go);
            }
        }

        public GameObject Get()
        {
            if (_list.Count == 0)
            {
                this.Preload(1);
            }

            var go = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            go.SetActive(true);
            return go;
        }

        public void Release(GameObject go)
        {
            go.SetActive(false);
            _list.Add(go);
        }
    }
}