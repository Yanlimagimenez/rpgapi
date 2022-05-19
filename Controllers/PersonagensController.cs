
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        //Programação de toda a classe ficará aqui abaixo
        private readonly DataContext _dataContext;

        public PersonagensController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

    }//Fim da classe do tipo controller
}




