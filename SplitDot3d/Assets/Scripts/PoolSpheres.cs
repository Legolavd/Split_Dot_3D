using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpheres : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    static Transform parent;

    [SerializeField]
    static List<GameObject> pool = new List<GameObject>();

    [SerializeField]
    [Range(1, 300)]
    int SizePool = 100;

    public static int currentObject = 0;
    void Start()
    {
        for(int i = 0; i < SizePool; i++)
        {
            pool.Add(Instantiate(prefab, parent));
        }
        AddFirstObjectInScene();
    }

    public void AddFirstObjectInScene()
    {
        pool[currentObject].transform.position = new Vector3(0, 0, 0);
    }
    public static void MoveFirst()
    {
        pool[currentObject].GetComponent<MoveSphere>().Move(Vector3.forward);
        currentObject++;
    }
    public static void AddObjectInScene()
    {
        
    }

   


    // Update is called once per frame
    void Update()
    {
        
    }


}
