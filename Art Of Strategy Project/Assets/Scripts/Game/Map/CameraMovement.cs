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
    
    float zoomModifierSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
