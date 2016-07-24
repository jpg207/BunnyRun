using UnityEngine;
using System.Collections;

public class Prefab_Spawner : MonoBehaviour {

    private float NextSpawn = 0;
    public Transform PrefabToSpawn;
    //public float SpawnRate = 1;
    //public float RandomDelay = 1;
    public AnimationCurve SpawnCurve;
    public float CurveLengthInSeconds = 30f;
    private float StartTime;
    public float Jitter = 0.25f;

	// Use this for initialization
	void Start () {
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.time > NextSpawn)
        {
            Instantiate(PrefabToSpawn, transform.position, Quaternion.identity);
            //NextSpawn = Time.time + SpawnRate + Random.Range(0, RandomDelay);
            float CurvePos = (Time.time - StartTime) / CurveLengthInSeconds;
            if (CurvePos > 1f)
            {
                CurvePos = 1f;
                StartTime = Time.time;
            }

            NextSpawn = Time.time + SpawnCurve.Evaluate(CurvePos) + Random.Range(-Jitter, Jitter);
        }
	}
}
