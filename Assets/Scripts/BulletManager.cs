using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Text bulletText;
    private ShotBullet shotBullet;

    void Start()
    {
        shotBullet = GameObject.Find("ShotBullet").GetComponent<ShotBullet>();
        bulletText.text = shotBullet.shotCount.ToString();
    }

    void Update()
    {
        bulletText.text = shotBullet.shotCount.ToString();
    }
}
