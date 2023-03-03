using FluentValidation;
using Login.Data;
using Login.DTOS;
using Login.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Login.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IValidator<SignUpDto> _validator;

    public AccountController(AppDbContext context, IValidator<SignUpDto> validator)
    {
        _context = context;
        _validator = validator;
    }

    [HttpPost("sign-Up")]
    public IActionResult SignUp(SignUpDto signUpDto)
    {
        var user = _context.SignUpSet.Any(u => u.Name == signUpDto.Name);

        if (user)
            return BadRequest("Uje user bor");

        var passwordhash = HashPassword(signUpDto.Password);
        var resultValidator = _validator.Validate(signUpDto);
        if (resultValidator == null)
        {
            return BadRequest();
        }
        var data = new SignUp()
        {
            LastName = signUpDto.LastName,
            Name = signUpDto.Name,
            Password = passwordhash,
            Email = signUpDto.Email
        };
        _context.SignUpSet.Add(data);
        _context.SaveChanges();

        return Ok();


    }

    [HttpPost("/sign-In")]
    public IActionResult SignIn([FromBody]SignInDto signInDto)
    {
        var data = _context.SignUpSet.FirstOrDefault(options => options.Email == signInDto.Email && options.Name == signInDto.Name);
        if (data == null)
            return NotFound();

        return Ok();
    }

    private string HashPassword(string password)
    {
        SHA256 hash = SHA256.Create();
        var passwordBytes = Encoding.Default.GetBytes(password);
        var hashedpassword = hash.ComputeHash(passwordBytes);
        return Convert.ToHexString(hashedpassword);
    }

}