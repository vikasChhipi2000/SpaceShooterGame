using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(menuName ="Enemy Wave property")]
public class WaveConf : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int noOfEnemy = 5;
    [SerializeField] float speed = 2f;
    [SerializeField] float spawnTime = .5f;
    [SerializeField] float randomFactorInSpawn = .3f;

    public GameObject getEnemyPrefab() { return enemyPrefab;  }
    public List<Transform> getWaypoints() 
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public int getNoOfEnemy() { return noOfEnemy; }
    public float getSpeed() { return speed; }
    public float getSpawnTime() { return spawnTime; }
    public float getRandomFactorInSpawn() { return randomFactorInSpawn; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
