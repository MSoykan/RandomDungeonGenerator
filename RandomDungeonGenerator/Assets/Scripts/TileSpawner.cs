using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    DungeonManager dungeonManager;

    private void Awake()
    {
        dungeonManager = FindObjectOfType<DungeonManager>();
        GameObject goFloor = Instantiate(dungeonManager.floorPrefab, transform.position, Quaternion.identity) as GameObject;
        goFloor.name = dungeonManager.floorPrefab.name;
        goFloor.transform.SetParent(dungeonManager.transform);
    }

    void Start()
    {
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, Vector2.one);
    }
}
