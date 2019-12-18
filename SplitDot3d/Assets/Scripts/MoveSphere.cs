using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    Transform transf;

    Vector3 dir = Vector3.up;
    Vector3 startPos;
    [SerializeField]
    bool startMove = false;
    

    [SerializeField]
    [Range(0, 50)]
    static float speed = 5;

    void Start()
    {
        transf = gameObject.transform;
    }


    bool blockDestroy;
    public void Move(Vector3 dir)
    {
        this.dir = dir;
        startMove = true;
        blockDestroy = true;
        StartCoroutine(block());
    }
    IEnumerator block()
    {
        yield return new WaitForSeconds(0.1f);
        blockDestroy = false;
    }

    
    public void Hide()
    {
        startMove = false;
        transf.position = new Vector3(0, -1000, 0);
    }

    IEnumerator split()
    {
        GameObject left = PoolSpheres.InstantiateFromPool();
        GameObject right = PoolSpheres.InstantiateFromPool();

        if (left != null && right != null)
        {
            left.transform.position = right.transform.position = transf.position;

            left.GetComponent<MoveSphere>().Move(new Vector3(transf.localEulerAngles.x - 45, transf.localEulerAngles.y, transf.localEulerAngles.z));
            right.GetComponent<MoveSphere>().Move(new Vector3(transf.localEulerAngles.x + 45, transf.localEulerAngles.y, transf.localEulerAngles.z));
            Hide();
        }
        yield return null;
    }
    void Update()
    {
        
        transf.rotation = Quaternion.Euler(dir);
        if(startMove)
        {
            transf.position += transf.forward * speed * Time.deltaTime;
            if(Input.GetMouseButtonDown(0) && !blockDestroy)
            {
               
                StartCoroutine(split());
                
                PoolSpheres.DestroyInPool(gameObject);
                


            }
        }
        
    }
}
