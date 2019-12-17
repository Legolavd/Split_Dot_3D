using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    Transform transf;

    Vector3 dir = Vector3.up;
    Vector3 startPos;
    bool startMove = false;
    

    [SerializeField]
    [Range(0, 50)]
    static float speed = 5;

    void Start()
    {
        transf = gameObject.transform;
    }

    public void Move(Vector3 dir)
    {
        this.dir = dir;
        startMove = true;
    }
    public void Hide()
    {
        startMove = false;
    }
    void Update()
    {
        
        transf.localRotation = Quaternion.Euler(-90, -90 , 0);
        Debug.Log(transf.localRotation);
        
        if(startMove)
        {
            transf.position += transf.forward * speed * Time.deltaTime;
        }
        
    }
}
