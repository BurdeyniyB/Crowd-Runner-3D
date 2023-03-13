using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel : MonoBehaviour
{
        [SerializeField] private string SceneName;

        public void To(string save)
        {
            PlayerPrefs.SetString("SceneLoad", save);
            SceneManager.LoadScene(SceneName);
        }

        public void Out()
        {
           SceneName = PlayerPrefs.GetString("SceneLoad");
           SceneManager.LoadScene(SceneName);
        }
}
