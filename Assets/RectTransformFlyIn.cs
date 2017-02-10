using UnityEngine;
using System.Collections;

/// Lets a RectTransform fly in from one of the edges of its canvas.
public class RectTransformFlyIn : MonoBehaviour
{

    public enum Sides
    {
        Left,
        Right,
        Top,
        Bottom
    }

    /// The side from where the rect transform should fly in.
    public Sides side;

    /// The transition factor (from 0 to 1) between inside and outside.
    [Range(0, 1)]
    public float transition;

    /// Inside is assumed to be the start position of the RectTransform.
    private Vector2 inside;

    /// Outside is the position
    /// where the rect transform is completely outside of its canvas on the given side.
    private Vector2 outside;

    /// Reference to the rect transform component.
    private RectTransform rectTransform;
    /// Reference to the canvas component this RectTransform is placed on.
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        inside = rectTransform.position;
    }

    void Update()
    {
        CalculateOutside();
        rectTransform.position = Vector2.Lerp(outside, inside, transition);
    }

    void CalculateOutside()
    {
        outside = inside + GetDifferenceToOutside();
    }

    Vector2 GetDifferenceToOutside()
    {
        var pos = inside;
        var size = canvas.scaleFactor * rectTransform.rect.size;
        var pivot = rectTransform.pivot;
        var canvasSize = canvas.pixelRect.size;

        switch (side)
        {
            case Sides.Top:
                var distanceToTop = canvasSize.y - pos.y;
                return new Vector2(0f, distanceToTop + size.y * (pivot.y));
            case Sides.Bottom:
                var distanceToBottom = pos.y;
                return new Vector2(0f, -distanceToBottom - size.y * (1 - pivot.y));
            case Sides.Left:
                var distanceToLeft = pos.x;
                return new Vector2(-distanceToLeft - size.x * (1 - pivot.x), 0f);
            case Sides.Right:
                var distanceToRight = canvasSize.x - pos.x;
                return new Vector2(distanceToRight + size.x * (pivot.x), 0f);
            default:
                return Vector2.zero;
        }
    }
}