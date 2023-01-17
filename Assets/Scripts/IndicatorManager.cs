using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : Singleton<IndicatorManager>
{
    [SerializeField] private RectTransform _labelContainer;
    [SerializeField] private Indicator _indicatorPrefab;

    public Indicator AddIndicator(GameObject target, Color color, Sprite sprite = null)
    {
        var newIndicator = Instantiate(_indicatorPrefab);

        newIndicator.target = target.transform;
        newIndicator.color = color;

        if (sprite != null)
        {
            newIndicator.GetComponent<Image>().sprite = sprite;
        }

        newIndicator.transform.SetParent(_labelContainer, false);

        return newIndicator;
    }
}
