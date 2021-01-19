namespace OcarinaMultiworld.Lib
{
    public class UpdateFlag
    {
        private bool _update;
        public bool Update
        {
            get => _update;
            set
            {
                if (value) _update = true;
            }
        }
    }
}
