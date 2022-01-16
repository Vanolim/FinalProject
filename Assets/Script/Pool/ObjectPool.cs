using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> where T : PoolableObject
{
    private readonly T _prefab;
    private readonly GameObject _container;
    private readonly int _capacity;

    private List<T> _pool;

    public ObjectPool(T prefab, GameObject container, int capacity)
    {
        _prefab = prefab;
        _container = container;
        _capacity = capacity;
        
        Init();
    }

    private void Init()
    {
        _pool = new List<T>(_capacity);

        for (int i = 0; i < _capacity; i++)
        {
            T spawned = Object.Instantiate(_prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }

    public IReadOnlyList<T> ActiveObjects()
    {
        return _pool.Where(t => t.gameObject.activeSelf).ToList();
    }
}
