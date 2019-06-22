using UnityEngine;

class SwipeModule
{
    public const float MaxSwipeTime = 1.0f;
    public const float MinSwipeDistance = 0.10f;

    public enum Direction { None, Right, Left, Up, Down };

    public delegate void OnSwipeHandler( Direction Dir );

    public OnSwipeHandler OnSwipe = null;

    Vector2 startPos;
    float startTime;

    private Direction ClassifySwipeVector( Vector2 Swipe )
    {
        if (Swipe.magnitude < MinSwipeDistance)
            return Direction.None;

        if (Mathf.Abs(Swipe.x) > Mathf.Abs(Swipe.y))
        { // Horizontal swipe
            if (Swipe.x > 0)
                return Direction.Right;
            else
                return Direction.Left;
        }
        else
        { // Vertical swipe
            if (Swipe.y > 0)
                return Direction.Up;
            else
                return Direction.Down;
        }
    }

    public void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = new Vector2(Input.mousePosition.x / (float)Screen.width, Input.mousePosition.y / (float)Screen.width);
                startTime = Time.time;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - startTime > MaxSwipeTime)
                    return;

                Vector2 endPos = new Vector2(Input.mousePosition.x / (float)Screen.width, Input.mousePosition.y / (float)Screen.width);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                OnSwipe(ClassifySwipeVector(swipe));
            }

        /*
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                startTime = Time.time;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                if (Time.time - startTime > MaxSwipeTime)
                    return;

                Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                OnSwipe(ClassifySwipeVector(swipe));
            }
        }
        */
    }
};
