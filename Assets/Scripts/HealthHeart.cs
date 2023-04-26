using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    [SerializeField] protected Sprite fullHeart, threeQuartersHeart, halfHeart, quarterHeart, emptyHeart;
    private Image _heartImage;

    private void Awake()
    {
        _heartImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetHeartStatus(HeartStatus heartStatus)
    {
        switch (heartStatus)
        {
            case HeartStatus.Full:
                _heartImage.sprite = fullHeart;
                break;
            case HeartStatus.ThreeQuarters:
                _heartImage.sprite = threeQuartersHeart;
                break;
            case HeartStatus.Half:
                _heartImage.sprite = halfHeart;
                break;
            case HeartStatus.Quarter:
                _heartImage.sprite = quarterHeart;
                break;
            case HeartStatus.Empty:
                _heartImage.sprite = emptyHeart;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(heartStatus), heartStatus, null);
        }
    }
}
public enum HeartStatus
{
    Empty = 0,
    Quarter = 1,
    Half = 2,
    ThreeQuarters = 3,
    Full = 4
}
