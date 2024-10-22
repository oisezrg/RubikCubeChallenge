using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubikCubeChallenge.Abstraction;
using RubikCubeChallenge.Printer;
using RubikCubeChallenge.Rubik;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<IPrinter, Printer>();
builder.Services.AddTransient<ICube, Cube>();
builder.Services.AddSingleton<ICubeFaceFactory, CubeFaceFactory>();

using IHost host = builder.Build();

RubikCubeChallengeRunner(host.Services);

static void RubikCubeChallengeRunner(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;


    ICube cube = provider.GetRequiredService<ICube>();

    cube.F();
    cube.R_();
    cube.U();
    cube.B_();
    cube.L();
    cube.D_();
    cube.Print();
    Console.WriteLine("...");
}