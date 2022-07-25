using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseObject : MonoBehaviour
{
    
    private ProgrammManager ProgrammManagerScript;
    private AddObject AddObjectScript;
    private Button button; //создаем переменную button
   
    public GameObject ChoosedObject; //создаем переменную для выбора модели

     
    void Start()
    {
       
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();   
        AddObjectScript = FindObjectOfType<AddObject>();
        
        button = GetComponent<Button>(); //помещаем в переменную компонент "<Button>"    
        button.onClick.AddListener(ChooseObjectFunction) ;//запуск функции ChooseObjectFunction при нажатии на кнопку.
        
       
    }

    // Update is called once per frame
    
    void ChooseObjectFunction()
    {
         
        ProgrammManagerScript.ObjectToSpawn = ChoosedObject; //присваиваем обьекту ObjecttoSpawn обьект ChoosedObject
        ProgrammManagerScript.ChooseObject = true; 
        ProgrammManagerScript.ScrollView.SetActive(false);
        button.gameObject.SetActive(true);   
    }

   
    
}
