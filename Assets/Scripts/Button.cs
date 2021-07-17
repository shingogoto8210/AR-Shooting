using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private ShotBullet shotBullet;

    void Start()
    {
       shotBullet = GameObject.Find("ShotBullet").GetComponent<ShotBullet>();
    }

    public void OnClick()
    {
        shotBullet.Reload();
    }
}
