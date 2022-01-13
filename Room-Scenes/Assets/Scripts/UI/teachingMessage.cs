using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teachingMessage : MonoBehaviour
{
    public Text message, teachingMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(teachingMode.color == Color.white)
        {
            message.gameObject.SetActive(true);
        }
        else
        {
            message.gameObject.SetActive(false);
        }
    }
}
