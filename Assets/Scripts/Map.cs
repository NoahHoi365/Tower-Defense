using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private GameObject[,] gridMap;

    public int rows = 10;
    public int cols = 10;

    public Sprite tileSprite;

    public GameObject prefab;
    public int scaleSize;
    Camera camera;


    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        Vector3 topRightCorner = camera.ViewportToScreenPoint(new Vector3(0, 1, -1));
        Vector3 topLeftCorner = camera.ViewportToScreenPoint(new Vector3(0, 1, camera.nearClipPlane));
        print(topRightCorner);
        print(topLeftCorner);

        //transform.position = new Vector3(topRightCorner.x, topRightCorner.y, 1);
        transform.position = new Vector3(topLeftCorner.x, topLeftCorner.y, 1);

        gridMap = new GameObject[rows, cols];
        for(int x = 0; x < rows; x++) {
            for(int y = 0; y < cols; y++) {
                gridMap[x, y] = Instantiate(prefab, transform);
                gridMap[x, y].GetComponent<SpriteRenderer>().sprite = tileSprite;
                gridMap[x, y].transform.localScale = new Vector3(scaleSize, scaleSize, 1);
            }
        }
    }
}
