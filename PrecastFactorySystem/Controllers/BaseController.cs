namespace PrecastFactorySystem.Controllers
{
	using System.Linq.Expressions;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Data.Models;

	[Authorize]
	public  class BaseController : Controller
	{
	
       
	}
}
