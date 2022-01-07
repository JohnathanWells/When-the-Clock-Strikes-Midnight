using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootSteps : MonoBehaviour
{
    //[SerializeField] private AudioClip[] stoneClips;
    //[SerializeField] private AudioClip[] grassClips;
    [System.Serializable]
    public class Clip
    {
        public string name;
        [SerializeField]
        AudioClip[] _clips;
        [SerializeField]
        AudioClip[] _lClips;
        [SerializeField]
        AudioClip[] _rClips;
        bool right = true;
        public bool lrEnabled = true;
        public AudioClip[] clips
        {
            get
            {
                if (lrEnabled)
                {

                    right = !right;

                    if (right)
                    {
                        return _rClips;
                    }
                    else
                    {

                        return _lClips;
                    }
                }
                else
                {
                    return _clips;
                }
            }
        }

        public int clipsLength
        {
            get
            {
                if (lrEnabled)
                {

                    if (right)
                    {
                        return _rClips.Length;
                    }
                    else
                    {
                        return _lClips.Length;
                    }
                }
                else
                {
                    return _clips.Length;
                }
            }
        }
    }

    [SerializeField] private Clip[] clips;

    private AudioSource audioSource;

    private TerrainDetector terrainDetector;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
    }

    //Step is an event from the Animation itself, everytime the animation fires "Step" , a Clip gets played
    public void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        if (terrainTextureIndex >= clips.Length)
            return null;

        //int ind = Mathf.Min(terrainTextureIndex, clips.Length - 1);
        int ind = terrainTextureIndex;

        return clips[ind].clips[Random.Range(0, clips[ind].clipsLength)];
    }
}