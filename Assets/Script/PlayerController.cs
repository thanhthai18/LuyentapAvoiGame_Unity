using FirstGame.Food;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FirstGame.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private bool isSlowSpeed;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private int _score = 0;
        [SerializeField]
        private TextMeshProUGUI _txtScore;
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip _pickupClip;
        [SerializeField, Range(0,1)]
        private float _pickupClipVolume = 1f;

        // Để thống nhất speed bên này và bên scence thì nên thêm phương thức get:
        public float Speed
        {
            get { return speed; }
        }
        // hoặc nếu chỉ cần dùng Get thì có cách viết tắt rất nhanh:
        // public float Speed => speed;

        //Even - action
        public static event Action<int> Event_OnPickup; // C#, .NET

        private void Awake()
        {
            Debug.Log("Awake()");
            // Nếu muốn add Sprite ( hoặc bất kỳ đối tượng nào như Animator) vào Player mà ko muốn kéo thả:
            //spriteRenderer = GetComponent<SpriteRenderer>();
        }


        void Start()
        {
            Debug.Log("Start");
            speed = 10f;
            //spriteRenderer.flipX = true;

        }

        void Update()
        {
            Debug.Log("Update");
            if (isSlowSpeed == true) speed = 5f;
            else speed = 10f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
                // hoặc viết:  transform.Translate(Vector2.left); 
                //xoay nhân vật:
                //spriteRenderer.flipX = false;
                animator.SetBool("isRight", false);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
                animator.SetBool("isRight", true);
                // xoay nhân vật:
                //spriteRenderer.flipX = true;
            }
        }
        public void AssignUI(TextMeshProUGUI txtScore)
        {
            _txtScore = txtScore;
        }

        // Cách để đưa cái hàm nào đó lên thanh menu của Unity để test cho dễ , ta dùng ContextMenu:
        //[ContextMenu("RunLeft")]
        //void RunLeft()
        //{
        //    transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
        //}

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    Debug.Log($"Collide with {collision.collider.name}");
        //    if (collision.gameObject.tag == "1")
        //        Destroy(collision.gameObject);
        //}


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Collide with trigger {collision.name}");
            bool isItem = collision.CompareTag("1");
            if (isItem)
            {
                Destroy(collision.gameObject);
                _score += 10;
                // _txtScore.SetText("Score: " +_score); dung cai duoi: 
                Event_OnPickup?.Invoke(_score);

                //Play audio
                _audioSource.PlayOneShot(_pickupClip,_pickupClipVolume);
            }
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }
        private void OnDisable()
        {
            Debug.Log("OnDisable");
        }

        private void OnDestroy()
        {
            Debug.Log($"OneDestroy() {gameObject.name}");
            // hoặc viết:  Debug.Log("OnDestroy()" + "gameObject.name");
        }
    }
}