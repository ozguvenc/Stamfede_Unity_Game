using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{

    Image m_Image;
    public Image m_Image2;

    private Sprite m_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKey(KeyCode.Space))
        {
            m_Image.sprite = m_Image2.sprite;
        }
    }
}
