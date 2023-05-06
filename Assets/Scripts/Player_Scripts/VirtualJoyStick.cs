using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform knob;
    public Vector2 axis;
    private Vector2 joyStickSize;

      // Start is called before the first frame update
    void Start()
    {
        joyStickSize = GetComponent<RectTransform>().rect.max;
    }

    private void MoveKnob(Vector2 pos) 
    {
        knob.position = pos;
        pos.x = Mathf.Clamp(knob.localPosition.x, 0,joyStickSize.x);
        pos.y = Mathf.Clamp(knob.localPosition.y, 0,joyStickSize.y);
        knob.localPosition = pos;

        axis = ((knob.localPosition / joyStickSize) * 2) - Vector2.one;
    }
   

    public void OnDrag(PointerEventData eventData)
    {
      MoveKnob(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       MoveKnob(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        axis = Vector2.zero;
        knob.localPosition = joyStickSize / 2;
    }
}
