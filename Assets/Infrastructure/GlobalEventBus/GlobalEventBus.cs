namespace Infrastructure.GlobalEventBus
{
    public static class GlobalEventBus
    {
        public static readonly EventBus Sync = new EventBus();
    }
}