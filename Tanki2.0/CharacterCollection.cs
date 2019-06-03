using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class CharacterCollection
        {
            private Character[] enemies;

            public int Count { get; set; }

            public CharacterCollection()
            {
                enemies = new Character[0];
                Count = 0;
            }

            public void Add(Character character)
            {
                Character []newArray = new Character[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = enemies[i];
                }

                newArray[Count++] = character;
                enemies = newArray;
            }
            
            public void Delete(int idx)
            {
                Character[] newArray = new Character[Count - 1];
                for(int oldI = 0, newI = 0; oldI < Count; oldI++)
                {
                    if (oldI != idx)
                    {
                        newArray[newI++] = enemies[oldI];
                    }
                }

                Count--;
                enemies = newArray;
            }

            public Character this[int idx]
            {
                get { return enemies[idx]; }
                set { enemies[idx] = value; }
            }
        }
    }
}