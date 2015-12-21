namespace FirstStep
{
    using System;

    using Observer;

    public partial class GoldGame
    {
        public abstract class GameObject : Subject
        {
            protected GoldGame Game => Instance;
           
        }
    }
    
}
