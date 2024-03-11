using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Components
{
    public class WineComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
