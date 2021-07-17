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
    [SerializeField] private GameObject[] itemPrefabs;
    private GameObject rapidItem;
    private GameObject reloadItem;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet" && gameMaster.currentGameState == GameState.プレイ中)
        {
            enemyHP -= 1;
            AudioSource.PlayClipAtPoint(audioClip,other.transform.position);
            if(enemyHP <= 0)
            {
                enemyHP = 0;
                Destroy(gameObject);
                Instantiate(effectprefab, transform.position, Quaternion.identity);
                gameMaster.Score(point);
                int itemNumber = Random.Range(1, 100);
                Debug.Log(itemNumber);
                if(itemNumber > 70)
                {
                    rapidItem = Instantiate(itemPrefabs[0], new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z), Quaternion.identity);
                    Destroy(rapidItem, 3.0f);
                }
                if(itemNumber < 10)
                {
                    reloadItem = Instantiate(itemPrefabs[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    Destroy(reloadItem, 3.0f);
                }
            }
        }
    }
}
