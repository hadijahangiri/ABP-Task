# ASP.NET ZERO - ASP.NET Core Version
* Start from here: https://www.aspnetzero.com/Documents/Development-Guide-Core
* Want to port your existing MVC 5.x application? See this post: http://volosoft.com/migrating-from-asp-net-mvc-5x-to-asp-net-core/

## Installation  

1. Clone the repository:  
   ```bash  
   git clone  https://github.com/hadijahangiri/ABP-Task.git

2. Restore Packages
   ```bash  
   dotnet restore
   
3. Navigate to the project directory
   ```bash  
   cd src/MyCompanyName.AbpZeroTemplate.Web.Mvc

 4. Install front dependencies
    ```bash  
    npm install

5. Run front bundeling
   ```bash
   npm run create-bundles

6. Init Database
   ```bash
   run MyCompanyName.AbpZeroTemplate.Migrator project

7. Install RabbitMQ with docker
   ```bash
   docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4.0-management

8. Run Project
   Start MyCompanyName.AbpZeroTemplate.Web.Mvc project
