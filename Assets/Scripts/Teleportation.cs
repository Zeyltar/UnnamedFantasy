using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Teleportation : MonoBehaviour
{
    [SerializeField] float TeleportCooldown;
    [FormerlySerializedAs("Speed")] [SerializeField] float Distance;
    [SerializeField] float TravelTime;

    private float _timer;
    private bool _teleport;
    private bool _canTeleport;
    private CharacterContoller _cc;

   

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterContoller>();
        _canTeleport = true;
        _teleport = false;
        _timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_teleport)
        {
            _canTeleport = false;
            if (_timer <= TravelTime)
            {
                transform.Translate(_cc.Looking * (Distance / TravelTime * Time.deltaTime));
                _timer += Time.deltaTime;
            }
            else
            {
                _teleport = false;
                _cc.SuperMove(_teleport);
                _timer = 0;
            }
        }
        else
        {
            if (!_canTeleport && _timer <= TeleportCooldown)
                _timer += Time.deltaTime;
            else
            {
                _canTeleport = true;
                _timer = 0f;
            }
        }
    }

    public void Teleport(InputAction.CallbackContext context)
    {
        if (_canTeleport && _cc.Looking != Vector2.zero)
        {
            _teleport = true;
            _cc.SuperMove(_teleport); 
        }
    }
}
