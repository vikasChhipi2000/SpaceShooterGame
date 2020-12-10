using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    WaveConf waveConf;
    List<Transform> wayPoints;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConf.getWaypoints();
        transform.position = wayPoints[index].position;
    }

    public void setWaveConf(WaveConf waveConf)
    {
        this.waveConf = waveConf;
    }

    // Update is called once per frame
    void Update()
    {
        if(index <= wayPoints.Count - 1)
        {
            Vector2 targetPoint = wayPoints[index].position;
            float waveSpeed = Time.deltaTime * waveConf.getSpeed();
            transform.position =  Vector2.MoveTowards(transform.position, targetPoint, waveSpeed);
            if(transform.position == wayPoints[index].position)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
