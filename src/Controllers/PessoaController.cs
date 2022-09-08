using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Persistencia;

namespace src.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
    private DatabaseContexto _contexto{ get; set; }
       
    public PessoaController(DatabaseContexto contexto){
      this._contexto = contexto;
    }  
       [HttpGet]
        public  List<Pessoa> Get(){
            
          return _contexto.Pessoas.Include(p => p.contratos).ToList();
           
        }   

        [HttpPost]
        public Pessoa Post([FromBody]Pessoa pessoa){
          _contexto.Pessoas.Add(pessoa);
          _contexto.SaveChanges();
          
          return pessoa;
        }

        [HttpPut("{id}")]
        public string Update([FromRoute]int id, [FromBody] Pessoa pessoa){
          _contexto.Pessoas.Update(pessoa);
          _contexto.SaveChanges();
          return "Dados do id" + id + " Atualizados.";
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute]int id ) {
          return "deletado pessoa de Id " +id; 
        }
    }
