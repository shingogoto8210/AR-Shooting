using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public float shotSpeed;
    public int shotCount = 30;
    private float shotInterval;
    public GameObject effectPrefab;
    private GameMaster gameMaster;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    // Update is called once per frame
    void Update()
    {
        Shot();
    }
    public void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameMaster.isPlaying == true)
        {
            //shotInterval += 1;

            if (/*shotInterval % 5 == 0 && */shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x + 90, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);
                Destroy(bullet, 3.0f);
                AudioSource.PlayClipAtPoint(shotSound, transform.position);
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
            }
        }
    }

    public void Reload()
    {
            shotCount = 30;
            AudioSource.PlayClipAtPoint(reloadSound, transform.position);
    }
}
