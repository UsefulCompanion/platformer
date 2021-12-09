using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
     public void OnDrawGizmos()
     {
          Gizmos.DrawIcon(transform.position,"danger_zone");
     }
}
