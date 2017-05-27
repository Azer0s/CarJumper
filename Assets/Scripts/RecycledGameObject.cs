using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IRecycle
{
    void Restart();
    void Shutdown();
}

public class RecycledGameObject : MonoBehaviour
{
    private List<IRecycle> _recycledComponents;

    public void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        _recycledComponents = new List<IRecycle>();

        components.Where(a => a is IRecycle).Select(a => a).ToList().ForEach(a => _recycledComponents.Add(a as IRecycle));
    }

    public void Restart()
    {
        gameObject.SetActive(true);

        foreach (var comp in _recycledComponents)
        {
            comp.Restart();
        }
    }

    public void Shutdown()
    {
        gameObject.SetActive(false);

        foreach (var comp in _recycledComponents)
        {
            comp.Shutdown();
        }
    }
}
