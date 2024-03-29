﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    //thiet lap giao dien man hinh cho tat ca cac thiet bi
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(worldHeight, worldWidth, 0);
        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
    }

    
}
