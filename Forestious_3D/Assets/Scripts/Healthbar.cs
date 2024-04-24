using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private float reduceSpeed = 2;
    private Camera cam;
    private float target = 1;
    void Start()
    {
        cam = Camera.main;
    }
    public void updateHealthBar(float maxHealth, float health)
    {
        target = health / maxHealth;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
