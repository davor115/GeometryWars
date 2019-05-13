
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float m_movementRate = 15.0f;

    float m_currentAxisValue = 0;
    float m_currentYAxisValue = 0;
    Rigidbody m_rigidbody;

    private void Awake()
    {
       // m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position); // get the position of the player and transform it to view port point.
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // We check if the player is in the screen.
        if (onScreen)          
        {
            // We get the movement value based on Unity's input system, which turns our A + D and Left + Right keys into a float value.
            // Using AxisRaw will return -1, 0 or 1, while Axis will return a smoothly changing value between -1 and 1
            m_currentAxisValue = Input.GetAxisRaw("Horizontal");
            m_currentYAxisValue = -Input.GetAxisRaw("Vertical");
            if (SceneManager.GetActiveScene().name != "underwater") // If we are not in the under water scene...
            {
                if (m_currentAxisValue != 0)
                {
                    // If you remove Time.deltaTime it will be tied to your frame rate = VERY BAD
                    // Try removing it and then compare setting your quality settings Vsync to Half and off, you'll see a big difference
                    transform.Translate(new Vector3((m_currentAxisValue * m_movementRate) * Time.deltaTime, 0, 0));
                }
                if (m_currentYAxisValue != 0)
                {
                    // If you remove Time.deltaTime it will be tied to your frame rate = VERY BAD
                    // Try removing it and then compare setting your quality settings Vsync to Half and off, you'll see a big difference
                    transform.Translate(new Vector3(0, (m_currentYAxisValue * m_movementRate) * Time.deltaTime, 0));
                }
            }
            else // Here I change the movement because in the under water scene we are not in top view, we are playing with side view.. so I inverted the controllers.
            {
                if (m_currentYAxisValue != 0)
                {
                    // If you remove Time.deltaTime it will be tied to your frame rate = VERY BAD
                    // Try removing it and then compare setting your quality settings Vsync to Half and off, you'll see a big difference
                    transform.Translate(new Vector3((m_currentYAxisValue * m_movementRate) * Time.deltaTime, 0, 0));
                }
                if (m_currentAxisValue != 0)
                {
                    // If you remove Time.deltaTime it will be tied to your frame rate = VERY BAD
                    // Try removing it and then compare setting your quality settings Vsync to Half and off, you'll see a big difference
                    transform.Translate(new Vector3(0, (m_currentAxisValue * m_movementRate) * Time.deltaTime, 0));
                }
            }
        }
        else // If he is trying to get outside the camera view..
        {
            if(transform.localPosition.z <= 0)
            {
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
            }
             if(transform.localPosition.z >= 0)
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
            }
            if(transform.localPosition.x <= 0)
            {
                transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
            }
             if(transform.localPosition.x >= 0)
            {
                transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
            }
        }

    }
}
