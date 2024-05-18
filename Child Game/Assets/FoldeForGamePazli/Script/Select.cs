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
        transform = GetComponent<RectTransform>();
        pos = transform.localPosition;
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
        if (GetComponentInParent<MainScr>().Game.transform.rotation.z == 1)
        {
            transform.anchoredPosition -= pointerEventData.delta / canvas.scaleFactor;
        }
        else
        {
            transform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;
        }

    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
    }
}
