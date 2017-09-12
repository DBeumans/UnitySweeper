using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour {

    private Button button;

    [SerializeField]
    private GameObject panel;

	private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate () { openPanel(panel); });
    }

    private void openPanel(GameObject panelObj)
    {
        this.gameObject.SetActive(false);
        panelObj.gameObject.SetActive(true);
        Debug.Log("test");
    }
}
