using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using TWValidacao.Validators;
using TWValidacao.ViewModels;

namespace TWValidacao.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    // private IValidator<CreateUserViewModelFluentValidadtion> _validator;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
        // _validator = validator;
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

    public IActionResult CreateFluent()
    {
        ViewData["Title"] = "Cadastro de Usuario";
        return View();
    }

    [HttpPost]
    public IActionResult CreateFluent(CreateUserViewModelFluentValidadtion formData)
    {
        // var validator = new CreateUserValidadtor();
        // var results = validator.Validate(formData);
        // if (!results.IsValid)
        // {
        //     results.AddToModelState(ModelState, null);
        //     Console.WriteLine("houveram erros de validação");
        //     ViewData["Title"] = "Cadastro de Usuario";
        //     return View();
        // }

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