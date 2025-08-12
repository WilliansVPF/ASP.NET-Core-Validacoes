using Microsoft.AspNetCore.Mvc;
using TWValidacao.ViewModels;

namespace TWValidacao.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastro de Usuario";
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateUserViewModel formData)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("houveram erros de validação");
            ViewData["Title"] = "Cadastro de Usuario";
            return View();
        }
        Console.WriteLine("não houveram erros de validação");
        return RedirectToAction();
    }
}