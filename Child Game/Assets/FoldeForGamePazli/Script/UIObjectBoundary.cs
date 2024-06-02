using UnityEngine;
using UnityEngine.UI;

public class UIObjectBoundary : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private RectTransform uiElementRectTransform;

    void Start()
    {
        // �������� RectTransform Canvas
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("���� ������ ������ ���� ���������� � UI �������� ������ Canvas.");
            return;
        }

        // �������� RectTransform �������� UI ��������
        uiElementRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // �������� ������� UI ��������
        CheckBounds();
    }

    void CheckBounds()
    {
        if (canvasRectTransform == null || uiElementRectTransform == null)
            return;

        // �������� ������� Canvas � ��������� �����������
        Vector3 canvasMin = canvasRectTransform.rect.min;
        Vector3 canvasMax = canvasRectTransform.rect.max;

        // �������� ��������� ������� � ������� UI ��������
        Vector3 localPosition = uiElementRectTransform.localPosition;
        Vector2 elementSize = uiElementRectTransform.rect.size;

        // �������� � ������������� �� ��� X
        if (localPosition.x - elementSize.x / 2 < canvasMin.x)
        {
            localPosition.x = canvasMin.x + elementSize.x / 2;
        }
        else if (localPosition.x + elementSize.x / 2 > canvasMax.x)
        {
            localPosition.x = canvasMax.x - elementSize.x / 2;
        }

        // �������� � ������������� �� ��� Y
        if (localPosition.y - elementSize.y / 2 < canvasMin.y)
        {
            localPosition.y = canvasMin.y + elementSize.y / 2;
        }
        else if (localPosition.y + elementSize.y / 2 > canvasMax.y)
        {
            localPosition.y = canvasMax.y - elementSize.y / 2;
        }

        // ������������� ����� ��������� ������� ��������
        uiElementRectTransform.localPosition = localPosition;
    }
}