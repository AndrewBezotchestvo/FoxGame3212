using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _hp = 100;
    [SerializeField] private float _damage = 5;

    [SerializeField] private Slider _slider;
    [SerializeField] private float _radius = 1;


    void Start()
    {
        _slider.maxValue = _hp;
    }

    void Update()
    {
        _slider.value = _hp;

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (Collider2D target in targets)
            {
                if (target.TryGetComponent<EnemyController>(out EnemyController enemyController))
                {
                    enemyController.GetDamage(Random.Range(5, 10));
                }

            }
        }
    }

    public void GetDamage(float damage)
    {
        _hp -= damage;
    }
}
