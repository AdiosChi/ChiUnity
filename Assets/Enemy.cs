using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject bossmusic,cry;
    
    public Image healthBar; 
    //public string dataFilePath = @"E:\unity\demo1\Assets\ball.txt"; 
    
    private SpriteRenderer spriteRenderer;
    public Sprite m70,m60, m50, m40, m30, m20, m10; 
 
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    public void TakeDamage(float damage){

            anim.SetTrigger("gothit");  
            health -= damage;   
            healthBar.fillAmount = health / 100f;
            if(health <=0f){
                StopMusic();
                Debug.Log("Enemy died");
                Time.timeScale = 0;
            }
    }
  
    private void LateUpdate(){
        if(health <= 0f)
        {
            spriteRenderer.sprite = m10;
        }
        if (health <= 5f)
            {
            Destroy(cry);
        }
        else if (health <= 30f)
        {
            spriteRenderer.sprite = m20;
        }
        else if (health <= 40f)
        {
            spriteRenderer.sprite = m30;
        
        }
        else if (health <= 55f)
        {
            spriteRenderer.sprite = m40;
        }
        else if (health <= 65f)
        {
            spriteRenderer.sprite = m50;
        }
        else if (health <= 75f)
        {
            spriteRenderer.sprite = m60;
        }
        else if (health <= 85f)
        {
            spriteRenderer.sprite = m70;
        }
         
    }
    private void StopMusic()
    {
        if (bossmusic != null)
        {
            AudioSource audioSource = bossmusic.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    
}
