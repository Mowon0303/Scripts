using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class FastWorkPirateCommand : ScriptableObject, IPirateCommand
    {
        private float totalWorkDuration;
        private float totalWorkDone;
        private float currentWork;
        private const float PRODUCTION_TIME = 2.0f;
        private bool exhausted = true;
        private float updated_time;
        private float produce_time;

        public FastWorkPirateCommand()
        {
            totalWorkDuration = 10.0f;
            totalWorkDone = totalWorkDuration / PRODUCTION_TIME;
            currentWork = 0;
            updated_time = 0;
            produce_time = 1;
        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            //This function returns false when no work is done. 
            //After you implement work according to the specification and
            //generate instances of productPrefab, this function should return true.
            GameObject product;
            updated_time += Time.deltaTime;
            if ((updated_time >= 2.0 * produce_time))
            { 
                if (currentWork < 5)
                {
                    Instantiate(productPrefab, pirate.transform.position, Quaternion.identity);
                }
                else
                {
                    return false;
                }
                produce_time = produce_time + 1;
                currentWork = currentWork + 1;
                return true;
            }

            return true;
        }
    }
}
