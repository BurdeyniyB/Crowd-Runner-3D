using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private string[] SceneName;
        [SerializeField] private bool Lose;
        private Button PlayButton;
        int range;

        void Start()
        {
            PlayButton = GetComponent<Button>();
            PlayButton.onClick.AddListener (Task);
        }

        public void Task()
        {
          if(!Lose)
          {
            range = Random.Range(0, SceneName.Length);
            SceneManager.LoadScene(SceneName[range]);
          }
          else
          {
            SceneManager.LoadScene(SceneName[0]);
          }
        }

    }
