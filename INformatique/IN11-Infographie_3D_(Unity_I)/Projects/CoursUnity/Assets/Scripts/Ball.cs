using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] LayerMask m_ColorableLayers;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " COLLIDED WITH " + collision.gameObject.name);

        // identification par name
        //if(collision.gameObject.name.Equals("Cube"))
        //if (collision.gameObject.name.Contains("Cube"))
        //if (collision.gameObject.name.ToUpper().Contains("CUBE"))

        //identification par tag
        //if(collision.gameObject.CompareTag("Colorable"))

        //identification par layer
        //if(collision.gameObject.layer == LayerMask.NameToLayer("Colorable"))
        //if( (m_ColorableLayers.value & (1<<collision.gameObject.layer))>0)

        // identification fonctionnelle par component
        Colorable colorable = collision.gameObject.GetComponentInChildren<Colorable>();
        if (colorable)
        {
            MyTools.ChangeColorRandom(collision.gameObject);
            EventManager.Instance.Raise(new BallHitAGameObjectEvent() { eGameObject = collision.gameObject });
        }



        // identification fonctionnelle par interface
        //IColorize colorize = collision.gameObject.GetComponent<IColorize>();
        //if (colorize != null)
        //    colorize.Colorize();

    }
}
