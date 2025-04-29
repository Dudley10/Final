using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public Slider slider;
    public int damagePerTick = -10;
    public float intervals = 3f;
    private bool isDamaging = false;
    public int slash = -10;
    public Health enemy;
    public Health player;
    public GameObject winTextObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value= health;
        startDamage();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    public void takeDamage(int damagePerTick){
        health -= damagePerTick;
        slider.value = health;

        if(health<=0){
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "YOU LOSE";
            //dealDamage() = null;
        }
    }

    public void dealDamage(int slash){
        health -= slash;
        slider.value = health;

        if(health<=0){
            winTextObject.SetActive(true);
            //takeDamage(null);
        }
    }
    public void startDamage(){
        if(!isDamaging)
        StartCoroutine(DamageRoutine());
    }
    public void stopDamage(){
        isDamaging = false;
        StopAllCoroutines();
    }
    private IEnumerator DamageRoutine(){
        isDamaging = true;
        while (isDamaging){
            player.takeDamage(damagePerTick);
            yield return new WaitForSeconds(intervals);
        }
    }
    public void attack(){
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
           enemy.dealDamage(slash); 
        }
    }
}
