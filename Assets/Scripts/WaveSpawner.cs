using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] List<WaveConf> waveList;
    [SerializeField] int index = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(swapnAllWave());
        } while (looping);
    }

    IEnumerator swapnAllWave()
    {
        for(int i = index; i < waveList.Count; i++)
        {
            WaveConf current = waveList[i];
            yield return StartCoroutine(bulidWave(current));
        }
    }

    IEnumerator bulidWave(WaveConf current)
    {
        List<Transform> waypoints = current.getWaypoints();
        for(int i = 0; i < current.getNoOfEnemy(); i++)
        {
            var enemy = Instantiate(current.getEnemyPrefab(), current.getWaypoints()[0].position, Quaternion.identity);
            enemy.GetComponent<EnemyPath>().setWaveConf(current);
            yield return new WaitForSeconds(current.getSpawnTime());
        }
    }
}
