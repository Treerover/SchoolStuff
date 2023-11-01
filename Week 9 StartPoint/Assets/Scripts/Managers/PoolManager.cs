using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    //Pool refresh rate
    public float m_PoolRefreshRate = 15.0f;
    public float SecondsStaleBeforeClamp = 10.0f;

    // Use this for initialization
    void Start()
    {
    }

    // We need a way to create a new pool, this function should implement this functionality
    private static ObjectPool CreateNewPool(GameObject prefab)
    {
        // TODO: instantiate new pool and assign type and name
        ObjectPool pool = new ObjectPool();
        pool.PoolType = prefab.GetType();
        pool.ObjectName = prefab.name;

        // TODO: store new pool handle in the list of object pool objects
        m_Pools.Add(pool);

        // TODO: return newly created pool
        return pool;
    }

    // This function should simplify pool finding process
    public static ObjectPool GetPool(string name, Type type)
    {
        // TODO: look for the pool with matching type and name
        ObjectPool pool = m_Pools.Find(x => x.ObjectName == name && x.PoolType == type);

        // TODO: return pool if found other ways return null
        return pool;
    }

    //  This function ment to be wrapped into the other Get function. It must return object pool
    public static GameObject Get(GameObject prefab)
    {
        // TODO: call existing GetPool function, pass name and type as arguments
        ObjectPool pool = GetPool(prefab.name, prefab.GetType());

        // TODO: if pool does not exist create a new one that is based on provided prefab
        if (pool == null)
        {
            pool = CreateNewPool(prefab);
        }

        // TODO: request a new object from the pool. Use GetObject functionality
        GameObject obj = pool.GetObject(prefab);


        // TODO: set object's state to active. use SetActive API
        obj.SetActive(true);

        // TODO: return object
        return obj;
    }

    // This function should be used by the code that requires a particular pool object. It must return a game object
    public static GameObject Get(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        // TODO: Call existing Get functionality
        GameObject obj = Get(prefab);

        // TODO: Use returned game object to set its position and rotation
        obj.transform.position = pos;
        obj.transform.rotation = rot;

        // TODO: Return the object
        return obj;
    }

    // Responsible for the object instantiation
    public static GameObject ObjectCreator(GameObject prefab)
    {
        // TODO: instantiate object based on the provided prefab and return instantiated object
        GameObject obj = Instantiate(prefab);

        return obj;
    }

    private IEnumerator CleanPools ()
    {
        while (true)
        {
            List<ObjectPool> poolsToDel = new List<ObjectPool>();
        }
    }

    static List<ObjectPool> m_Pools = new List<ObjectPool>();
}
