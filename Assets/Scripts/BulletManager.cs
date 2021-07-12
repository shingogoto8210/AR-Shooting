using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Text bulletText;
    private ShotBullet shotBullet;
    // Start is called before the first frame update
    void Start()
    {
        shotBullet = GameObject.Find("ShotBullet").GetComponent<ShotBullet>();
        bulletText.text = shotBullet.shotCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = shotBullet.shotCount.ToString();
    }
}
