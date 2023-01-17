using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    void Start()
    {
        IndicatorManager.instance.AddIndicator(
            gameObject,
            Color.green
            );   
    }
}
