using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Sprite newButtonImage;
    public Sprite oldButtonImage;
    private Button Button;
    private ProgrammManager ProgrammManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        Button = GetComponent<Button>();
        Button.onClick.AddListener(RotationFunction);
    }

    // Update is called once per frame
    void RotationFunction()
    {
        if (ProgrammManagerScript.Rotation)
        {
            ProgrammManagerScript.Rotation = false;
            GetComponent<Image>().sprite = newButtonImage;
        }
        else
        {
            ProgrammManagerScript.Rotation = true;
            GetComponent<Image>().sprite = oldButtonImage;
        }
    }
}
