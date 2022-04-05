using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace.Managers
{
    public class ResourceManager : IResourceManager
    {
        public T CreatePrefabInstance<T, E>(E item) where E : Enum
        {
            var prefab = CreatePrefabInstance(item);
            var result = prefab.GetComponent<T>();

            return result;
        }

        public GameObject CreatePrefabInstance<E>(E item) where E : Enum
        {
            var path = $"{typeof(E).Name}/{item.ToString()}";
            var asset = Resources.Load<GameObject>(path);
            var result = Object.Instantiate(asset);

            return result;
        }

        public T GetAsset<T, E>(E item)
            where T : Object
            where E : Enum
        {
            var path = $"{typeof(E).Name}/{item.ToString()}";
            var result = Resources.Load<T>(path);

            return result;
        }
    }
}