using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    public GameObject thisPanel;
    public GameObject nextPanel;

    public bool shouldBeEscapable;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(() => SwapPanel());
    }

    private void Update()
    {
        if(shouldBeEscapable && Input.GetKeyDown(KeyCode.Escape))
        {
            SwapPanel();
        }
    }

    void SwapPanel()
    {
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
