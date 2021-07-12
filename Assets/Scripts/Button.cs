using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private ShotBullet shotBullet;
    // Start is called before the first frame update
    void Start()
    {
       shotBullet = GameObject.Find("ShotBullet").GetComponent<ShotBullet>();
    }

    // Update is called once per frame

    public void OnClick()
    {
        shotBullet.Reload();
    }
}
