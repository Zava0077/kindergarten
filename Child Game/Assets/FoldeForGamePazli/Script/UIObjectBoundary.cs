using UnityEngine;
using UnityEngine.UI;

public class UIObjectBoundary : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private RectTransform uiElementRectTransform;

    void Start()
    {
        // Получаем RectTransform Canvas
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Этот скрипт должен быть прикреплен к UI элементу внутри Canvas.");
            return;
        }

        // Получаем RectTransform текущего UI элемента
        uiElementRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Проверка позиции UI элемента
        CheckBounds();
    }

    void CheckBounds()
    {
        if (canvasRectTransform == null || uiElementRectTransform == null)
            return;

        // Получаем размеры Canvas в локальных координатах
        Vector3 canvasMin = canvasRectTransform.rect.min;
        Vector3 canvasMax = canvasRectTransform.rect.max;

        // Получаем локальную позицию и размеры UI элемента
        Vector3 localPosition = uiElementRectTransform.localPosition;
        Vector2 elementSize = uiElementRectTransform.rect.size;

        // Проверка и корректировка по оси X
        if (localPosition.x - elementSize.x / 2 < canvasMin.x)
        {
            localPosition.x = canvasMin.x + elementSize.x / 2;
        }
        else if (localPosition.x + elementSize.x / 2 > canvasMax.x)
        {
            localPosition.x = canvasMax.x - elementSize.x / 2;
        }

        // Проверка и корректировка по оси Y
        if (localPosition.y - elementSize.y / 2 < canvasMin.y)
        {
            localPosition.y = canvasMin.y + elementSize.y / 2;
        }
        else if (localPosition.y + elementSize.y / 2 > canvasMax.y)
        {
            localPosition.y = canvasMax.y - elementSize.y / 2;
        }

        // Устанавливаем новую локальную позицию элемента
        uiElementRectTransform.localPosition = localPosition;
    }
}