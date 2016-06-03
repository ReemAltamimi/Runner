using UnityEngine;
using System.Collections;

public class MenuHeart : MonoBehaviour {

    // Use this for initialization
    public void Enable()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Fade()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 0.3f);
    }
}
