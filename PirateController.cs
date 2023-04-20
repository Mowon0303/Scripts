using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    [SerializeField]
    public IPirateCommand activeCommand;
    
    [SerializeField]
    public GameObject productPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.activeCommand = ScriptableObject.CreateInstance<NoWorkPirateCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        var working = this.activeCommand.Execute(this.gameObject, this.productPrefab);

        this.gameObject.GetComponent<Animator>().SetBool("Exhausted", !working);
    }

    //Has received motivation. A likely source is from on of the Captain's morale inducements.
    public void Motivate()
    {
        int index;

        IPirateCommand[] types = new IPirateCommand[3];

        types[0] = ScriptableObject.CreateInstance<SlowWorkPirateCommand>();
        types[1] = ScriptableObject.CreateInstance<NormalWorkPirateCommand>();
        types[2] = ScriptableObject.CreateInstance<FastWorkPirateCommand>();

        index = Random.Range(0,types.Length);

        // UnityEngine.Debug.Log(types[index]);

        this.activeCommand = types[index];
    }
    
}
