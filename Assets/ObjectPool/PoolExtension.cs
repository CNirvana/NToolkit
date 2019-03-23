using UnityEngine;

namespace Nirvana.Toolkit
{
    public static class PoolExtension
    {
        public static void Preload(this GameObject prefab, int count)
        {
            PoolManager.Instance.Preload(prefab, count);
        }

        public static void Preload<T>(this T component, int count) where T : MonoBehaviour
        {
            Preload(component.gameObject, count);
        }

        public static void PreloadTo(this GameObject prefab, int count)
        {
            PoolManager.Instance.PreloadTo(prefab, count);
        }

        public static void PreloadTo<T>(this T component, int count) where T : MonoBehaviour
        {
            PreloadTo(component.gameObject, count);
        }

        public static GameObject New(this GameObject go)
        {
            return PoolManager.Instance.SpawnObject(go, go.transform.localPosition, go.transform.localRotation);
        }

        public static T New<T>(this T component) where T : MonoBehaviour
        {
            return New(component.gameObject).GetComponent<T>();
        }

        public static GameObject New(this GameObject go, Vector3 position, Quaternion rotation)
        {
            return PoolManager.Instance.SpawnObject(go, position, rotation);
        }

        public static T New<T>(this T component, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            return New(component.gameObject, position, rotation).GetComponent<T>();
        }

        public static void Delete(this GameObject go)
        {
            PoolManager.Instance.ReleaseObject(go);
        }

        public static void Delete<T>(this T component) where T : MonoBehaviour
        {
            Delete(component.gameObject);
        }
    }
}