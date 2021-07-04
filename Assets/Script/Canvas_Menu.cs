using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace FirstGame.Food.UI
{
    public class Canvas_Menu : MonoBehaviour
    {
        [SerializeField]
        private Button _btnStart;
        [SerializeField]
        private Button _btnQuit;

        private void Awake()
        {

        }
        private void Start()
        {
            _btnStart.onClick.AddListener(Handle_BtnStartClicked);
            _btnQuit.onClick.AddListener(Handle_BtnQuitClicked);


        }
        private void Handle_BtnStartClicked()
        {
            Debug.Log("<color=red>Handle_BtnStartClicked</color>");
            SceneManager.LoadScene("SampleScene");
        }
        private void Handle_BtnQuitClicked()
        {
            Debug.Log("<color=green>Handle_BtnQuitClicked</color>");
        }


    }


}
