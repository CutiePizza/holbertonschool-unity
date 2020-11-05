using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class links : MonoBehaviour
{
    public void ToEmail()
    {
        Application.OpenURL("mailto:ines.chokri97@gmail.com");
    }

    public void Linkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/inès-chokri-b247b7175/");
    }

    public void GitHub()
    {
        Application.OpenURL("https://github.com/CutiePizza");
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/chokri_ines");
    }
}
