using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    [SerializeField]
    private NavMeshSurface surface;

    public List<GameObject> rooms;
    private float waitTime = 0.5f;

    private void Update() {
        if(waitTime <= 0) {
            surface.BuildNavMesh();
        } else {
            waitTime -= Time.deltaTime;
        }
    }
}
