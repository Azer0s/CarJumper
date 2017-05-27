using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public RecycledGameObject Prefab;
    private List<RecycledGameObject> _poolInstances = new List<RecycledGameObject>();

    private RecycledGameObject CreateInstance(Vector3 pos)
    {
        var clone = GameObject.Instantiate(Prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;

        _poolInstances.Add(clone);
        return clone;
    }

    public RecycledGameObject NextObject(Vector3 pos)
    {
        RecycledGameObject instance = null;

        foreach (var go in _poolInstances)
        {
            if (go.gameObject.activeSelf != true)
            {
                instance = go;
                instance.transform.position = pos;
            }
        }

        if (instance == null)
        {
            instance = CreateInstance(pos);
        }

        instance.Restart();

        return instance;
    }
}
