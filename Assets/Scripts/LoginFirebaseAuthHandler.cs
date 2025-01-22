using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;

public class LoginFirebaseAuthHandler : MonoBehaviour
{
    public TMP_InputField emailInputField;   // Email input field
    public TMP_InputField passwordInputField; // Password input field
    public Button loginButton;           // Register button
    public TMP_Text feedbackText;               // Feedback text area

    private FirebaseAuth auth;
    private FirebaseFirestore firestore;

    public static bool IsAllowed(string email, string password)
    {
        string status = "allowed";

        //implent checking if allowed in firestore and return true/false

        return status.Equals("allowed");
    }

    void Start()
    {
        // Initialize Firebase
        auth = FirebaseAuth.DefaultInstance;
        firestore = FirebaseFirestore.DefaultInstance;

        // Add listener for the Register button
        loginButton.onClick.AddListener(() => StartCoroutine(LoginUser()));
    }

    IEnumerator LoginUser()
    {
        string email = emailInputField.text.Trim();
        string password = passwordInputField.text.Trim();

        // Validate input fields
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            feedbackText.text = "Please enter both email and password.";
            yield break;
        }


        if (IsAllowed(email, password))
        {
            feedbackText.text = "Login Success";
        }
        else
        {
            feedbackText.text = "No admin approval.";
        }
    }

    
}
