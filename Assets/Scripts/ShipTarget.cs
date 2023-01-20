using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTarget : MonoBehaviour
{
    [SerializeField] private Sprite _targetImage;

    void Start()
    {
        IndicatorManager.instance.AddIndicator(gameObject, Color.yellow, _targetImage);
    }
}