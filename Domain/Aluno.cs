using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Aluno
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
