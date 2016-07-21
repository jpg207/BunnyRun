using UnityEngine;
using System.Collections;

public class Prefab_Spawner : MonoBehaviour {

    private float NextSpawn = 0;
    public Transform PrefabToSpawn;
    public float SpawnRate = 1;
    public float RandomDelay = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.time > NextSpawn)
        {
            Instantiate(PrefabToSpawn, transform.position, Quaternion.identity);
            NextSpawn = Time.time + SpawnRate + Random.Range(0, RandomDelay);
        }
	}
}
