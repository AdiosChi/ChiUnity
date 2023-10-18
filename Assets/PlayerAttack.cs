using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim; 
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attacksound;
    // private int ballValue = 0;
    private List<int> ballValues = new List<int>();

    private void Start(){
        //TextAsset txt = Resources.Load("ball") as TextAsset;
        //int.TryParse(txt.text, out ballValue);
        TextAsset txt = Resources.Load("ball") as TextAsset;
        string[] lines = txt.text.Split('\n');
        

         /*foreach (string line in lines)
       {
            int ballValue;
            if (int.TryParse(line.Trim(), out ballValue))
            {
                ballValues.Add(ballValue); 
            }
        }*/
    }
    float timeUntilMelee;

    private void Update(){
        
        if(timeUntilMelee <= 0f){
            if(Input.GetMouseButtonDown(0)){
                PlayAttackSound();
                anim.SetTrigger("2point");
               timeUntilMelee = meleeSpeed;
            }
            /*foreach (int ballValue in ballValues)
            {
            
                if(ballValue == 2){
                    PlayAttackSound();
                    anim.SetTrigger("2point");
                    timeUntilMelee = meleeSpeed;
                    break;
                }
            }*/
        }
    
        if(timeUntilMelee <= 0f){
             if(Input.GetMouseButtonDown(1)){
                PlayAttackSound();
                anim.SetTrigger("3point");
                timeUntilMelee = meleeSpeed;
            }
            /*foreach (int ballValue in ballValues)
            {
           
                if(ballValue == 3){
                    PlayAttackSound();
                    anim.SetTrigger("3point");
                    timeUntilMelee = meleeSpeed;
                    break;
                }
            }*/
        }
        else{
            timeUntilMelee -= Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger entered");
            if(other.tag== "Enemy"){
                other.GetComponent<Enemy>().TakeDamage(damage);
            
                //Debug.Log("Enemy hit");
            }
    }

    private void PlayAttackSound()
    {
        if (audioSource != null && attacksound != null)
        {
            audioSource.PlayOneShot(attacksound);
        }
    }

}
 