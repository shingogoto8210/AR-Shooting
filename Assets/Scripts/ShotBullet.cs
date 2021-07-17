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
    public bool isRapid;
    private float rapidTime;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    void Update()
    {
        Shot();
    }
    public void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameMaster.currentGameState == GameState.プレイ中 && isRapid == false)
        {

            if (shotCount > 0)
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
        if (Input.GetKey(KeyCode.Mouse0) && gameMaster.currentGameState == GameState.プレイ中 && isRapid == true)
        {
            shotInterval += 1;
            rapidTime += Time.deltaTime;
            if (rapidTime < 10)
            {
                if (shotInterval % 5 == 0)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x + 90, transform.parent.eulerAngles.y, 0));
                    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                    bulletRb.AddForce(transform.forward * shotSpeed);
                    Destroy(bullet, 3.0f);
                    AudioSource.PlayClipAtPoint(shotSound, transform.position);
                    GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                    Destroy(effect, 0.5f);
                }
            }
            else if (rapidTime >= 10)
            {
                isRapid = false;
                rapidTime = 0;
            }
        }
    }

    public void Reload()
    {
            shotCount = 30;
            AudioSource.PlayClipAtPoint(reloadSound, transform.position);
    }

    public void Rapid()
    {
        isRapid = true;
    }
}
