using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float edge = 10f;
    public float movementRandom = 0.1f;
    public float appleDrops = 1f;
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDrops);
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -edge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > edge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }
    void FixedUpdate()
    {
        if (Random.value < movementRandom)
        {
            speed *= -1;
        }
    }
}
