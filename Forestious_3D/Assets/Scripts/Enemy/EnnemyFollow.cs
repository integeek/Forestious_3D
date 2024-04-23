using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnnemyFollow : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }
}
