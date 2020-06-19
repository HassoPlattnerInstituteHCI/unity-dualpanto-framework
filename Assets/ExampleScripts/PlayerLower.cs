﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLower : MonoBehaviour
{
    PantoHandle lowerHandle;
    void Start()
    {
        lowerHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
    }

    void FixedUpdate()
    {
        transform.position = lowerHandle.HandlePosition(transform.position);
    }
}
