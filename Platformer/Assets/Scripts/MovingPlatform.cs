using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f; //[HideInInspector]
    [SerializeField] private Transform[] path;
    private int currentPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = path[currentPos].position;
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = speed * Time.deltaTime;
        int nextPos = (currentPos + 1) % path.Length; //1,2,3,0,1
        Vector3 direction = (path[nextPos].position - path[currentPos].position).normalized;

        transform.Translate(direction * amtToMove, Space.World);

        if (Vector3.Distance(transform.position, path[nextPos].position) < 0.5f)
        {
            currentPos = nextPos;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.SetParent(transform, true);
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.SetParent(null, true);
        }
    }
}
