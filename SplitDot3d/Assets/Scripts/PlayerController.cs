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
                PoolSpheres.MoveFirst();
            }
            else if(PoolSpheres.currentObject > 0)
            {
                PoolSpheres.Ad
            }
        }

    }
    
}
