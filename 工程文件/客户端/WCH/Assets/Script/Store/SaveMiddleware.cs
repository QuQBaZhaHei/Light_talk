

using Unity.UIWidgets;

namespace WCH
{
    public class SaveMiddleware  
    {

        public static Middleware<T> create<T>() where T : IPreservable<T>,new()
        {
            return (store) => (next) => new DispatcherImpl((action) =>
            {
                var result = next.dispatch(action);
                var afterState = store.getState();
                afterState.Save();

                return result;
            });
        }
    }
}
