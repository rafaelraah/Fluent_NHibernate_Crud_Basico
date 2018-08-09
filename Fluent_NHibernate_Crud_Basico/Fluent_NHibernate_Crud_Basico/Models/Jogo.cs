using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fluent_NHibernate_Crud_Basico.Models
{
    public class Jogo
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int Classificacao { get; set; }
    }
}