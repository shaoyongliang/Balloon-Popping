using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 movedPos = transform.position;
        movedPos.x += speed * Time.deltaTime;
        transform.position = movedPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        speed *= -1;
    }

}
