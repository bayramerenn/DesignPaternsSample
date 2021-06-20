using Microsoft.AspNetCore.Mvc;

namespace WebApp.CommandPatern.Commands
{
    public interface ITableActionCommand
    {
         public IActionResult Execute(); 
    }
}