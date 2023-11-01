using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectPool
{
    public Type PoolType;
    public string ObjectName = "";

    public float lastUsed = 0.0f;

    // Returns object count in the pool
    public int ObjectCount
    {
        // TODO: Return object count
        get { return m_PoolGameObjects.Count; }
    }

    // Returns an object whether it is already exist or not
    public GameObject GetObject(GameObject prefab)
    {
        // TODO: Look for disabled objects in the pool
        GameObject retrievedObject = null;
        var disabledObjects = m_PoolGameObjects.Where(x => x.activeSelf == false);

        // TODO: If any disabled objects exist, store it's reference in retrievedObject
        if (disabledObjects.Any())
        {
            retrievedObject = disabledObjects.First();
        }

        // TODO: If no disabled objects exist, call createNewObject function and save output to retrievedObject
        if (retrievedObject == null)
        {
            retrievedObject = CreateNewObject(prefab);
        }

        // TODO: Finally set retrieved object's state to active and update lastUsed flag
        retrievedObject.SetActive(true);

        lastUsed = Time.time;
        Debug.Log(lastUsed);

        // TODO: Return the object
        return retrievedObject;
    }

    // Removes disabled objects from common pool
    public void RemoveDisabledObjects()
    {
        // TODO: Separate all disabled objects from common pool of objects
        var disabledObjects = m_PoolGameObjects.Where(x => x.activeSelf == false);

        // TODO: destroy all disabled objects
        foreach (var disabledObject in disabledObjects)
        {
            GameObject.Destroy(disabledObject);
        }

        // TODO: update lastUsed flag
        lastUsed = Time.time;
    }

    // This function adds a new object to the common pool
    public GameObject CreateNewObject(GameObject prefab)
    {
        // TODO: Request object from PoolManager's Object creator function
        GameObject returnObject = PoolManager.ObjectCreator(prefab);

        // TODO: Add object to the common pool of objects
        m_PoolGameObjects.Add(returnObject);

        // TODO: Return the object 
        return returnObject;

    }

    List<GameObject> m_PoolGameObjects = new List<GameObject>();
}
