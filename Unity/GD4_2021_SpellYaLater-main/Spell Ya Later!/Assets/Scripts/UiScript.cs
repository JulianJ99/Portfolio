using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Color newColor = Color.green;
    public Color Inactivec = Color.white;
    public Button button;
    void Start()
    {
        button = GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
           ColorBlock cb = button.colors;
           cb.normalColor = newColor;
           button.colors = cb;
        }else if(Input.GetKeyUp("space")){
            ColorBlock cb = button.colors;
           cb.normalColor = Inactivec;
           button.colors = cb;
           
        }

    }
}
