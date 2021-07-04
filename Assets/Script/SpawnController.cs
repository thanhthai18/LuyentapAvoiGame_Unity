using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGame.Food;

namespace FirstGame.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        /* [SerializeField]
         private GameObject _foodPrefab;*/
        [SerializeField]
        private List<GameObject> _foodPrefabs = new List<GameObject>();
        //hoặc dùng FoodController để tạo các vật thể và di chuyển:
        [SerializeField]
        private List<FoodController> _foodCtlPrefabs = new List<FoodController>();
        [SerializeField]
        private float _startX = 0;
        [SerializeField]
        private float _startY = 2.64f;


        void Start()
        {
            foreach (var item in _foodPrefabs)
            {
                /*_startX = UnityEngine.Random.Range(-2.79f, 2.79f);
                var randomSpeed = UnityEngine.Random.Range(1, 3);
                var foodObj = Instantiate(item, new Vector2(_startX, _startY), Quaternion.identity);
                var foodCtl = foodObj.GetComponent<FoodController>();
                foodCtl.Speed = randomSpeed;*/
            }
            foreach (var item in _foodCtlPrefabs)
            {
                _startX = UnityEngine.Random.Range(-2.79f, 2.79f);
                var randomSpeed = UnityEngine.Random.Range(1, 3);
                var food = Instantiate(item, new Vector2(_startX, _startY), Quaternion.identity);
                food.Speed = randomSpeed;
            }
            
        }

        void Update()
        {
         
        }
    }
}