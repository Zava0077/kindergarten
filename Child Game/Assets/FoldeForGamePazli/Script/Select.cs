using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    RectTransform transform;
    CanvasGroup group;
    public Image image;
    public int CodePazel;
    public Vector3 pos;

    private void Awake()
    {
        pos = this.gameObject.transform.position;
        transform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        group.alpha = 6f;
        group.blocksRaycasts = false;
        Debug.Log(CodePazel);
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        transform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
    }
}
