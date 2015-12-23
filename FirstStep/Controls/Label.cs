namespace FirstStep.Controls
{
    using System.Runtime.Remoting.Messaging;

    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Label : SimpleGameObject
    {
        public string Caption { get; }

        public int Size { get; }

        public Label(string caption, int size)
        {
            Caption = caption;
            Size = size;
        }



    }
}
