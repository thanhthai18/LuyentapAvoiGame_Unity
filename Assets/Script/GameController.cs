using FirstGame.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FirstGame.Food.Controller
{
 public class GameController : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerPrefabs;
        [SerializeField]
        private Transform _spawnPosition;
        [SerializeField]
        private PlayerController _player;

        void Start()
        {
            //Instantate player
            _player = Instantiate(_playerPrefabs, _spawnPosition.position, Quaternion.identity);

            //Basic
            var txtScore = GameObject.Find("txtScore").GetComponent<TextMeshProUGUI>();
            _player.AssignUI(txtScore);
        }

      
    }

}
