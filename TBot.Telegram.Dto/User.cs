using Microsoft.AspNetCore.Mvc;

namespace TBot.Telegram.Dto;

public class User
{
    [BindProperty(Name = "id")]
    public long Id { get; set; }
        
    [BindProperty(Name = "first_name")]
    public string FirstName { get; set; }
        
    [BindProperty(Name = "last_name")]
    public string? LastName { get; set; }
        
    [BindProperty(Name = "username")]
    public string? Username { get; set; }
}