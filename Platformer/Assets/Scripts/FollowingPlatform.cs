using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlatform : MonoBehaviour
{
    [SerializeField] private Transform follow;

    void Update()
    {
        transform.LookAt(follow);
    }
    
}
