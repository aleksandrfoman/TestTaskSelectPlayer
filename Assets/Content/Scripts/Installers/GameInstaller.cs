using Content.Scripts.Services;

namespace Content.Scripts.Installers
{
    public class GameInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            BindService<PlayerService>();
            BindService<GameCanvasService>();
        }
    }
}