using System;
using UnityEngine;

public class CameraSwipeController : MonoBehaviour
{
    public float cameraSpeed = 12f;
    public float size = 12f;
    private Vector2 startTouchPosition, endTouchPosition;
    private bool isDragging = false;
    private bool isPanelOn = false;
    private int mapIndex = 0;

    private void Start()
    {
        mapIndex = 0;
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = size / (2.0f * aspectRatio);
        CoreUISignals.Instance.isPanelOpen+=IsPanelOpen;
        isPanelOn = false;
        //Camera.main.aspect = (float)Screen.width / (float)Screen.height;
    }

    private void IsPanelOpen(bool arg0)
    {
        if (arg0)
        {
            isPanelOn = true;
        }
        else { isPanelOn = false; }
    }

    void Update()
    {
        //float aspectRatio = (float)Screen.width / (float)Screen.height;
        //Camera.main.orthographicSize = cameraSpeed / (2.0f * aspectRatio);
        /*if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endTouchPosition = Input.mousePosition;
            Vector2 swipeDelta = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && swipeDelta.x > 0 && mapIndex > 0)
            {
                MoveCameraLeft();
                mapIndex--;
                CoreUISignals.Instance.onRoomUIIndex(mapIndex);
            }
            else if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && swipeDelta.x < 0 && mapIndex < 2)//maps.Count
            {
                MoveCameraRight();
                mapIndex++;
                CoreUISignals.Instance.onRoomUIIndex(mapIndex);
            }
            else if (Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y) && swipeDelta.y < 0)
            {
                MoveCameraUp();
            }
            else if (Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y) && swipeDelta.y > 0)
            {
                MoveCameraDown();
            }


            isDragging = false;
        }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isDragging = true;
            }

            if (touch.phase == TouchPhase.Ended && isDragging && !isPanelOn)
            {
                endTouchPosition = touch.position;
                Vector2 swipeDelta = endTouchPosition - startTouchPosition;

                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && swipeDelta.x > 0 && mapIndex < 2)
                {
                    MoveCameraLeft();
                    mapIndex++;
                    CoreUISignals.Instance.onRoomUIIndex(mapIndex);
                }
                else if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && swipeDelta.x < 0 && mapIndex > 0)//maps.Count
                {
                    MoveCameraRight();
                    mapIndex--;
                    CoreUISignals.Instance.onRoomUIIndex(mapIndex);
                }
                else if (Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y) && swipeDelta.y < 0)
                {
                    MoveCameraUp();
                }
                else if (Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y) && swipeDelta.y > 0)
                {
                    MoveCameraDown();
                }
                isDragging = false;
            }
        }
    }

    void MoveCameraRight()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += cameraSpeed;
        transform.position = newPosition;
    }

    void MoveCameraLeft()
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= cameraSpeed;
        transform.position = newPosition;
    }
    void MoveCameraUp()
    {
        Vector3 newPosition = transform.position;
        newPosition.z += cameraSpeed;
        transform.position = newPosition;
    }

    void MoveCameraDown()
    {
        Vector3 newPosition = transform.position;
        newPosition.z -= cameraSpeed;
        transform.position = newPosition;
    }
}
