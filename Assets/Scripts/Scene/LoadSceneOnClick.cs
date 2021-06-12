using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scene
{
    public class LoadSceneOnClick : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string sceneToLoad;

        public void OnPointerDown(PointerEventData eventData)
        {
            SceneLoader.Instance.LoadScene(sceneToLoad);
        }
    }
}
