using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpheres : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    static Transform parent;

    [SerializeField]
    static Stack<GameObject> poolHide = new Stack<GameObject>();

    [SerializeField]
    [Range(1, 300)]
    int SizePool = 100;

    public static int currentObject = 0;
    void Start()
    {
        parent = GameObject.Find("Pool").transform;
        for(int i = 0; i < SizePool; i++)
        {
            GameObject obj = Instantiate(prefab, parent);
            obj.name = obj.name + i;
            poolHide.Push(obj);
        }
        poolHide.Peek().transform.position = new Vector3(0, 0, 0);
    }
   
    public static GameObject InstantiateFromPool()
    {
        if(poolHide.Count > 0)
        {
            return poolHide.Pop();
        }
        return null;
    }
    public static void DestroyInPool(GameObject obj)
    {
        poolHide.Push(obj);
    }
   


}
