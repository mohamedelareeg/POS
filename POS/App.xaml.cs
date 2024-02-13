using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using POS.Persistence.Context;
using POS.Persistence.Models;
using POS.Views;
using System.Windows;

namespace POS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    var services = new ServiceCollection();

        //    // Add services required for authentication
        //    services.AddDbContext<AppDbContext>();
        //    services.AddIdentity<ApplicationUser, IdentityRole>()
        //        .AddEntityFrameworkStores<AppDbContext>()
        //        .AddDefaultTokenProviders();

        //    services.AddLogging();
        //    // Add AuthenticationService
        //    services.AddScoped<AuthenticationService>();

        //    // Build the service provider
        //    ServiceProvider = services.BuildServiceProvider();


        //}

        private void OnStartup(object sender, StartupEventArgs e)
        {
            // base.OnStartup(e);

            // Resolve services
            //var userManager = _serviceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();
            //var signInManager = _serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();

            //// Configure authentication
            //var authenticationService = new AuthenticationService(userManager, signInManager);

            var services = new ServiceCollection();

            // Add services required for authentication
            services.AddDbContext<AppDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequiredLength = 3; // Set the minimum password length to 3 characters
            //    options.Password.RequiredUniqueChars = 0; // Set the number of required unique characters to 0
            //});
            services.AddLogging();

            // Add authentication services

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();
            // Add AuthenticationService
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<AuthenticationService>();

            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();
            var loginView = new LoginView();
            // var loginView = new LoginView(_serviceProvider.GetService<SignInManager<ApplicationUser>>());
            loginView.Show();
            //loginView.IsVisibleChanged += (s, ev) =>
            //{
            //    if (loginView.IsVisible == false && loginView.IsLoaded)
            //    {
            //        var mainView = new MainWindow();
            //        mainView.Show();
            //        loginView.Close();
            //    }
            //};
        }
        //private IServiceProvider _serviceProvider;


        //private void ConfigureServices()
        //{
        //    var services = new ServiceCollection();
        //    services.AddApplicationDependencies()
        //            .AddInfrustructureDependencies()
        //            .AddPersistenceDependencies();
        //    services.AddIdentity<ApplicationUser, IdentityRole>()
        //              .AddEntityFrameworkStores<AppDbContext>()
        //              .AddDefaultTokenProviders();


        //    // Register MainWindow as a service
        //    services.AddSingleton<MainWindow>();

        //    _serviceProvider = services.BuildServiceProvider();
        //}


        //private void OnStartup(object sender, StartupEventArgs e)
        //{


        //    // Register dependencies
        //    ConfigureServices();



        //    // Build the service provider
        //    //UserManager<ApplicationUser> userManager = _serviceProvider.GetService<UserManager<ApplicationUser>>();
        //    //SignInManager<ApplicationUser> signInManager = _serviceProvider.GetService<SignInManager<ApplicationUser>>();
        //    var signInManager = _serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
        //    signInManager.Context = new DefaultHttpContext { RequestServices = _serviceProvider };
        //    var loginView = new LoginView(signInManager);
        //    // var loginView = new LoginView(_serviceProvider.GetService<SignInManager<ApplicationUser>>());
        //    loginView.Show();
        //    loginView.IsVisibleChanged += (s, ev) =>
        //    {
        //        if (loginView.IsVisible == false && loginView.IsLoaded)
        //        {
        //            var mainView = _serviceProvider.GetRequiredService<MainWindow>();
        //            mainView.Show();
        //            loginView.Close();
        //        }
        //    };
        //}
    }
}
