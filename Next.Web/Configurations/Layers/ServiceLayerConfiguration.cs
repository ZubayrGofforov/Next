using Next.Web.Interfaces;
using Next.Web.Services;
using System.Configuration;

namespace Next.Web.Configurations.Layers;
public static class ServiceLayerConfiguration
{
    public static void AddServices(this WebApplicationBuilder buider)
    {
        buider.Services.AddTransient<IUserService, UserService>();
        //services.AddSingleton<IConfiguration>(Configuration);
                        
        //builder.AddMvc().AddRazorPagesOptions(options =>
        //{
        //    options.Conventions.AddPageRoute("User/Index", "");
        //});
    }
}

