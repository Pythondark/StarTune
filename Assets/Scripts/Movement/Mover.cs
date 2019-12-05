using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST.Movement
{
    public class Mover : MonoBehaviour
    {

        [SerializeField] [Range(0, 5)] float maxSpeed = 2f;
        Vector2 target;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (target == null) { return; }

            float step = maxSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

        public void MoveTo(Vector2 destination, float speedFraction)
        {
            target = destination;
        }
    }
}

