using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnPoint : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "spawnpoint");
    }
}
