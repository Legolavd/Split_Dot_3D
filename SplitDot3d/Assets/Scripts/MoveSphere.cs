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

    private void Awake()
    {
        transf = gameObject.transform;

    }
    void Start()
    {
       
    }


    bool blockDestroy;

    bool blockCollision;
    public void Move(Vector3 dir)
    {
        this.dir = dir;
        startMove = true;
        blockDestroy = true;
        blockCollision = true;
        StartCoroutine(block());
    }
    IEnumerator block()
    {
        yield return new WaitForSeconds(0.1f);
        blockDestroy = false;
        StartCoroutine(BlockCollision());
    }
    IEnumerator BlockCollision()
    {
        blockCollision = true;
        yield return new WaitForSeconds(0.4f);
        blockCollision = false;
    }
    public void Hide()
    {
        startMove = false;
        transf.position = new Vector3(0, -1000, 0);
        TrailRenderer tr = gameObject.GetComponent<TrailRenderer>();
        tr.enabled = false;
    }

    IEnumerator split()
    {
        GameObject left = PoolSpheres.InstantiateFromPool();
        GameObject right = PoolSpheres.InstantiateFromPool();

        if (left != null && right != null)
        {
            left.transform.position = right.transform.position = transf.position;

            StartCoroutine(BlockCollision());
            left.GetComponent<MoveSphere>().Move(new Vector3(transf.localEulerAngles.x - 40, transf.localEulerAngles.y, transf.localEulerAngles.z));
            right.GetComponent<MoveSphere>().Move(new Vector3(transf.localEulerAngles.x + 40, transf.localEulerAngles.y, transf.localEulerAngles.z));

            TrailRenderer trLeft = left.GetComponent<TrailRenderer>();
            TrailRenderer trRight = right.GetComponent<TrailRenderer>();

            trLeft.enabled = trRight.enabled = true;

            Hide();
        }
        yield return null;
    }
    void Update()
    {
        transf.rotation = Quaternion.Euler(dir);
        if(startMove)
        {
            if (MoveCamera.Y +30 < transf.position.y)
            {
                MoveCamera.Y = transf.position.y -30;
            }
            transf.position += transf.forward * speed * Time.deltaTime;
            if(Input.GetMouseButtonDown(0) && !blockDestroy)
            {
                StartCoroutine(split());
                PoolSpheres.DestroyInPool(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Hide();
            PoolSpheres.DestroyInPool(gameObject);
        }

        else if (!blockCollision)
        {
            if (other.gameObject.tag == "Sphere")
            {
                Hide();
                PoolSpheres.DestroyInPool(gameObject);
            }
        }

        
    }
}
