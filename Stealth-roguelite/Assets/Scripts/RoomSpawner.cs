using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplate templates;
    public bool spawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn() {
        if (!spawned) {
            if (openingDirection == 1) {
                // Need to spawn a room with a BOTTOM door.
                Debug.Log("Spawning a room with a BOTTOM door.");
                Instantiate(templates.bottomRooms[Random.Range(0, templates.bottomRooms.Length)], transform.position, Quaternion.identity);
            } else if (openingDirection == 2) {
                // Need to spawn a room with a TOP door.
                Debug.Log("Spawning a room with a TOP door.");
                Instantiate(templates.topRooms[Random.Range(0, templates.topRooms.Length)], transform.position, Quaternion.identity);
            } else if (openingDirection == 3) {
                // Need to spawn a room with a LEFT door.
                Debug.Log("Spawning a room with a LEFT door.");
                Instantiate(templates.leftRooms[Random.Range(0, templates.leftRooms.Length)], transform.position, Quaternion.identity);
            } else if (openingDirection == 4) {
                // Need to spawn a room with a RIGHT door.
                Debug.Log("Spawning a room with a RIGHT door.");
                Instantiate(templates.rightRooms[Random.Range(0, templates.rightRooms.Length)], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned) {
            Destroy(gameObject);
        }
    }
}
