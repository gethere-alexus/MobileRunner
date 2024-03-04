using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.Factory.Character
{
    public interface ICharacterFactory : IService
    {
        void CreateCharacterPreview();
    }
}