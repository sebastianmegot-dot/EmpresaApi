Imports Microsoft.AspNetCore.Builder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports EmpresaApi.Data
Imports EmpresaApi.Repositories
Imports EmpresaApi.Services

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        ' EF Core + SQL Server
        builder.Services.AddDbContext(Of EmpresaDbContext)(
            Sub(options) options.UseSqlServer(builder.Configuration.GetConnectionString("EmpresaDB")))

        ' Inyección de dependencias: Controller -> Service -> Repository -> DbContext
        builder.Services.AddScoped(Of IClienteRepository, ClienteRepository)()
        builder.Services.AddScoped(Of IClienteService, ClienteService)()

        Dim app = builder.Build()

        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.MapControllers()
        app.Run()
    End Sub
End Module