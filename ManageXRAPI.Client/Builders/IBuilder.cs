namespace ManageXRAPI.Client.Builders
{
    public abstract class ABuilder<T> where T: new()
    {
        protected T data;

        protected ABuilder()
        {
            Reset();
        }
    
        public abstract T Build();

        protected void Reset()
        {
            data = new T();
        }
    }
}