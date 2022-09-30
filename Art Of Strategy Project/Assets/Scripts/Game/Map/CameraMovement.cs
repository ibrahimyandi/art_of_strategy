using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 dragOrigin;
    float zoomOutmin = 50f;
    float zoomOutMax = 200f;
    float maxSlide = 200;
    //zoom = 200
    //sol alt x = -75 y = 40
    //sol üst x = -75 y = 100
    //sağ üst x = 345 y = 100
    //sağ alt x = 345 y = 40


    //zoom = 125
    //sol alt x = -37.5  y = 20
    //sol üst x = -37.5 y = 162.5
    //sağ üst x = 306.5 y = 162.5
    //sağ alt x = 306.5 y = 20

    //zoom = 50
    //sol alt x = 0 y = 0
    //sol üst x = 0 y = 225
    //sağ üst x = 268 y = 225
    //sağ alt x = 268 y = 0
    
    float zoomModifierSpeed = 0.1f;

    void Update()
    {
        PanCamera();
    }
    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);     
            Touch secondTouch = Input.GetTouch(1);

            Vector2 firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;
            
            float touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
            float touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;
            float difference = touchesCurPosDifference - touchesPrevPosDifference;
            zoom(difference * zoomModifierSpeed);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }

        void zoom(float increment){
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutmin, zoomOutMax);
        }
    }
}
