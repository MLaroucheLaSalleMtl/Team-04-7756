﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        animation.enabled = true;
    }
}
