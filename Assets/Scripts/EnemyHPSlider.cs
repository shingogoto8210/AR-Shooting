using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSlider : MonoBehaviour
{
    private Slider slider;
    private int eHP;
    private GameObject enemyCanvas;

    void Start()
    {
        eHP = transform.root.gameObject.GetComponent<EnemyHealth>().enemyHP;

        slider = GetComponent<Slider>();
        slider.value = eHP;
        slider.maxValue = eHP;
        enemyCanvas = transform.parent.gameObject;
    }

    void Update()
    {
        eHP = transform.root.gameObject.GetComponent<EnemyHealth>().enemyHP;
        slider.value = eHP;
        enemyCanvas.transform.LookAt(GameObject.Find("FPSCamera").transform);
    }
}
