using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDataBase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption= 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDB.characterCount )
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if(selectedOption <0)
        {
            selectedOption = characterDB.characterCount - 1;

        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");

    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
