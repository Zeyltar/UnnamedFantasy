using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FocusSystem : MonoBehaviour
{
    public Transform Target { get; private set; }

    private string _targetTag = "Player";
    private float _focusTimer = 0.0f;
    private bool _isFocused = false;

    public float Distance { get; private set; }


    [SerializeField] protected float focusDistance = 5.0f;
    [SerializeField] protected float focusDuration = 2.0f;
    [SerializeField] protected UnityEvent onFocused;
    [SerializeField] protected UnityEvent onLostFocus;



    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag(_targetTag).transform;

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the target GameObject is assigned
        if (Target == null)
        {
            Debug.LogError("No target GameObject with the specified tag found.");
            return;
        }

        // Calculate the distance between the two GameObjects
        Distance = Vector2.Distance(transform.position, Target.position);

        // Check if the distance is within the focus distance
        if (Distance <= focusDistance)
        {
            // Increase the focus timer by the time passed since the last frame
            _focusTimer += Time.deltaTime;

            // Check if the focus timer has reached the required focus duration and the focus action is not active
            if (_focusTimer >= focusDuration && !_isFocused)
            {
                _isFocused = true; // Set the focus action as active
            }
            else if (_isFocused)
            {
                onFocused.Invoke(); // Invoke the focus event
            }
        }
        else
        {
            // Reset the focus timer and deactivate the focus action if the target is out of focus distance
            if (_isFocused)
            {
                onLostFocus.Invoke(); // Invoke the lost focus event
                _isFocused = false; // Set the focus action as inactive
            }
            _focusTimer = 0.0f;
        }
    }
}
