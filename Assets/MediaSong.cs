using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaSong : MonoBehaviour
{
    private void Awake()
    {
        setMediaSong();
    }

    private void setMediaSong()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
