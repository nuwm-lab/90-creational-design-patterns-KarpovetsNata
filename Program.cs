using System;
using System.Collections.Generic;

// Продукт — сайт
class Website
{
    private List<string> _pages = new List<string>();

    public void AddPage(string page)
    {
        _pages.Add(page);
    }

    public void ShowPages()
    {
        Console.WriteLine("Сайт містить сторінки:");
        foreach (var page in _pages)
        {
            Console.WriteLine("- " + page);
        }
    }
}

// Абстрактний будівельник
interface IWebsiteBuilder
{
    void BuildHomePage();
    void BuildContactPage();
    void BuildServicesPage();
    Website GetWebsite();
}

// Конкретний будівельник
class ConcreteWebsiteBuilder : IWebsiteBuilder
{
    private Website _website = new Website();

    public void BuildHomePage()
    {
        _website.AddPage("Головна сторінка");
    }

    public void BuildContactPage()
    {
        _website.AddPage("Контактна сторінка");
    }

    public void BuildServicesPage()
    {
        _website.AddPage("Сторінка з описом послуг");
    }

    public Website GetWebsite()
    {
        return _website;
    }
}

// Директор
class Director
{
    private IWebsiteBuilder _builder;

    public Director(IWebsiteBuilder builder)
    {
        _builder = builder;
    }

    public void BuildMinimalWebsite()
    {
        _builder.BuildHomePage();
        _builder.BuildContactPage();
    }

    public void BuildFullWebsite()
    {
        _builder.BuildHomePage();
        _builder.BuildContactPage();
        _builder.BuildServicesPage();
    }
}

// Клієнт
class Program
{
    static void Main()
    {
        IWebsiteBuilder builder = new ConcreteWebsiteBuilder();
        Director director = new Director(builder);

        // Будуємо повний сайт
        director.BuildFullWebsite();

        Website website = builder.GetWebsite();
        website.ShowPages();
    }
}
