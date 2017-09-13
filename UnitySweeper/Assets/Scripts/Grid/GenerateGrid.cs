using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour {
    public void Generate(int w, int h, GameObject obj, string parentObjectName, string gameObjectsName)
    {
        GameObject parentObject = new GameObject();
        parentObject.transform.name = parentObjectName;
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                GameObject go = Instantiate(obj);
                go.transform.position = new Vector2(x, y);
                go.transform.name = gameObjectsName;
                go.transform.SetParent(parentObject.transform);

            }
        }
    }
}
