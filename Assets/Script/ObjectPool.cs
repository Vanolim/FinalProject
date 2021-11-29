using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<Ball> _pool = new List<Ball>();

    protected void Initialize(Ball prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab.gameObject, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned.GetComponent<Ball>());
        }
    }

    protected bool TryGetObject(out Ball result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    protected List<Ball> ReturnActiveObjectsPool()
    {
        List<Ball> activeGameObjects = new List<Ball>();

        foreach (var item in _pool)
        {
            if (item.gameObject.activeSelf)
                activeGameObjects.Add(item.GetComponent<Ball>());
        }

        return activeGameObjects;
    }
}
