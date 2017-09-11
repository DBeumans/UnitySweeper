using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour {
    public void Generate(int w, int h, GameObject obj)
    {
        GameObject parentObject = new GameObject();
        parentObject.transform.name = "Elements";
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                GameObject go = Instantiate(obj);
                go.transform.position = new Vector2(x, y);
                go.transform.name = "default";
                go.transform.SetParent(parentObject.transform);

            }
        }
    }
}
