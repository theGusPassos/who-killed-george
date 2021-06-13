using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        [SerializeField] float transitionTime;
        Animator transition;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        private void Start()
        {
            transition = GetComponentInChildren<Animator>();
        }

        public void LoadScene(string level)
            => StartCoroutine(LoadSceneWithTransition(level));


        private void OnLevelWasLoaded(int level)
        {
            transition = GetComponentInChildren<Animator>();
            transition.Play("fade-in");
        }

        IEnumerator LoadSceneWithTransition(string level)
        {
            transition.Play("fade-out");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(level);
        }
    }
}
