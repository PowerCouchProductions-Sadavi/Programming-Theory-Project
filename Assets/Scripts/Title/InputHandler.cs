using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private int nameLengthMax = 15;

    public TMP_InputField catInput;
    public TMP_InputField dogInput;
    public TMP_Text warning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ValidateButton()
    {
        SubmitNames();
    }
    public bool SubmitNames()
    {
        warning.text = "";
        warning.color = Color.orange;
        if(!NameValidationCheck()){ return false; }
        warning.text = "Both names valid!";
        warning.color = Color.green;
        return true;
    }
    private bool NameValidationCheck()
    {
        bool isValid = true;
        //Validate name length
        if(catInput.text.Length > nameLengthMax) { DisplayWarning($"Cat Name cannot exceed {nameLengthMax} characters!"); isValid = false; }
        if(dogInput.text.Length > nameLengthMax) { DisplayWarning($"Dog Name cannot exceed {nameLengthMax} characters!"); isValid = false; }

        //Check for blank input, space at start and capitalization
        if(catInput.text.Length < 1) { DisplayWarning("Cat Name cannot be blank!") ; isValid = false; }
        else if(catInput.text.StartsWith(" ")) { DisplayWarning("Cat Name cannot start with a space."); isValid = false; }
        else if (!char.IsUpper(catInput.text[0])) { DisplayWarning("Cat Name needs to begin with a capital letter."); isValid = false; }

        if(dogInput.text.Length < 1) { DisplayWarning("Dog Name cannot be blank!"); isValid = false; }
        else if (dogInput.text.StartsWith(" ")) { DisplayWarning("Dog Name cannot start with a space."); isValid = false; }
        else if (!char.IsUpper(dogInput.text[0])) { DisplayWarning("Dog Name needs to begin with a capital letter."); isValid = false; }

        return isValid;
    }

    private void DisplayWarning(string message)
    {
        warning.text += message + "\n";

    }

    public void PlayButton()
    {
        if (!SubmitNames()) { return; }
        else
        {
            GameController.CatName = catInput.text;
            GameController.DogName = dogInput.text;
            SceneManager.LoadScene(1);
        }
    }
}
