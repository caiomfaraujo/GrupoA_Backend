using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class AlunoModel
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Identificacao { get; set; }
        public int RegistroAcademico { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
