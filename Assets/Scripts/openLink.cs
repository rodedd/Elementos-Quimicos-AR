using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLink : MonoBehaviour {

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }

}
