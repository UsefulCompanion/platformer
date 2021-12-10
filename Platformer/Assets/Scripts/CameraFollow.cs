using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float distanceAway;
    [SerializeField] private float distanceUp;
    [SerializeField] private float smooth;
    [SerializeField] private Transform follow;
    private Vector3 targetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        if (follow == null)
        {
            follow = GameObject.Find("Player").transform;
        }
    }

    void LateUpdate()
    {
        targetPos = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smooth);
        
        transform.LookAt(follow);
    }
}
