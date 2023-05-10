using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    [SerializeField] protected GameObject heartPrefab;
    [SerializeField] protected Health playerHealth;
    
    private List<HealthHeart> _healthHearts = new List<HealthHeart>();

    // Start is called before the first frame update
    void Start()
    {
        DrawHearts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        playerHealth.OnDamaged += DrawHearts;
    }
    
    private void OnDisable()
    {
        playerHealth.OnDamaged -= DrawHearts;
    }

    public void DrawHearts()
    {
        ClearHearts();
        
        int heartsToDraw = (int)Mathf.Ceil(playerHealth.MaxHealthPoints / 4f);
        
        
        for (int i = 0; i < heartsToDraw; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < _healthHearts.Count; i++)
        {
            int heartStatus = (int)Mathf.Clamp(playerHealth.HealthPoints - (i * 4), 0, 4);
            _healthHearts[i].SetHeartStatus((HeartStatus)heartStatus);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject heart = Instantiate(heartPrefab, transform);
        
        HealthHeart heartComponent = heart.GetComponent<HealthHeart>();
        heartComponent.SetHeartStatus(HeartStatus.Empty);
        _healthHearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        _healthHearts.Clear();
    }
}
