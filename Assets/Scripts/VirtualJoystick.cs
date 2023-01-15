using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform _thumb;

    private Vector2 _originalPosition;
    private Vector2 _originalThumbPosition;

    public Vector2 delta;

    void Start()
    {
        _originalPosition = this.GetComponent<RectTransform>().localPosition;
        _originalThumbPosition = _thumb.localPosition;

        _thumb.gameObject.SetActive(false);
      
        delta = Vector2.zero;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _thumb.gameObject.SetActive(true);

        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out worldPoint);

        this.GetComponent<RectTransform>().position = worldPoint;
        _thumb.localPosition = _originalThumbPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint = new Vector3();

        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out worldPoint);

        _thumb.position = worldPoint;

        var size = GetComponent<RectTransform>().rect.size;

        delta = _thumb.localPosition;

        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;

        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localPosition = _originalPosition;

        delta = Vector2.zero;

        _thumb.gameObject.SetActive(false);
    }
}
