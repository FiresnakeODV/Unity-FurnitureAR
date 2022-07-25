using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    private Button button;
    private ProgrammManager ProgrammManagerScript;
    public Button buttonToHide;
    
    
    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();
        buttonToHide = GetComponent<Button>();
        button = GetComponent<Button>();
        
        button.onClick.AddListener(AddObjectFunction);
        buttonToHide.onClick.AddListener(HideButton);
        
    }

    // Update is called once per frame
    void AddObjectFunction()
    {
      ProgrammManagerScript.ScrollView.SetActive(true);
      
    }

    void HideButton()
    {
        buttonToHide.gameObject.SetActive(false);
    }
    public void UnhideButton()
      {
        buttonToHide.gameObject.SetActive(true);
      }
    
}
