using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static bool listenTouch = true;
    void Start()
    {
        
    }

    void Update()
    {
        ClickListener();
    }

    void ClickListener()
    {
        if (!listenTouch)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.startLvl)
            {
                GameManager.startLvl = false;
                GameObject firstObj = PoolSpheres.InstantiateFromPool();
                firstObj.transform.position = new Vector3(0, 0, 0);
                firstObj.GetComponent<MoveSphere>().Move(new Vector3(-90, 90, 180));
            }
        }

    }
    
}
