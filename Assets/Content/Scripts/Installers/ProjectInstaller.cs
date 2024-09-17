using Content.Scripts.Services;

namespace Content.Scripts.Installers
{
    public class ProjectInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            BindService<SceneService>();
            BindService<SaveService>();
        }
    }
}