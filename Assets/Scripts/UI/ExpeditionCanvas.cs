using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ExpeditionCanvas : MonoBehaviour
{
    [SerializeField] float tickTimer;
    [Header("Fields")]
    [SerializeField] TextMeshProUGUI expeditionName;
    [SerializeField] TextMeshProUGUI expeditionDescription;
    [SerializeField] TextMeshProUGUI playerLog;
    [SerializeField] TextMeshProUGUI creatureLog;
    [SerializeField] Image creatureSprite;
    [SerializeField] Image playerHp;
    [SerializeField] Image creatureHp;
    ExpeditionDetail detail;
    UnitStats playerStats;
    float fillAmount, creatureHealth, playerHealth;
    float timer;
    public void Initialize(ExpeditionDetail _detail){
        detail = _detail;
        playerStats = PlayerStats.Instance.playerStats;
        expeditionName.text = detail.expeditionName;
        expeditionDescription.text = detail.expeditionDescription;
        creatureSprite.sprite = detail.creatureImage;
        fillAmount = detail.creatureStats.health;
        creatureHp.fillAmount = fillAmount;

        creatureHealth = detail.creatureStats.health;
        playerHealth = playerStats.health;
    }
    private void Update() {
        timer += Time.deltaTime;
        if(timer >= tickTimer){
            _Tick();
            timer = 0;
        }
    }
    public void _Tick(){
        var firstRoll = Random.Range(0, 7);
        var secondRoll = Random.Range(0,7);

        playerLog.text += $"Rolled a {firstRoll}\n";
        creatureLog.text += $"Rolled a {secondRoll}\n";

        if(firstRoll > secondRoll){
            Debug.Log("Player Attack!");

            var attack = playerStats.attack;
            creatureHealth -= attack;

            if(creatureHealth <= 0){
                OnWin();
                return;
            }

            playerLog.text += $"Attacked with {attack}\n";
            creatureHp.fillAmount = (1/creatureHealth);

        }else{
            Debug.Log("Enemy Attack!");

            var attack = detail.creatureStats.attack;
            playerHealth -= attack;

            if(playerHealth <= 0){
                OnLose();
                return;
            }

            creatureLog.text += $"Attacked with {attack}\n";
            playerHp.fillAmount = (1/playerHealth);
        }
    }
    void OnLose(){
        Debug.Log("Player Lost...");
        StateController.Instance.currentState = States.GAME;
        Destroy(this.gameObject);
    }
    void OnWin(){
        Debug.Log("Player Win...");
        StateController.Instance.currentState = States.GAME;
        Destroy(this.gameObject);
    }
}
