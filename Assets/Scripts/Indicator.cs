using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Transform target;
    public Transform showDistanceTo;

    public Color color
    {
        set { GetComponent<Image>().color = value; }
        get { return GetComponent<Image>().color; }
    }

    [SerializeField] private Text _distanceLabel;
    [SerializeField] private int _margin = 50;


    void Start()
    {
        _distanceLabel.enabled = false;
        GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (showDistanceTo != null)
        {
            _distanceLabel.enabled = true;

            var distance = (int)Vector3.Magnitude(showDistanceTo.position - target.position);
            _distanceLabel.text = distance.ToString() + "m";
        } else
        {
            _distanceLabel.enabled = false;
        }

        GetComponent<Image>().enabled = true;
        var viewportPoint = Camera.main.WorldToViewportPoint(target.position);

        if (viewportPoint.z < 0)
        {
            viewportPoint.z = 0;
            viewportPoint = viewportPoint.normalized;
            viewportPoint.x *= -Mathf.Infinity;
        }

        var screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);

        screenPoint.x = Mathf.Clamp(screenPoint.x, _margin, Screen.width - _margin * 2);
        screenPoint.y = Mathf.Clamp(screenPoint.y, _margin, Screen.height - _margin * 2);

        var localPosition = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            screenPoint,
            Camera.main,
            out localPosition);

        var rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = localPosition;
    }
}