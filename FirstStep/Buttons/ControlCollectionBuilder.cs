namespace FirstStep.Buttons
{
    using Base;

    using Microsoft.Xna.Framework;

    public class ControlCollectionBuilder
    {
        private ContolCollection _contols;


        public ControlCollectionBuilder(ContolCollection contolCollection)
        {
            _contols = contolCollection;
        }

        public ControlCollectionBuilder AddControl(Control control)
        {
            _contols.Contols.Add(control);
            return this;
        }

        public ControlCollectionBuilder AtCoords(Vector2 coords)
        {
            _contols.Coordinates = coords;
            return this;
        }

        public ControlCollectionBuilder WithSize(double size)
        {
            _contols.Size = size;
            return this;
        }

        public static implicit operator ContolCollection(ControlCollectionBuilder bcb)
        {
            return bcb._contols;
        }
    }
}
