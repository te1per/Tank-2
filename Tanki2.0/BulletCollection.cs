using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class BulletCollection
        {
            private Bullet[] bullets;

            public int Count { get; set; }

            public BulletCollection()
            {
                bullets = new Bullet[0];
                Count = 0;
            }

            public void Add(Bullet character)
            {
                Bullet[] newArray = new Bullet[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = bullets[i];
                }

                newArray[Count++] = character;
                bullets = newArray;
            }

            public void Delete(int idx)
            {
                Bullet[] newArray = new Bullet[Count - 1];
                for(int oldI = 0, newI = 0; oldI < Count; oldI++)
                {
                    if (oldI != idx)
                    {
                        newArray[newI++] = bullets[oldI];
                    }
                }

                Count--;
                bullets = newArray;
            }

            public void Print()
            {
                for (int i = 0; i < Count; i++)
                {
                    this[i].Draw();
                }
            }

            public Bullet this[int idx]
            {
                get { return bullets[idx]; }
                set { bullets[idx] = value; }
            }
        }
    }
}
