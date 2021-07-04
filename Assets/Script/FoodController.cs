using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame.Food
{
    public class FoodController : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        public float Speed { get => speed; set => speed = value; }

        [SerializeField]
        private float _downBorder;


        void Start()
        {

            _downBorder = -2f;
        }


        void Update()
        {
            if (transform.position.y >= _downBorder)
            {
                transform.Translate(new Vector2(0, -1) * Speed * Time.deltaTime);
            }
            else
            {
                // Destroy(gameObject);
                Speed = 0f;
            }
        }
    }
}

