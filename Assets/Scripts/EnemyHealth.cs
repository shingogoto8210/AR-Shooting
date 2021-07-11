using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP;
    public AudioClip audioClip;
    public GameObject effectprefab;
    public int point;
    private GameMaster gameMaster;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            enemyHP -= 1;
            AudioSource.PlayClipAtPoint(audioClip,other.transform.position);
            if(enemyHP < 0)
            {
                enemyHP = 0;
                Destroy(gameObject);
                Instantiate(effectprefab, transform.position, Quaternion.identity);
                gameMaster.Score(point);
            }
        }
    }
}
