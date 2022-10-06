using UnityEngine;
 
public class BGmusic : MonoBehaviour
{
    public static BGmusic bgmusic;
 
    void Awake()
    {
        if (bgmusic == null)
        {
            bgmusic = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}