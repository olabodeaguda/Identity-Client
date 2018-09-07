## Identity-Client-Middleware
  Its a middleware developed using aspnetcore 2.1.0. It authenticate a log on user by connecting to the remote identity api. 
  
## Features
  #### it uses JWT Authentication mechanism.
  #### it retrieve token from the Authorization bearer header.
  #### It validate token by posting to the identity provider url.
  #### It finally authenticate the user by loading user details into the principal
  
## Use
  #### it is specifically built for .net core project version >= 2.1.0
  
## How to use
 #### Download from nuget by running Install-Package IdentityClientMiddleware -Version 1.0.4
 #### Include this into your start up code
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddIdentityClientAuthentication();
            services.AddIdentityClientAuthorization();
         }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIdentityClient(new IdentityClientModel()
            {
                IdentityServerUrl = Configuration[identityprovider url],
            });
        }
