using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ls_10
{
    internal class FootballTeam
    {
        private FootballPlayer[] players = new FootballPlayer[11];

        public FootballPlayer this[int index]
        {
            get 
            { 
                if (index >=  1 && index <= players.Length)
                    return players[index - 1]; 
                else return null;
            }
            set
            {
                if (index >= 1 && index <= players.Length)
                    players[index - 1] = value;
                else throw new IndexOutOfRangeException($"Несуществующий порядковый номер элемента в массиве: {index}");

            }
        }
        // Перегрузите инндексатор для получения номера телефона
        public string this[string name]
        {
            get
            {
                if (name != null)
                {
                    foreach (var player in players)
                    {
                        if (player != null && player.FullName == name)
                        {
                            return player.Phone;
                        }
                    }
                }
                return null;
            }
        }
       

    }

}
