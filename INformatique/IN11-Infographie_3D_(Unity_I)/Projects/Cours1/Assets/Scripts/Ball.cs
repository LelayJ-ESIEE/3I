using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // [SerializeField] LayerMask m_ColorableLayers;

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(name + " COLLISIONNED WITH " + collision.gameObject.name);

        // Identification par son name
        /*
        if (collision.gameObject.name.ToLower().Contains("cube"))
        {
            MyTools.ChangeColorRandom(collision.gameObject);
        }
        */

        // Identification par son tag
        
        if (collision.gameObject.CompareTag("Colorable"))
        {
            MyTools.ChangeColorRandom(collision.gameObject);
        }
        

        // Identification par layer
        /*
        if (collision.gameObject.layer == LayerMask.NameToLayer("Colorable")
        {
            MyTools.ChangeColorRandom(collision.gameObject);
        }
        */

        // Masque de bit
        /*
        if(m_ColorableLayers.value & (1<<collision.gameObject.layer) > 0)
        {
            MyTools.ChangeColorRandom(collision.gameObject);
        }
        */

        // Identification fonctionnelle par component
        /*if (collision.gameObject.GetComponent<Colorable>())
        {
            MyTools.ChangeColorRandom(collision.gameObject);
        }*/

        // Identification fonctionnelle par interface
        /*IColorable colorable = collision.gameObject.GetComponent<IColorable>();
            if (colorable != null)
        {
            MyTools.ChangeColorRandom(collision.gameObject);
        }*/
    }
}
