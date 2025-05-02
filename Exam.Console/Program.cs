// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Exam.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
serviceCollection.AddDbContext<DbContext, ExamContext>();
serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
serviceCollection.AddSingleton<Type>(p => typeof(GenericRepository<>));
//add instance of services
serviceCollection.AddScoped<IServiceChanson, ServiceChanson>();
serviceCollection.AddScoped<IServiceArtiste, ServiceArtiste>(); 
    serviceCollection.AddScoped<IConcertService, ConcertService>();
serviceCollection.AddScoped<IFestivalService, FestivalService>();


var serviceProvider = serviceCollection.BuildServiceProvider();

var sa = serviceProvider.GetRequiredService<IServiceArtiste>();
var cs = serviceProvider.GetRequiredService<IConcertService>();
var chs = serviceProvider.GetRequiredService<IServiceChanson>();
var fs = serviceProvider.GetRequiredService<IFestivalService>();


StyleMusic st = StyleMusic.Pop;

var cceerts = cs.GetConcertListByMusicalStyle(st);

var artists = sa.GetAll();
Console.WriteLine("Artists found: " + artists.Count());

foreach (var artist in artists)
{
    Console.WriteLine($"Artist ID: {artist.ArtisteId}, Name: {artist.Nom}");
    // Add other properties you want to display
}
Console.WriteLine("**************************************** ");

foreach (var cf in cceerts)
{
    Console.WriteLine($"Cachet ID: {cf.Cachet},");
    // Add other properties you want to display
}

Console.WriteLine("********************22******************** ");

chs.GetMusicalStyle(st);

Console.WriteLine("*******************GetMusicalStyledebug******************** ");

chs.GetMusicalStyledebug(st);
Console.WriteLine("*******************GetFiveChanson******************** ");

var artist2s = sa.GetMany(a=>a.ArtisteId==2).ToList().FirstOrDefault();


    foreach (var ch in chs.GetFiveChanson(artist2s))
{
    Console.WriteLine($"ChansonId : {ch.ChansonId},");
    // Add other properties you want to display
}
Console.WriteLine("*******************33******************** ");

var fes = fs.GetMany(f => f.FestivalId == 1).ToList();
foreach (var festival in fes)
{
    Console.WriteLine($"Festival ID: {festival.FestivalId}, Name: {festival.Capacite}, Location: {festival.Ville}");
    // Add other properties you want to display
    // For example: Console.WriteLine($"  Date: {festival.Date}, Capacity: {festival.Capacity}");
}

Console.WriteLine(cs.plusHautCachet(fes.FirstOrDefault()));

Console.WriteLine("Press any key to close this window...");
Console.ReadKey();