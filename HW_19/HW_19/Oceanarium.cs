using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class Oceanarium
    {
        Dolphin[] dolphins;
        SeaTurtle[] seaTurtles;

        public Oceanarium(Dolphin[] dolphins, SeaTurtle[] seaTurtles)
        {
            this.dolphins = dolphins;
            this.seaTurtles = seaTurtles;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < dolphins.Length; i++)
            {
                yield return dolphins[i];
            }
            for (int i = 0; i < seaTurtles.Length; i++)
            {
                yield return seaTurtles[i];
            }
        }
    }
}
