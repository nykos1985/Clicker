using UnityEngine;

namespace Main
{
    public class InputController : MonoBehaviour, IExecute
    {

        private Player _player;
        

        public void InpController(Player player)
        {
            _player = player;
        }
        
       void Update()
        {
            //if ((Input.touchCount > 0)&&(Input.touches[0].phase==TouchPhase.Began))
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Click");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        hit.collider.GetComponentInParent<Enemy>().Damage();
                        
                    }
                }

            }
        }

       public void Execute()
       {
           
       }
    }
}