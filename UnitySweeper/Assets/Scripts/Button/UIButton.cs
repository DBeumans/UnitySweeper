using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour {

    private Button button;

    [SerializeField]
    private GameObject showPanel;
    [SerializeField]
    private GameObject hidePanel;

    [SerializeField]
    private bool changeLevel;

    [SerializeField]
    private int sceneNumber;

	private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate () { changeTarget(hidePanel, showPanel, sceneNumber); });
    }

    private void changeTarget(GameObject hidePanelObj, GameObject showpanelObj = null, int scene = 0)
    {
        if(changeLevel)
        {
            changeScene(scene);
            return;
        }

        if (hidePanelObj != null)
            hidePanelObj.SetActive(false);
        if(showpanelObj != null)
            showpanelObj.gameObject.SetActive(true);
    }

    private void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
