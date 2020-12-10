﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float speed = .5f;
    Material material;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset*Time.deltaTime;
    }
}
