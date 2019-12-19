using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public static bool startMove = false;

    public static float Y;

    public static float speed = 3;

    public bool limit = false;

    private void Start()
    {
        Y = gameObject.transform.position.y; 
    }
    void Update()
    {

        if (startMove)
        {
            Y += speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Y, transform.position.z);

        }
    }

    IEnumerator stopMove_Second(float second)
    {
        startMove = false;
        yield return new WaitForSeconds(second);
        startMove = true;
    }

    public static void StartMove()
    {
        startMove = true;
    }

   
}
