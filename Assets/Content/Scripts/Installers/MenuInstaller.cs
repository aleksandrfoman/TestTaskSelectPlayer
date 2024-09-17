using Content.Scripts.Services;

namespace Content.Scripts.Installers
{
    public class MenuInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            BindService<SelectionService>();
            BindService<MenuCanvasService>();
        }
    }
}