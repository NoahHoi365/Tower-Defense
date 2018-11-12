using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingObjects : MonoBehaviour
{

    public GUIStyle deleteStyle, replaceStyle;
    public Vector2 homeBtnSize = new Vector2(100, 100);
    public Vector2 topOffset = new Vector2(50, -50), bottomOffset = new Vector2(50, 180);

    private GameObject selectedGameObject;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                if(hit.transform.GetComponent<Tower>() && hit.transform.GetComponent<TowerPlace>().IsPlaced()) {
                    selectedGameObject = hit.transform.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            selectedGameObject = null;
        }
    }

    private void OnGUI()
    {
        if (selectedGameObject != null) {
            if (selectedGameObject.GetComponent<TowerPlace>().IsPlaced()) {
                Vector2 pointPosition = new Vector2(
                selectedGameObject.transform.position.x - camera.transform.position.x,
                -(selectedGameObject.transform.position.y - camera.transform.position.y)
                );

                Vector2 pointInCamera = camera.WorldToViewportPoint(pointPosition);
                bool pointIsVisible = true;
                Vector2 btnOffset;

                if (pointInCamera.y <= 0) {
                    pointIsVisible = false;
                    btnOffset = bottomOffset;
                } else {
                    pointIsVisible = true;
                    btnOffset = topOffset;
                }

                Vector2 point = camera.WorldToScreenPoint(pointPosition);

                //Delete button
                if (GUI.Button(new Rect(new Vector2(point.x - btnOffset.x, point.y + btnOffset.y), homeBtnSize), "", deleteStyle)) {
                    Destroy(selectedGameObject);
                }

                //Pick up button
                if (GUI.Button(new Rect(new Vector2(point.x - btnOffset.x + 120, point.y + btnOffset.y), homeBtnSize), "", replaceStyle)) {
                    selectedGameObject.GetComponent<MouseMove2D>().UnPlace();
                    selectedGameObject.GetComponent<TowerPlace>().Placed(false);
                    selectedGameObject = null;
                }
            }
        }
    }
}
