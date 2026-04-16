using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleJoystick : MonoBehaviour, IDragHandler, IEndDragHandler 
{
    public RectTransform handle;
    public Vector2 input;
    private RectTransform _bg;

    void Start() 
    { 
        _bg = GetComponent<RectTransform>(); 
    }

    public void OnDrag(PointerEventData eventData) 
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bg, eventData.position, eventData.pressEventCamera, out pos)) 
        {
            pos.x = pos.x / _bg.sizeDelta.x;
            pos.y = pos.y / _bg.sizeDelta.y;
            input = Vector2.ClampMagnitude(pos * 2, 1.0f);
            handle.anchoredPosition = new Vector2(input.x * (_bg.sizeDelta.x / 2), input.y * (_bg.sizeDelta.y / 2));
        }
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}