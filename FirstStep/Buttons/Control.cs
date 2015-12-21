namespace FirstStep.Buttons
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    
    public abstract class Control : GoldGame.GameObject
    {
        protected string _name;

        protected Control(string name)
        {
            _name = name;
        }

        public abstract void OnKeysPressed(Keys[] keys);

        public abstract void DrawAt(Rectangle coords);

    }
}
