using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(()=>
            {
                gameObject.SetActive(false);
                //GameStartEvent.Trigger();
                new StartGameCommand().Execute();
            });
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
