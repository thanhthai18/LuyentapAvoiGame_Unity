using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using FirstGame.Player;

public class Canvas_MainGame : MonoBehaviour
{
    [SerializeField]
    private Button _btnMenu;
    [SerializeField]
    private TextMeshProUGUI _txtTime;
    [SerializeField]
    private TextMeshProUGUI _txtScore;
    private float _timeCount;
    [SerializeField]
    private Coroutine _coutingTimeCoroutine; //chi la bien gan StartCoro vao
                                            // k co thi thoi

    public float TimeCount
    {
        get => _timeCount;
        set
        {
            _timeCount = value;
            _txtTime.SetText($"Time: {TimeCount}"); // Thay vi dung trong update
        }
    }

    void Start()
    {
        _btnMenu.onClick.AddListener(Handle_BtnMenuClicked);
        _coutingTimeCoroutine = StartCoroutine(IECoutingTime());
      
    }

    private void OnEnable()
    {
        //Subcribe
        PlayerController.Event_OnPickup += Handle_Event_OnPickup;
    }
    private void OnDisable()
    {
        //Unsubcribe
        PlayerController.Event_OnPickup -= Handle_Event_OnPickup;
    }

    private void Handle_Event_OnPickup(int score)
    {
        _txtScore.SetText($"Score: {score}");
    }

    private void Handle_BtnMenuClicked()
    {
        Debug.Log("<color=green>Handle_BtnMenuClicked</color>");
        SceneManager.LoadScene("MenuScenes");        
              
    }
    //private void Update()
    //{
    //    _timeCount += Time.deltaTime;
    //    _txtTime.SetText("Time:" + _timeCount);
    //} (Tinh time nhung it ai dung kieu nay)

    private IEnumerator IECoutingTime()
    {
        
        while (true) 
        {

            TimeCount++;
            yield return new WaitForSeconds(1f);
            Debug.Log($"IECoutingTime() {TimeCount}");
        }      
    }
    [ContextMenu ("StopCoutingTime()")]
    private void StopCoutingTime()
    {
        StopCoroutine(_coutingTimeCoroutine);
    }
    private void OnDestroy()
    {
        PlayerController.Event_OnPickup -= Handle_Event_OnPickup;
    }
}
