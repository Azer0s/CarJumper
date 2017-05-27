using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtility
{
    private static Dictionary<RecycledGameObject,ObjectPool> _pools = new Dictionary<RecycledGameObject, ObjectPool>();

    private static ObjectPool GetObjectPool(RecycledGameObject reference)
    {
        ObjectPool pool = null;

        if (_pools.ContainsKey(reference))
        {
            pool = _pools[reference];
        }
        else
        {
            var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.Prefab = reference;

            _pools.Add(reference,pool);
        }

        return pool;
    }
    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        GameObject instance = null;

        var recycledScript = prefab.GetComponent<RecycledGameObject>();
        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pos).gameObject;
        }
        else
        {
            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }

        return instance;
    }

    public static void Destroy(GameObject gameObject)
    {
        var recycledGameObject = gameObject.GetComponent<RecycledGameObject>();

        if (recycledGameObject != null)
        {
            recycledGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
}
